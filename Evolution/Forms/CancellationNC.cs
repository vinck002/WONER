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
    public partial class CancellationNC : Form
    {
        public CancellationNC()
        {
            InitializeComponent();
        }
        DataView DVReport = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void CancellationNC_Load(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancellationNC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                DVReport = SQLCMD.SQLdata("LS_CancellationNC_R " + ((SalesfloorID.Text.Trim() == "") ? "Null" : SalesfloorID.Text.Trim()) + "," +
                    ((PropertyID.Text.Trim() == "") ? "Null" : "'" + PropertyID.Text.Trim() + "'") + "," +
                    ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + "," +
                    ((Contract2.Text.Trim() == "") ? "99999999999" : Contract2.Text.Trim()) + ",'" +
                     ((Contractdate1.Text.Trim() == "") ? "01-01-1990" : Contractdate1.Text.Trim()) + "','" +
                    ((Contractdate2.Text.Trim() == "") ? "01-01-3000" : Contractdate2.Text.Trim()) + "'").DefaultView;
                /*----------------------------------------------------------------------------------------------------*/
                // if(DVReport.Count < 1) { MessageBox.Show("No Record Found","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information); }
                ReportViewer repo = new ReportViewer();
                string path = "";
                path = "Reports\\CancellationNCReport.rpt";
                repo.Inforeport = DVReport;
                repo.reportpath = path;
                repo.Show();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
        /*================================================================================================================================*/
    }
}
