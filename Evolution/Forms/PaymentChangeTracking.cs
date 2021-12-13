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
    public partial class PaymentChangeTracking : Form
    {
        public PaymentChangeTracking()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVowner = new DataView();
        DataView DVevo = new DataView();
        DataView DVSave = new DataView();
        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { MemberAgreementNo.SelectionStart = 0; MemberAgreementNo.SelectionLength = MemberAgreementNo.Text.Length; MemberAgreementNo.Focus(); }
        }

        private void MemberAgreementNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Sequence.SelectionStart = 0; Sequence.SelectionLength = Sequence.Text.Length; Sequence.Focus(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Sequence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            MemberAgreementNo.Text = "";
            Sequence.Text = ""; SalesfloorID.Focus();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // wwt.Show(); wwt.Refresh();
                DVowner = SQLCMD.SQLdata("LS_PaymentChangeTracking_L 1, '" + SalesfloorID.Text.Trim() +"-"+ PropertyID.Text.Trim() +"-"+ MemberAgreementNo.Text.Trim()  + "'," +
                ((Sequence.Text.Trim() == "") ? 0 : int.Parse(Sequence.Text.Trim())) + "").DefaultView;
                /*--------------------------------------*/
                DVevo = SQLCMD.SQLdata("LS_PaymentChangeTracking_L 2, '" + SalesfloorID.Text.Trim() + "-" + PropertyID.Text.Trim() + "-" + MemberAgreementNo.Text.Trim() + "'," +
              ((Sequence.Text.Trim() == "") ? 0 : int.Parse(Sequence.Text.Trim())) + "").DefaultView;

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GRD.DataSource = DVowner;
            GRDEvo.DataSource = DVevo;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim() == "") { MessageBox.Show("Missing SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            if (PropertyID.Text.Trim() == "") { MessageBox.Show("Missing Property", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); PropertyID.Focus(); return; }
            if (MemberAgreementNo.Text.Trim() == "") { MessageBox.Show("Missing Agreement Number", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); MemberAgreementNo.Focus(); return; }
            //MemberContractNo = SalesfloorID.Text.Trim() + "-" + PropertyID.Text.Trim() + "-" + MemberAgreementNo.Text.Trim() + ((Sequence.Text.Trim() == "" || int.Parse(Sequence.Text) <= 0) ? "" : "-" + Sequence.Text.Trim());
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void bInactive_Click(object sender, EventArgs e)
        {
            if (GRD.RowCount < 1) { MessageBox.Show("No Payments In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------------*/
            string TransactionID = "0", DTSTransactionID = "0";
            for (int record = 0; record <= GRD.RowCount - 1; record++)
            {
                if (GRD.Rows[record].Cells["Select"].Value.ToString() == "1")
                {
                    TransactionID = TransactionID + "," + GRD.Rows[record].Cells["TransactionID"].Value.ToString();
                    DTSTransactionID = DTSTransactionID + "," + GRD.Rows[record].Cells["DTSTransactionID"].Value.ToString();
                }

            }
            if (TransactionID == "0") { MessageBox.Show("No Payments Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*-------------------------------------------------------------------------------------*/
            try
            {
                if (MessageBox.Show("Confirm Inactive" , "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata("LS_InactivePayments_M 1,'" + TransactionID + "'," + General.Globalvariables.guserid + ",'"+ DTSTransactionID + "'").DefaultView;
                bSearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void bTransfer_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                if (GRDEvo.Rows.Count < 1) { MessageBox.Show("No Transactions In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                string TransferenceID = "", TransactionID = "0";
                TransferenceID = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") + "" + DateTime.Now.ToString("ss");
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                for (int record = 0; record <= GRDEvo.RowCount - 1; record++)
                {
                    if (GRDEvo.Rows[record].Cells["Select"].Value.ToString() == "1")
                    {
                        TransactionID = TransactionID + "," + GRDEvo.Rows[record].Cells["TransactionID"].Value.ToString();
                    }

                }
                if (TransactionID == "0") { MessageBox.Show("No Transactions Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                /*-----------------------------------------------------------------------------------------------------------------------------------------*/
                if (MessageBox.Show("Confirm Transference", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata("LS_GenerationPayments_M " + TransferenceID + "," + General.Globalvariables.guserid + "").DefaultView;
                DVSave = SQLCMD.SQLdata("Exec LS_PaymentsSynchronize_M '" + TransactionID + "','" + TransferenceID + "'").DefaultView;
                bSearch.PerformClick();
                /*---------------------------------------------------*/
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentChangeTracking_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }
    }
}
