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
    public partial class R_WeeklyReport : Form
    {
        public R_WeeklyReport()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVReport = new DataView();
        private void R_WeeklyReport_Load(object sender, EventArgs e)
        {
          
            Paymentmethod.DataSource = SQLCMD.SQLdata("SP_L_paymenttype 1,0,null").DefaultView;
            Paymentmethod.DisplayMember = "Description";
            Paymentmethod.ValueMember = "ID";
            Btnclear.PerformClick();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            CreationDate1.Text = DateTime.Now.ToShortDateString();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
            Paymentmethod.Text = "";
            PropertyID.Text = ""; rdbProcess.IsChecked = true;
            SalesfloorID.Focus();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();
           
        }

        private void R_WeeklyReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13) { SendKeys.Send("{Tab}"); }
            if (e.KeyChar == 27) { this.Close(); }
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2)
            {
                PropertyID.SelectionStart = 0;
                PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus();
            }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2)
            {
                bSearch.Focus();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVReport = SQLCMD.SQLdata("LS_WeeklyPayment_R " + ((ckbExportExcel.Checked == true) ? 2 : 1) + ","+((SalesfloorID.Text.Trim()=="")? "Null" : SalesfloorID.Text.Trim())+","+
                 ((PropertyID.Text.Trim()=="")?"Null" : "'"+PropertyID.Text.Trim()+"'")+","+ ((Paymentmethod.Text == "") ? "Null" : Paymentmethod.SelectedValue.ToString()) + ",'"+
                 ((CreationDate1.Text =="")?"01-01-1990" : CreationDate1.Text) +"','"+ ((CreationDate2.Text == "") ? "01-01-1990" : CreationDate2.Text) + "',"+
                  ((rdbProcess.IsChecked == true) ? 0 : 1) + "").DefaultView;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ckbExportExcel.Checked ==false)
            {
                ReportViewer repo = new ReportViewer();
                string path = "Reports\\WeeklyReport.rpt";
                repo.reportpath = path;
                repo.Inforeport = DVReport;
                repo.ShowDialog();
            }
            else
            {
                General.WeeklyReportPropertySummary.ExportarSummary(DVReport);
            }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name=="Wait");
            frm.Close();
        }

        private void ckbExportExcel_CheckStateChanged(object sender, EventArgs e)
        {
            rdbPaid.Visible = ((ckbExportExcel.CheckState == CheckState.Checked)? true : false);
            rdbProcess.Visible = ((ckbExportExcel.CheckState == CheckState.Checked) ? true : false);
        }
    }
}
