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
    public partial class R_ThirdReport : Form
    {
        public R_ThirdReport()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVReport = new DataView();
        private void R_ThirdReport_Load(object sender, EventArgs e)
        {
            
            Companylist.DataSource = SQLCMD.SQLdata("Ls_CompanyPercent_L").DefaultView;
            Companylist.DisplayMember = "CompanyName";
            Companylist.ValueMember = "CompanyPercentID";
            Btnclear.PerformClick();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void R_ThirdReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                /*-------------------------------------------------------------------------------------------*/
                DVReport = SQLCMD.SQLdata("LS_CompanyCommisionReport_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text.Trim() == "") ? "null" : PropertyID.Text) + ",'" +
                    ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "', " + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +
                    ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + "," + ((Companylist.Text == "") ? "null" : Companylist.SelectedValue.ToString()) + "").DefaultView;
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ReportViewer repo = new ReportViewer();
            string path = "Reports\\ThirdReport.rpt";
            repo.reportpath = path;
            repo.Inforeport = DVReport;
            repo.ShowDialog();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = ""; PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            Contractdate1.SetToNullValue(); Contractdate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Focus();
        }
    }
}
