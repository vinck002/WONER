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
    public partial class TransferUpgradePayments : Form
    {
        public TransferUpgradePayments()
        {
            InitializeComponent();
        }
        DataView DVTranferenceLog = new DataView();
        DataView DVTransfer = new DataView();
        DataView DVPayments = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        public string AgreementID = "0";
        private void bSave_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (transactionslist.Rows.Count < 1) { MessageBox.Show("No Transaction In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                string TransferenceID = "", TransactionID = "0";
                TransferenceID = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") + "" + DateTime.Now.ToString("ss");
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                for (int record = 0; record <= transactionslist.RowCount - 1; record++)
                {
                    if (transactionslist.Rows[record].Cells["Select"].Value.ToString() == "1")
                    {
                        TransactionID = TransactionID + "," + transactionslist.Rows[record].Cells["TransactionID"].Value.ToString();
                    }
                }
                /*-----------------------------------------------------------------------------------------------------------------------------------------*/
                if (TransactionID =="0") { MessageBox.Show("No Transaction Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Transference", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVTranferenceLog = SQLCMD.SQLdata("LS_GenerationPayments_M " + TransferenceID + "," + General.Globalvariables.guserid + "").DefaultView;
                DVTransfer = SQLCMD.SQLdata("Exec LS_TransferUpgradePayments_M '" + TransactionID + "','" + TransferenceID + "',"+AgreementID+"").DefaultView;
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

        private void TransferUpgradePayments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void TransferUpgradePayments_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            DVPayments = SQLCMD.SQLdata("Exec LS_TransferUpgradePayments_L " + AgreementID + "").DefaultView;
            transactionslist.DataSource = DVPayments;
            Found.Text = DVPayments.Count.ToString();
        }
/*--------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
