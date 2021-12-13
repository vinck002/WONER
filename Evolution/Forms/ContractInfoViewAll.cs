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
    public partial class ContractInfoViewAll : Form
    {
        public ContractInfoViewAll()
        {
            InitializeComponent();
        }
        DataView DVContractInfo = new DataView();
        DataView DVContractSummary = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();

        private void ContractInfoViewAll_Load(object sender, EventArgs e)
        {
            CreationDate1.SetToNullValue();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
        }

        private void  Btnsearch_Click(object sender, EventArgs e)
        {
           
                if (SalesfloorID.Text.Trim() == "" && PropertyID.Text.Trim() == "" && Contract1.Text.Trim() == "" && Contract2.Text.Trim() =="")
                {
                    if (MessageBox.Show("Search All Contracts ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                }

            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void  SearchContracts() 
        {
            try
            {
                /*-------------------------------------------------------------------*/
                DVContractInfo =  SQLCMD.SQLdata("LS_ContractInfoViewAll_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text.Trim()) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text.Trim() + "'") + "," +
             ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + "," + ((Contract2.Text.Trim() == "") ? "9999999999" : Contract2.Text.Trim()) + ",'" +
            ((CreationDate1.Text.Trim() == "") ? "01-01-1990" : CreationDate1.Text.Trim()) + "','" + ((CreationDate2.Text.Trim() == "") ? "01-01-3000" : CreationDate2.Text.Trim()) + "',0").DefaultView;
            /*--------------------------------Search Summary-----------------------------------------------*/
            DVContractSummary = SQLCMD.SQLdata("LS_ContractInfoViewAll_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text.Trim()) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text.Trim() + "'") + "," +
              ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + "," + ((Contract2.Text.Trim() == "") ? "9999999999" : Contract2.Text.Trim()) + ",'" +
             ((CreationDate1.Text.Trim() == "") ? "01-01-1990" : CreationDate1.Text.Trim()) + "','" + ((CreationDate2.Text.Trim() == "") ? "01-01-3000" : CreationDate2.Text.Trim()) + "',1").DefaultView;
                /*------------------------------------------------------------------------------*/
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void  FillGridInfo()
        {
            try
            {
                ContractList.DataSource = DVContractInfo;
                ContractPaying.DataSource = DVContractInfo;
                 TotalContracts.DataSource = DVContractSummary;
                if (DVContractInfo.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                for (int rw = 0; rw <= ContractList.RowCount - 1; rw++)
                {
                    ContractList.Rows[rw].Cells["ClosingPercent"].Style.ForeColor = ((decimal.Parse(ContractList.Rows[rw].Cells["ClosingPercent"].Value.ToString()) > 100) ? Color.Red : Color.Black);
                    ContractList.Rows[rw].Cells["TaxPercent"].Style.ForeColor = ((decimal.Parse(ContractList.Rows[rw].Cells["TaxPercent"].Value.ToString()) > 100) ? Color.Red : Color.Black);
                }
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void ContractInfoViewAll_Activated(object sender, EventArgs e)
        {
            SalesfloorID.Focus();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            CreationDate1.SetToNullValue();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            SalesfloorID.Focus();
        }

        private void ContractInfoViewAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
        }

        private void Contract2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Btnsearch.PerformClick(); }
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Contract2.SelectionStart = 0;
                Contract2.SelectionLength = Contract2.Text.Length; Contract2.Focus();
            }
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2)
            {
                SalesfloorID.Text = SalesfloorID.Text; PropertyID.SelectionStart = 0;
                PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus();
            }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2)
            { PropertyID.Text = PropertyID.Text; Contract1.Focus(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                if (ContractList.RowCount < 1) { return; }
                wwt.Show(); wwt.Refresh();
                General.ContractsCommission ContractsCommission = new General.ContractsCommission();
                ContractsCommission.ExportContractCommission(ContractList,TotalContracts);
            }
            catch (Exception ecx)
            { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bExportContracts_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                if (ContractList.RowCount < 1) { return; }
                wwt.Show(); wwt.Refresh();
                General.ContractsCommission ContractsOnly = new General.ContractsCommission();
                ContractsOnly.ExportContractOnly(ContractList);
            }
            catch (Exception ecx)
            { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchContracts();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGridInfo();
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "Wait").FirstOrDefault();
            frm.Close();
        }

        /*============================================================================================================================================================================*/
    }
}
