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
    public partial class AccountReceivableContract : Form
    {
        public AccountReceivableContract()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        private void AccountReceivableContract_Load(object sender, EventArgs e)
        {
            Btnclear.PerformClick();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            CreationDate1.SetToNullValue();
             CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (GRDHistory.RowCount < 1) { return; }
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim()=="" && PropertyID.Text.Trim()=="" && Contract1.Text.Trim()=="" && Contract1.Text.Trim() == "")
            {
                if (MessageBox.Show("No SalesFloor Specified, Do You Want To continue ?","Owner",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_AccountReceibableContract_R " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text.Trim()) + "," +
                  ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text.Trim() + "'") + "," + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + "," +
                  ((Contract2.Text.Trim() == "") ? "999999999999" : Contract2.Text.Trim()) + ",'" +
                 ((CreationDate2.Text == "") ? "01-01-3000" : CreationDate2.Text.Trim()) + "','"+ ((CreationDate1.Text == "") ? "01-01-1990" : CreationDate1.Text.Trim()) + "'").DefaultView;

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GRDHistory.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void AccountReceivableContract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            General.AgedAccountReceivable comm = new General.AgedAccountReceivable();
            comm.ExportToExcel(DVSearch);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }
    }
}
