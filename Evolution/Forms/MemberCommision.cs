using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class MemberCommision : Form
    {
        public MemberCommision()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void MemberCommision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); } 
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim() == "") { MessageBox.Show("Missing SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void SumCommision()
        {
            if (DVSearch.Count <1) { TotalToBePaid.Text = "0.00"; TotalPaid.Text = "0.00"; return; }
            decimal Topay = 0, Paid = 0;
            for (int record=0; record<=ContractList.RowCount -1; record++)
            { Topay = Topay + decimal.Parse(ContractList.Rows[record].Cells["ToPay"].Value.ToString());
                Paid = Paid + decimal.Parse(ContractList.Rows[record].Cells["CommisionPaid"].Value.ToString());
                ContractList.Rows[record].Cells["CommisionPercent"].ReadOnly = ((decimal.Parse(ContractList.Rows[record].Cells["ToPay"].Value.ToString()) <=0)? true : false); /*no editable cuando no va a pagar*/
            }
            TotalToBePaid.Text = Topay.ToString("#,##0.00");
            TotalPaid.Text = Paid.ToString("#,##0.00");
        }
        private void MemberAgreementNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) { Sequence.SelectionStart = 0; Sequence.SelectionLength = Sequence.Text.Length;  Sequence.Focus(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void MemberAgreementNo_Click(object sender, EventArgs e)
        {
            MemberAgreementNo.SelectAll();
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            if(ContractList.RowCount < 1) { MessageBox.Show("No Contracts", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); MemberAgreementNo.Focus(); return; }
            try
            {
                string ProcessCode = "";
                ProcessCode = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") + "" + DateTime.Now.ToString("ss");
                StringBuilder Query = new StringBuilder();
                /*---------------------------------------------------------------*/
                for (int Record = 0; Record <= ContractList.RowCount - 1; Record++)
                {
                    if (decimal.Parse(ContractList.Rows[Record].Cells["ToPay"].Value.ToString()) != 0 && int.Parse(ContractList.Rows[Record].Cells["Select"].Value.ToString()) ==1) 
                    {
                        Query.Append("Exec LS_CompanyCommissionReport_M 0,0,0," + ContractList.Rows[Record].Cells["agreementID"].Value.ToString() + ",'0'," + 
                            ContractList.Rows[Record].Cells["ToPay"].Value.ToString() + ",0,0,0,0," + General.Globalvariables.guserid + ",'MC-"+ ProcessCode + "',"+
                           ContractList.Rows[Record].Cells["CompanyID"].Value.ToString() + ",'01-01-1990','"+DateTime.Now.ToShortDateString()+"'"+" ");
                    }
                }
                if (Query.Length == 0) { MessageBox.Show("Nothing To Pay", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Process", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata(Query.ToString()).DefaultView;
                bSearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContractList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
               if (e.ColumnIndex == 11) { CalculatePercentToPay(); } 
        }
        private void CalculatePercentToPay()
        {
            try
            {
                if (ContractList.RowCount < 1) { return; }
                String Value = ContractList.CurrentRow.Cells["CommisionPercent"].Value.ToString();
                if (decimal.Parse(ContractList.CurrentRow.Cells["ToPay"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Cannot Change Percent When Contract Amount To Pay is minor or Equal than Zero", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                if (decimal.Parse(ContractList.CurrentRow.Cells["CommisionPercent"].Value.ToString()) <= 0 || decimal.Parse(ContractList.CurrentRow.Cells["CommisionPercent"].Value.ToString()) > 100)
                {
                    MessageBox.Show("Invalid Percent...", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                ContractList.CurrentRow.Cells["ToPay"].Value = (decimal.Parse(ContractList.CurrentRow.Cells["Price"].Value.ToString()) * decimal.Parse(ContractList.CurrentRow.Cells["CommisionPercent"].Value.ToString())) / 100;
                DVSave = SQLCMD.SQLdata("LS_MemberPercentPayment_M "+ ContractList.CurrentRow.Cells["AgreementID"].Value.ToString() + ","+ ContractList.CurrentRow.Cells["CompanyID"].Value.ToString() + ","+
                   ContractList.CurrentRow.Cells["CommisionPercent"].Value.ToString() + ","+General.Globalvariables.guserid+"").DefaultView;
                SumCommision(); //para refrescar el monto a pagar al miebro
            }
            catch (Exception ) { MessageBox.Show("Invalid Amount", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ContractList_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void ContractList_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
        {
            
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (DVSearch.Count < 1) { return; }
                General.ExportMemberCommision exportar = new General.ExportMemberCommision();
                exportar.ExportToExcel(DVSearch);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
             try
            {
                DVSearch = SQLCMD.SQLdata("LS_MemberCommisions_L "+decimal.Parse(SalesfloorID.Text)+"," + ((PropertyID.Text.Trim()=="")? "Null" : "'"+PropertyID.Text.Trim()+"'") + ","+
               ((MemberAgreementNo.Text.Trim() =="")? "null" : MemberAgreementNo.Text.Trim()) +","+ ((Sequence.Text.Trim() == "") ? "null" : Sequence.Text.Trim())+"," + ((Include.CheckState == CheckState.Checked) ? 1 : 0) + ","+ (chToPay.IsChecked ?1:0)).DefaultView;
                
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContractList.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            SumCommision();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name =="Wait");
            frm.Close();
            /*------------------------------------------------*/
        }

        private void bHidtory_Click(object sender, EventArgs e)
        {
            MemberCommisionHistory ph = new MemberCommisionHistory();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(PayoffHistory))
                {
                    frm.BringToFront();

                    return;
                }

            }
            ph.MdiParent = MdiParent;
            ph.Show();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            MemberAgreementNo.Text = "";
            Sequence.Text = ""; SalesfloorID.Focus();

        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { MemberAgreementNo.SelectionStart = 0; MemberAgreementNo.SelectionLength = MemberAgreementNo.Text.Length; MemberAgreementNo.Focus(); }
        }

        private void Sequence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void MemberCommision_Activated(object sender, EventArgs e)
        {
            SalesfloorID.Focus();
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void MemberCommision_Load(object sender, EventArgs e)
        {

        }

        private void ContractList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
        
        }

        private void ContractList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
