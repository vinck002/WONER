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
    public partial class ContractPaymentStatus : Form
    {
        public ContractPaymentStatus()
        {
            InitializeComponent();
        }
        DataView DVSave = new DataView();
        DataView DVLoad = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
      public  string ContractPaymentStatusID = "0",AgreementID="0";

        private void ContractPaymentStatus_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            DVLoad = SQLCMD.SQLdata("LS_ContractPaymentStatus_ML 3,0,"+AgreementID+",0").DefaultView;
            transactionslist.DataSource = DVLoad;
            transactionslist.Columns[0].IsVisible = false;
            transactionslist.Columns[1].IsVisible = false;
            transactionslist.Columns[4].IsVisible = false;
        }

        private void bSave_Click(object sender, EventArgs e)
        {   if(transactionslist.RowCount <1 & AllowPay.Checked == false) { MessageBox.Show("Please Check Allow Payment","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            ContractPaymentStatusID = ((transactionslist.RowCount <1)? "0" : transactionslist.CurrentRow.Cells["ContractPaymentStatusID"].Value.ToString());
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                DVSave = SQLCMD.SQLdata("LS_ContractPaymentStatus_ML " + ((ContractPaymentStatusID == "0") ? "0" : "1") + "," + ContractPaymentStatusID + "," +
                    AgreementID + "," + ((AllowPay.Checked == true) ? "1" : "0") + "").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }

        }

        private void bInactivate_Click(object sender, EventArgs e)
        {
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Transaction In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ContractPaymentStatusID = ((transactionslist.RowCount < 1) ? "0" : transactionslist.CurrentRow.Cells["ContractPaymentStatusID"].Value.ToString());
            Wait wwt = new Wait();
            if(MessageBox.Show("Confirm Inactivate", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No) { return; }
            try
            {
                wwt.Show(); wwt.Refresh();
                DVSave = SQLCMD.SQLdata("LS_ContractPaymentStatus_ML 2," + ContractPaymentStatusID + "," +
                    AgreementID + "," + ((AllowPay.Checked == true) ? "1" : "0") + "").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContractPaymentStatus_Activated(object sender, EventArgs e)
        {
            if(transactionslist.RowCount < 1) { return; }
            AllowPay.Checked = ((transactionslist.CurrentRow.Cells["Paystatus"].Value.ToString() =="1")? true : false);
        }

        private void ContractPaymentStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }
 /*---------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
