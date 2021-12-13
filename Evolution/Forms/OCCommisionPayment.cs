using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;
using Telerik.WinControls.Export;

namespace Evolution.Forms
{   
    public partial class OCCommisionPayment : Form
    {   
        public OCCommisionPayment()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OCCommisionPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (GRDHistory.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                General.ExportOCCommision comm = new General.ExportOCCommision();
                comm.ExportToExcel(DVSearch);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
            /*--------------------------------------------------------------*/
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            CreationDate1.SetToNullValue(); CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void OCCommisionPayment_Load(object sender, EventArgs e)
        {
            Btnclear.PerformClick();
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_MemberServiceFeeSearch_L "+((ckbHistory.Checked==false)? 2 : 3)+","+((SalesfloorID.Text.Trim() == "")? "null" : SalesfloorID.Text.Trim())+","+
                  ((PropertyID.Text.Trim() == "") ? "null" : "'"+ PropertyID.Text.Trim() +"'") +",null,null,null,null,"+ ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + ","+
                  ((Contract2.Text.Trim() == "") ? "999999999999" : Contract2.Text.Trim()) + ",'"+ ((CreationDate1.Text == "") ? "01-01-1990" : CreationDate1.Text.Trim()) + "','"+
                 ((CreationDate2.Text == "") ? "01-01-3000" : CreationDate2.Text.Trim()) + "'").DefaultView;

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void ClearSummary()
        {
            Paymentmade.Text ="0.00";
            Appliedpayment.Text = "0.00";
            Totaltobepaid.Text = "0.00";
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (ckbHistory.Checked == false)
            {
                GRDHistory.DataSource = DVSearch;
                Found.Text = DVSearch.Count.ToString();
                if (DVSearch.Count < 1) { ClearSummary(); goto Proximo; }
                Paymentmade.Text = DVSearch.Table.Rows[0]["TOTAL"].ToString();
                Appliedpayment.Text = DVSearch.Table.Rows[0]["TOTALPAID"].ToString();
                Totaltobepaid.Text = DVSearch.Table.Rows[0]["TOTALTOBEPAID"].ToString();
                for (int R1 = 0; R1 <= GRDHistory.RowCount - 1; R1++)
                {
                    GRDHistory.Rows[R1].Cells["AmountPaid"].Style.ForeColor = Color.Blue;
                    GRDHistory.Rows[R1].Cells["ToPay"].Style.ForeColor = Color.Green;
                }
                Proximo:;
                OptToPay.Enabled = true;
            }
            else
            {
                ReportViewer repo = new ReportViewer();
                string path = "Reports\\ServiceFeeCommisionHistory.rpt";
                repo.reportpath = path;
                repo.Inforeport = DVSearch;
                repo.ShowDialog();
                OptToPay.Enabled = false ;
                GRDHistory.DataSource = null;
            }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name =="Wait");
            frm.Close();
            /*-------------------------------------------------*/
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { Contract1.SelectionStart = 0; Contract1.SelectionLength = Contract1.Text.Length; Contract1.Focus(); }
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            if(GRDHistory.RowCount < 1) { return; }
            /*----------------------------------------------------*/
            StringBuilder SqlQuery = new StringBuilder();
            string ProccessStatus = "";
            ProccessStatus = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") + "" + DateTime.Now.ToString("ss");
            for (int R1 = 0; R1 <= GRDHistory.RowCount - 1; R1++)
            {
                if(int.Parse(GRDHistory.Rows[R1].Cells["Select"].Value.ToString()) != 0 && decimal.Parse(GRDHistory.Rows[R1].Cells["ToPay"].Value.ToString()) != 0)
                {
                    SqlQuery.Append("exec LS_MemberServiceFeePayment_M 0,0," + GRDHistory.Rows[R1].Cells["AgreementID"].Value.ToString() + "," + GRDHistory.Rows[R1].Cells["CompanyPercentID"].Value.ToString() + "," +
                       decimal.Parse(GRDHistory.Rows[R1].Cells["ToPay"].Value.ToString()) +","+ General.Globalvariables.guserid +",null,"+ ProccessStatus + ""+" ");
                }
                
            }
            if (SqlQuery.Length == 0) { MessageBox.Show("No Tranasactions Selected Or Nothing To Proccess","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }

            // ----------------------------------
            if (MessageBox.Show("Confirm Proccess", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
            bSearch.PerformClick();
            MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*---------------------------------------------------------------*/
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (GRDHistory.RowCount < 1) { return; }
            StringBuilder SqlQuery = new StringBuilder();
            Boolean AllowDelete = false;
            /*----------------------------------------------------*/
             SqlQuery.Append("exec LS_MemberServiceFeePayment_M 2,@UserID=" + General.Globalvariables.guserid + "");
            // ----------------------------------
            if (MessageBox.Show("Confirm Undo", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            Authorization aauto = new Authorization();
            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AllowDelete = true;
            }
            if(AllowDelete == false) { MessageBox.Show("Operation Was Canceled", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            /*---------------------------------*/
            DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
            bSearch.PerformClick();
            MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*---------------------------------------------------------------*/
        }

        private void OptToPay_Click(object sender, EventArgs e)
        {
            if (OptToPay.CheckState == CheckState.Unchecked)
            {
                
                    DVSearch.RowFilter = "ToPay <>0";
                FillGrid2();
            }
            else
            {
                DVSearch.RowFilter = "";
                FillGrid2();
            }
        }
        private void FillGrid2()
        {
            GRDHistory.DataSource = DVSearch;
            if(GRDHistory.RowCount < 1) { return; }
            for (int R1 = 0; R1 <= GRDHistory.RowCount - 1; R1++)
            {
                GRDHistory.Rows[R1].Cells["AmountPaid"].Style.ForeColor = Color.Blue;
                GRDHistory.Rows[R1].Cells["ToPay"].Style.ForeColor = Color.Green;
            }
        }
        /*====================================================================================================*/
    }
}
