using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
namespace Evolution.Forms
{
    public partial class PaymentDetail :Form
    {
        public PaymentDetail()
        {
            InitializeComponent();
        }
        public string agreementid = "0", datecreate,Option="0";
        
        public double sumatoria = 0,totalcorrection=0;
        DataView document = new DataView();
        DataView DVInactive = new DataView();
        DataView transactionview = new DataView();
        DataView DvUpgrade = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        string currentdate = DateTime.Now.ToShortDateString();
        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void PaymentDetail_Load(object sender, EventArgs e)
        {
            document = SQLCMD.SQLdata("ls_OWNERSHIPDOCUMENT_l 1").DefaultView;
            documenttype.DataSource = document;
            documenttype.DisplayMember = "description";
            documenttype.ValueMember = "ID_OWNERSHIPDOCUMENT";
            documenttype.Text = "";
            FillGrid();
            Transactiondate.Text = DateTime.Now.ToShortDateString();
            DvUpgrade = SQLCMD.SQLdata($"LS_VerifyUpgrade_L 1,{agreementid}").DefaultView;
            if(DvUpgrade.Count > 0) 
            {
                btnUpgradePay.Visible = true;
                lblUpgrade.Visible = true;
                lblUpgrade.Text = DvUpgrade.Table.Rows[0]["AgreementNumber"].ToString();
            }
        }
        private void FillGrid()
        {
            Wait wwt = new Wait();
            bgwSearch.RunWorkerAsync();
            wwt.ShowDialog();
           
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
           
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (documenttype.Text.Trim() == ""){ MessageBox.Show("Select Document Type", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Comment.Text.Trim() == "") { MessageBox.Show("Reference is required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Transactiondate.Text.Trim() == "") { MessageBox.Show(" Application Date is required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (DateTime.Parse(Transactiondate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (Amount.Text.Trim() == "") { MessageBox.Show("Amount is required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*---------------------------------------------------------------------------------------------*/
            transactionview = SQLCMD.SQLdata("LS_DOCUMENTTRANSACTION_M2 0,"+ documenttype.SelectedValue.ToString()+","+agreementid+",'"+
                   Comment.Text  +"','"+Transactiondate.Text+"',"+General.Globalvariables.guserid+","+Amount.Text+"").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumeros(e);
        }

        private void PaymentDetail_Activated(object sender, EventArgs e)
        {
            Transactiondate.SetToNullValue();
            if (Option == "1")
            {
                radLabel5.Visible =  false ;
                TotalPaid1.Visible = false ;
            }
        }

        private void PaymentDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void bInactive_Click(object sender, EventArgs e)
        {
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Transactions in the List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*-------------------------------------------------------------------------------------------------*/
            string TransactionId ="",TransactionInfo="";
            for (int Rw = 0; Rw <= transactionslist.RowCount - 1; Rw++)
            {
                if (int.Parse(transactionslist.Rows[Rw].Cells["Selected"].Value.ToString()) == 1)
                {
                    if (transactionslist.Rows[Rw].Cells["notes"].Value.ToString() != "payment" && transactionslist.Rows[Rw].Cells["notes"].Value.ToString() != "CNDN")
                    {
                        TransactionInfo = TransactionInfo + "\n" + transactionslist.Rows[Rw].Cells["TRANSACTIONTYPE"].Value.ToString() +" US$ "+ transactionslist.Rows[Rw].Cells["Amount"].Value.ToString()+"\n";
                    }
                    else
                    {
                        TransactionId = TransactionId + ((TransactionId.Length <= 0) ? "" : ",") + transactionslist.Rows[Rw].Cells["ID"].Value.ToString();
                    }
                }
            }
            /*-------------------------------------------------------------------------------------------------*/
            if (TransactionId.Length <=0) { MessageBox.Show("Select A Valid Transaction", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (TransactionInfo.Length > 0) { MessageBox.Show($"Theses Transactions Type Will Not Be Inactivated \n {TransactionInfo}", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (MessageBox.Show("Confirm Inactive ", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            /*-------------------------------------------------------------------------*/
            try
            {
                DVInactive = SQLCMD.SQLdata("LS_InactivePayments_M 1,'" + TransactionId + "'," + General.Globalvariables.guserid + "").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*------------------------------------------------------------------------*/
        }

        private void btnUpgradePay_Click(object sender, EventArgs e)
        {
            PaymentFromUpgrade pmt = new PaymentFromUpgrade();
            pmt.AgreementID = long.Parse(agreementid);
            pmt.UpgradeAgreementID = long.Parse(DvUpgrade.Table.Rows[0]["AgreementID"].ToString());
            pmt.Controls["grbSearch"].Controls["mebAmount"].Text = AccountReceivable.Text;
            if (pmt.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                this.Close();
            }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            transactionview =  SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_L1 null,null,'" + datecreate + "',null,null,2,null,null," + agreementid + ",null").DefaultView;
           // transactionslist.DataSource = transactionview;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            transactionslist.DataSource = transactionview; /*puesto hoy 2020-12-01*/
            if (transactionview.Count > 0)
            { 
                for (int record1 = 0; record1 <= transactionslist.RowCount - 1; record1++)
                {
                    /*---------------------------------------------------------------------------------------*/
                    if (Convert.ToInt32(transactionslist.Rows[record1].Cells["hold"].Value.ToString()) == 1)
                    { transactionslist.Rows[record1].Cells["amount"].Style.ForeColor = Color.Red; }
                    /*--------------------------------------------------------------------*/
                    if (transactionslist.Rows[record1].Cells["notes"].Value.ToString() == "CN_DN" || transactionslist.Rows[record1].Cells["notes"].Value.ToString() == "CNBN")
                    { transactionslist.Rows[record1].Cells["hold"].ReadOnly = true; }
                    /*-----------------------------------------------------------------------------------------------------*/
                    if (transactionslist.Rows[record1].Cells["notes"].Value.ToString() == "CN_DN" || transactionslist.Rows[record1].Cells["notes"].Value.ToString() == "CNBN")
                    {
                        transactionslist.Rows[record1].Cells["TRANSACTIONTYPE"].Style.ForeColor = Color.Red;
                    }
                    if (transactionslist.Rows[record1].Cells["notes"].Value.ToString() == "CNG")
                    {
                        transactionslist.Rows[record1].Cells["TRANSACTIONTYPE"].Style.ForeColor = Color.Blue;
                    }
                    /*--------------------------------------------------------------------------------------------------------*/
                    if (transactionslist.Rows[record1].Cells["endhold"].Value.ToString() != "")
                    { transactionslist.Rows[record1].Cells["hold"].ReadOnly = true; }
                    /*----------------------Poner color Azul y letra blanca cuando sea la transaccion desde un upgrade-----------------------------------------------------------------------*/
                    if (int.Parse(transactionslist.Rows[record1].Cells["IsFromUpgrade"].Value.ToString()) == 1)
                    {
                       // this.transactionslist.Rows[record1].Cells["Amount"].Style.CustomizeFill = true;
                       // this.transactionslist.Rows[record1].Cells["Amount"].Style.DrawFill = true;
                        this.transactionslist.Rows[record1].Cells["Amount"].Style.ForeColor = Color.Blue;
                       // this.transactionslist.Rows[record1].Cells["Amount"].Style.BackColor = Color.Blue;
                        //--------------------------------------------
                       // this.transactionslist.Rows[record1].Cells["Date"].Style.CustomizeFill = true;
                       // this.transactionslist.Rows[record1].Cells["Date"].Style.DrawFill = true;
                        this.transactionslist.Rows[record1].Cells["Date"].Style.ForeColor = Color.Blue;
                       // this.transactionslist.Rows[record1].Cells["Date"].Style.BackColor = Color.Blue;
                    }
                    /*--------------------------------------------------------------------*/
                }
 
            }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name == "Wait");
            frm.Close();
        }

        private void transactionslist_CellClick(object sender, GridViewCellEventArgs e)
        {
           // int record = transactionslist.CurrentRow.Index;
            string endhold = "", notes = "";
            endhold =  transactionslist.CurrentRow.Cells["endhold"].Value.ToString();
            notes = transactionslist.CurrentRow.Cells["notes"].Value.ToString();
            if (e.ColumnIndex == 6)
            { if(endhold != "") { MessageBox.Show("Cannot Set This payment Hold Because it Has Been Holded Before","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
                if ( notes == "CN_DN") { MessageBox.Show("Cannot Set Debit or Credit Note Document Hold", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
        }

        private void bHold_Click(object sender, EventArgs e)
        {
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Transactions in the List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Transactiondate.Text.Trim() == "") { MessageBox.Show("Application Date is Required","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
             
            if (DateTime.Parse(Transactiondate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string querySQL = "";
            for (int record = 0; record <= transactionslist.RowCount - 1; record++)
            {
                if (int.Parse(transactionslist.Rows[record].Cells["hold"].Value.ToString()) != int.Parse(transactionslist.Rows[record].Cells["holdvalue"].Value.ToString()))
                {

                    querySQL = querySQL + " " + "EXEC LS_HOLDTRANSACTION_M2 "+ agreementid + "," + General.Globalvariables.guserid + "," +
                        transactionslist.Rows[record].Cells["ID"].Value.ToString() + "," + transactionslist.Rows[record].Cells["hold"].Value.ToString() + ",'" + 
                        ((Transactiondate.Text=="")? DateTime.Now.ToShortDateString() : Transactiondate.Text) + "'";
                }
            }
            if(querySQL == "") { MessageBox.Show("No Transactions Changes To Set Hold ","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Confirm Set Hold ", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            transactionview = SQLCMD.SQLdata(querySQL).DefaultView;
            FillGrid();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            string notes = "";
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Transactions in the List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
  
            notes = transactionslist.CurrentRow.Cells["notes"].Value.ToString();
            if (notes == "payment" || notes== "CNDN") { MessageBox.Show("Undo is Only For Debit or Credit Notes Document","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
            transactionview = SQLCMD.SQLdata("LS_DOCUMENTTRANSACTION_M2 2," + transactionslist.CurrentRow .Cells["ID"].Value.ToString() + "," +
                agreementid + ",' none ','" + ((Transactiondate.Text=="")? Transactiondate.Text : Transactiondate.Text) + "'," + General.Globalvariables.guserid + ",0").DefaultView;
            FillGrid();
            MessageBox.Show("Undo Successful","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        /*-----------------------------------------------------------------------------------------------------------------*/
    }
}
