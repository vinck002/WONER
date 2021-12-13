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
    public partial class MemberCommisionHistory : Form
    {
        public MemberCommisionHistory()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch1 = new DataView();
        DataView DVSave = new DataView();
        private void MemberCommisionHistory_Load(object sender, EventArgs e)
        {
            Btnclear.PerformClick();
            backgroundWorker2.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
        }
     
        private void MemberCommisionHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27) { this.Close(); }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
                DVSearch1.RowFilter = "CreationDate >='" + ((Contractdate1.Text == "") ? "01/01/1990" : DateTime.Parse(Contractdate1.Text).ToShortDateString()) + "' and CreationDate <='" +
              ((Contractdate2.Text == "") ? "01/01/3000" : DateTime.Parse(Contractdate2.Text).ToShortDateString()) + "'";

            //DVSearch1.RowFilter = "CreationDate >= '07/05/2018'";
            ContractList.DataSource = DVSearch1;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch1 = SQLCMD.SQLdata("LS_MemberPaymentHistory_L").DefaultView;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContractList.DataSource = DVSearch1;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void MemberCommisionHistory_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (DVSearch1.Count < 1) { return; }
                General.ExportMemberCommision exportar = new General.ExportMemberCommision();
                exportar.ExportToExcel(DVSearch1);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            /*-----------------------------------------------------------*/
            string CompanyCommisionReportID = "0";
            for(int record=0; record <=ContractList.RowCount -1; record++)
            {
                if (int.Parse(ContractList.Rows[record].Cells["Select"].Value.ToString()) == 1)
                {
                    CompanyCommisionReportID = CompanyCommisionReportID + "," + ContractList.Rows[record].Cells["CompanyCommissionReportID"].Value.ToString();
                }
            }
            if (CompanyCommisionReportID=="0") { MessageBox.Show("No Transactions Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.No) { return; }
            DVSave = SQLCMD.SQLdata("LS_MemberCommision_M '"+ CompanyCommisionReportID + "',"+General.Globalvariables.guserid+"").DefaultView;
            /*-------------------------------------------------------------*/
            backgroundWorker2.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
            Btnclear.PerformClick();
            MessageBox.Show("Done","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
