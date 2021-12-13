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
using Telerik.WinControls.Data;
namespace Evolution.Forms
{
    public partial class PaymentOld : Form
    {
        public PaymentOld()
        {
            InitializeComponent();
        }
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        DataView DVTranferenceLog = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { Contract1.SelectionStart = 0; Contract1.SelectionLength = Contract1.Text.Length; Contract1.Focus(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void PaymentOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==27) { this.Close(); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim() == "" & PropertyID.Text.Trim() == "" & Contract1.Text.Trim() == "" & Contract2.Text.Trim() == "")
            {
                if(MessageBox.Show("Do You Want To Seach All Contract ?","OWNER",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                DVSearch = SQLCMD.SQLdata("LS_PaymentOld_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text.Trim()) + "," +
                    ((PropertyID.Text.Trim() == "") ? "null" : "'"+PropertyID.Text.Trim()+ "'") + "," + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + "," +
                    ((Contract2.Text.Trim() == "") ? "1" : Contract2.Text.Trim()) + ",'" + ((Contractdate1.Text.Trim() == "") ? "01-01-1990" : Contractdate1.Text.Trim()) + "','" +
                    ((Contractdate2.Text.Trim() == "") ? "11-30-2017" : Contractdate2.Text.Trim()) + "'").DefaultView;
                /*-----------------------------------------------*/
                transactionslist.DataSource = DVSearch;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = ""; PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            Contractdate1.SetToNullValue(); Contractdate2.Text = "11-30-2017";
            SalesfloorID.Focus();
        }

        private void PaymentOld_Load(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue(); Contractdate2.Text = "11-30-2017";
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void bSave_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (transactionslist.Rows.Count < 1) { MessageBox.Show("No Payments In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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
                if (TransactionID =="0") { MessageBox.Show("No Payments Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Transference", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVTranferenceLog = SQLCMD.SQLdata("LS_GenerationPayments_M " + TransferenceID + "," + General.Globalvariables.guserid + "").DefaultView;
                DVSave = SQLCMD.SQLdata("Exec LS_PaymentsSynchronize_M '" + TransactionID + "','" + TransferenceID + "',1").DefaultView;
                bSearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void PaymentOld_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
