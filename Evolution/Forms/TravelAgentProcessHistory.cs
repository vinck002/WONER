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
    public partial class TravelAgentProcessHistory : Form
    {
        public TravelAgentProcessHistory()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DV = new DataView();
        DataView DvDetail = new DataView();
        DataView DvSave = new DataView();
        private void TravelAgentProcessHistory_Load(object sender, EventArgs e)
        {

        }
        public void FillGridHistory()
        {
            bgwSearch.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
        }
        private void FillGridDetail()
        {
            bgwDetail.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (txtReference.Text.Trim() =="") { MessageBox.Show("Missing Reference","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); txtReference.Focus(); return; }
            DialogResult = DialogResult.OK;
        }

        private void TravelAgentProcessHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 27) { DialogResult = DialogResult.Cancel; }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DV = SQLCMD.SQLdata("Exec LS_TravelAgentCommission_SPL 1,0").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdHistory.DataSource = DV;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void grdHistory_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(grdHistory.RowCount <= 0) { return; }
            FillGridDetail();
        }

        private void bgwDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            DvDetail = SQLCMD.SQLdata($"Exec LS_TravelAgentCommission_SPL 2,{grdHistory.CurrentRow.Cells["TravelAgentCommissionID"].Value.ToString()}").DefaultView;
        }

        private void bgwDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdCommission.DataSource = DvDetail;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdHistory.RowCount <= 0) { return; }
                string _info = "\n" + grdHistory.CurrentRow.Cells["Description"].Value.ToString() + "\n" + grdHistory.CurrentRow.Cells["CreationDate"].Value.ToString() + "\n" + grdHistory.CurrentRow.Cells["amountPaid"].Value.ToString();
                if (MessageBox.Show("Confirm Undo " + _info, "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DvSave = SQLCMD.SQLdata($"Exec LS_TravelAgentCommission_SPM 2,{grdHistory.CurrentRow.Cells["TravelAgentCommissionID"].Value.ToString()}," +
                    $"@UserID={General.Globalvariables.guserid}").DefaultView;
                FillGridHistory();
                grdCommission.DataSource = DvSave;
                MessageBox.Show("Done","Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                if (grdCommission.RowCount < 1) { return; }
                wwt.Show(); wwt.Refresh();
                General.TravelAgentCommissionExport exportar = new General.TravelAgentCommissionExport();
                exportar.ExportarGridview(grdCommission, 2);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
        /*=============================================================================================*/
    }
}
