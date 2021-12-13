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
    public partial class PaymentFromUpgrade :Form
    {
        public PaymentFromUpgrade()
        {
            InitializeComponent();
        }
        DataView DvSearch = new DataView();
        DataView DvSave = new DataView();
        public long AgreementID = 0, UpgradeAgreementID=0;
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void PaymentFromUpgrade_Load(object sender, EventArgs e)
        {
            bSearch.PerformClick();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            DvSearch = SQLCMD.SQLdata($"LS_PaymentFromUpgrade_L 1,{UpgradeAgreementID}").DefaultView;
            transactionslist.DataSource = DvSearch;
            Found.Text = DvSearch.Count.ToString();
            if (DvSearch.Count < 1) { MessageBox.Show("No Record Found", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void PaymentFromUpgrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.DialogResult = DialogResult.Cancel; }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string TransactionID = "";
            decimal AmountPaid = 0;
            try 
            {
                for (int rw=0; rw<= transactionslist.RowCount - 1; rw++) 
                {
                    if (int.Parse(transactionslist.Rows[rw].Cells["Selected"].Value.ToString()) == 1)
                    {
                        TransactionID = TransactionID + ((TransactionID.Length <= 0) ? "" : ",") + transactionslist.Rows[rw].Cells["TransactionID"].Value.ToString();
                        AmountPaid = AmountPaid + decimal.Parse(transactionslist.Rows[rw].Cells["Amount"].Value.ToString());
                    }
                }
                if (AmountPaid == 0) { MessageBox.Show("Select At Least A Transaction", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Transfer Payment ", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DvSave = SQLCMD.SQLdata($"LS_PaymentFromUpgrade_M 1,'{TransactionID}',{UpgradeAgreementID},{AgreementID}").DefaultView;
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
