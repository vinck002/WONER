using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evolution.General;
namespace Evolution.Forms
{
    public partial class ArrearsContractCommission :Form
    {
        public ArrearsContractCommission()
        {
            InitializeComponent();
        }
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void ArrearsContractCommission_Load(object sender, EventArgs e)
        {
            Btnclear.PerformClick();
            GlobalAccess access = new GlobalAccess();
            access.groubox(grbButtonContainer);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = Globalvariables.Systemdate.ToShortDateString();
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            CkbToPay.Checked = true;
            SalesfloorID.Focus();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(Contractdate1.Text != "") 
                {
                    if (DateTime.Parse(Contractdate1.Text) > DateTime.Parse(Contractdate2.Text)) { MessageBox.Show("Invalid Date Range", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); Contractdate2.Focus(); return; }
                }
                if (Contract1.Text != "" && Contract2.Text !="")
                {
                    if (long.Parse(Contract1.Text) > long.Parse(Contract2.Text)) { MessageBox.Show("Invalid Contract Range", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); Contract2.Focus(); return; }
                }
                bgwSearch.RunWorkerAsync();
                Wait wwt = new Wait();
                wwt.ShowDialog();
            }
            catch(Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"LS_ArrearsContractCommission_SPR 1,{((SalesfloorID.Text.Trim()=="")? "Null": SalesfloorID.Text.Trim())}," +
                $"{((PropertyID.Text.Trim() == "")? "Null": "'"+PropertyID.Text.Trim() +"'")}," +
                $"'{((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text)}', '{Contractdate2.Text}'," +
                $"{((Contract1.Text.Trim()=="")? 1 : long.Parse(Contract1.Text))},{((Contract2.Text.Trim() == "") ? 99999999999 : long.Parse(Contract2.Text))},{((CkbToPay.Checked ==true)? 1 : 0)}").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtTotalToBePaid.Text = "0.00";
            TxtTotalToBePaid2.Text = "0.00";
            GRDContractList.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            if(DVSearch.Count > 0) 
            {
                decimal TotalToPay = 0;
                for (int R1 = 0; R1 <= GRDContractList.RowCount - 1; R1++)
                {
                    GRDContractList.Rows[R1].Cells["AmountPaid"].Style.ForeColor = Color.Blue;
                    GRDContractList.Rows[R1].Cells["ToPay"].Style.ForeColor = Color.Red;
                    TotalToPay = TotalToPay + decimal.Parse(GRDContractList.Rows[R1].Cells["ToPay"].Value.ToString());
                }
                TxtTotalToBePaid.Text = TotalToPay.ToString("#,##0.00") ;
                TxtTotalToBePaid2.Text = TotalToPay.ToString("#,##0.00");
            }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name =="Wait");
            frm.Close();
            if (DVSearch.Count < 1) { MessageBox.Show("No Record Found", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ArrearsContractCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim().Length >= 2) { PropertyID.Focus(); PropertyID.SelectAll(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.Text.Trim().Length >= 2) { Contract1.Focus(); Contract1.SelectAll(); }
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexbox valida = new ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexbox valida = new ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexbox valida = new ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (GRDContractList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try 
            {
                wwt.Show(); wwt.Refresh();
                ExportArrearsCommission.ExportarGridview(GRDContractList, DateTime.Parse(Contractdate2.Text).ToString("MMM-dd-yyyy") );
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            if (GRDContractList.RowCount < 1) { return; }
            try 
            {
                StringBuilder SqlQuery = new StringBuilder();
                string ProcessCode = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") + "" + DateTime.Now.ToString("ss");
                /*------------------------------------------------------------------*/
                for (int row=0; row <= GRDContractList.RowCount -1; row++) 
                {
                    if (int.Parse(GRDContractList.Rows[row].Cells["Select"].Value.ToString()) == 1 && int.Parse(GRDContractList.Rows[row].Cells["AllowPay"].Value.ToString()) == 1) 
                    {
                        SqlQuery.Append($"Exec LS_ArrearsContractCommission_SPM 0,0,{GRDContractList.Rows[row].Cells["AgreementID"].Value.ToString()}," +
                            $"{GRDContractList.Rows[row].Cells["MultifinanceID"].Value.ToString()},{GRDContractList.Rows[row].Cells["ToPay"].Value.ToString()}," +
                            $"'Cut Of Date: {Contractdate2.Text}',{ProcessCode},{Globalvariables.guserid}"+" ");
                    }
                }
                /*------------------------------------------------------------------*/
                if (SqlQuery.Length <=0) { MessageBox.Show("No Contract Selected Or Nothing To Pay", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Process", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                bSearch.PerformClick();
                /*------------------------------------------------------------------*/
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bHidtory_Click(object sender, EventArgs e)
        {
            ArrearsContractCommissionHistory history = new ArrearsContractCommissionHistory();
            history.ShowDialog();
        }
    }
}
