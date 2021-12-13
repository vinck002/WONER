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
    public partial class RealStateFeeGeneration :Form
    {
        public RealStateFeeGeneration()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void RealStateFeeGeneration_Load(object sender, EventArgs e)
        {
            /*--------------------------------------------*/
            ddlProjectName.DataSource = SQLCMD.SQLdata("RealStateProperty_SPL 1").DefaultView;
            ddlProjectName.DisplayMember = "Description";
            ddlProjectName.ValueMember = "RealStatePropertyID";
            ddlFrecuency.DataSource = SQLCMD.SQLdata("RealStateFrecuency_SPL 1").DefaultView;
            ddlFrecuency.DisplayMember = "Description";
            ddlFrecuency.ValueMember = "RealStateFrecuencyID";
            ddlLocation.DataSource = SQLCMD.SQLdata("RealStateLocation_SPL 1").DefaultView;
            ddlLocation.DisplayMember = "Description";
            ddlLocation.ValueMember = "RealStateLocationID";
            ddlUnitType.DataSource = SQLCMD.SQLdata("RoomType_SPL 1").DefaultView;
            ddlUnitType.DisplayMember = "Description";
            ddlUnitType.ValueMember = "RealStateRoomTypeID";
            ddlRoomNo.DataSource = SQLCMD.SQLdata("RoomType_SPL 2").DefaultView;
            ddlRoomNo.DisplayMember = "Description";
            ddlRoomNo.ValueMember = "RealStateroomID";
            /*--------------------------------------------*/
            btnClear.PerformClick();
            dtpEfectiveDate.Text = General.Globalvariables.Systemdate.ToShortDateString();
            dtpEfectiveDate.SetToNullValue();
            General.GlobalAccess acceso = new General.GlobalAccess();
            acceso.groubox(radGroupBox4);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpContractDate1.SetToNullValue();
            dtpContractDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            ddlRoomNo.Text = ""; txtOwner.Text = "";
            ddlFrecuency.Text = ""; ddlLocation.Text = "";
            ddlProjectName.Text = ""; ddlUnitType.Text = "";
            rdbAll.IsChecked = true;
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"RealStateFeeGeneration_SPL 1,{((ddlRoomNo.Text.Trim()=="" || ddlRoomNo.SelectedValue == null)? "null" :  ddlRoomNo.SelectedValue)},"+
            $"{((ddlUnitType.Text.Trim() == "")? "null" : ddlUnitType.SelectedValue)},{((txtOwner.Text.Trim() == "") ? "null" : "'" + txtOwner.Text.Trim().Replace("'", "''") + "'")},"+
            $"{((ddlProjectName.Text.Trim() == "") ? "null" : ddlProjectName.SelectedValue)},{((ddlFrecuency.Text.Trim() == "") ? "null" : ddlFrecuency.SelectedValue)},"+
            $"{((ddlLocation.Text.Trim() == "") ? "null" : ddlLocation.SelectedValue)},'{((dtpContractDate1.Text=="")? "01-01-1990" : dtpContractDate1.Text)}',"+
            $"'{dtpContractDate2.Text}',{((rdbAll.IsChecked==true)? "null" : (rdbPaid.IsChecked==true)? "0" : "1")}").DefaultView;

        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dtpEfectiveDate.SetToNullValue();
            grdOwner.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            txtTotaltobepaid.Text = "0.00"; txtTotalPaid.Text = "0.00"; txtTotalFeeGenerated.Text = "0.00";
            if (DVSearch.Count > 0) { _summaryformating(); }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlProjectName.Text.Trim() !="" && ddlProjectName.SelectedValue == null) { MessageBox.Show("Invalid Project Name","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); ddlProjectName.Focus(); return; }
            if (ddlLocation.Text.Trim() != "" && ddlLocation.SelectedValue == null) { MessageBox.Show("Invalid Location", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlLocation.Focus(); return; }
            if (ddlFrecuency.Text.Trim() != "" && ddlFrecuency.SelectedValue == null) { MessageBox.Show("Invalid Frecuency", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlFrecuency.Focus(); return; }
            if (ddlUnitType.Text.Trim() != "" && ddlUnitType.SelectedValue == null) { MessageBox.Show("Invalid Unit Type", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlUnitType.Focus(); return; }
            Wait wwt = new Wait();
            bgwSearch.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void _summaryformating()
        {
            if(grdOwner.RowCount < 1) { return; }
            decimal _totalpaid = 0, _totalgenerated = 0,_grandtotal=0;
            for (int R1 = 0; R1 <= grdOwner.RowCount - 1; R1++)
            {
                _totalpaid = _totalpaid + decimal.Parse(grdOwner.Rows[R1].Cells["totalpaid"].Value.ToString());
                _totalgenerated = _totalgenerated + decimal.Parse(grdOwner.Rows[R1].Cells["feegenerated"].Value.ToString());
                /*-------------------------------------------------------------*/
                this.grdOwner.Rows[R1].Cells["Select"].Style.CustomizeFill = true;
                this.grdOwner.Rows[R1].Cells["Select"].Style.DrawFill = true;
                this.grdOwner.Rows[R1].Cells["Select"].Style.BackColor = Color.Lime;
                this.grdOwner.Rows[R1].Cells["balancedue"].Style.CustomizeFill = true;
                this.grdOwner.Rows[R1].Cells["balancedue"].Style.DrawFill = true;
                this.grdOwner.Rows[R1].Cells["balancedue"].Style.BackColor = Color.LemonChiffon;
               // this.grdOwner.Rows[R1].Cells["balancedue"].Style.Font.Bold = FontStyle.Bold;
                /*-------------------------------------------------------------*/
                //grdOwner.Rows[R1].Cells["balancedue"].Style.ForeColor = Color.Red;
                grdOwner.Rows[R1].Cells["balancedue"].ReadOnly = ((decimal.Parse(grdOwner.Rows[R1].Cells["ToPay"].Value.ToString()) <= 0 ) ? true : false);
                grdOwner.Rows[R1].Cells["select"].Value = ((grdOwner.Rows[R1].Cells["select"].Value.ToString() == "0") ? "0" : "1");
            }
            txtTotalFeeGenerated.Text = _totalgenerated.ToString("#,##0.00");
            txtTotalPaid.Text = _totalpaid.ToString("#,##0.00");
            _grandtotal = _totalgenerated - _totalpaid;
            txtTotaltobepaid.Text = _grandtotal.ToString("#,##0.00");
        }

        private void grdOwner_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) { _editbalancetopay(); }
        }
        private void _editbalancetopay()
        {
            try
            {
                if (grdOwner.RowCount < 1) { return; }
                String Value = grdOwner.CurrentRow.Cells["ToPay"].Value.ToString();
                //if (decimal.Parse(grdOwner.CurrentRow.Cells["ToPay"].Value.ToString()) <= 0)
                //{
                //    MessageBox.Show("Cannot Change When Balance To Pay is minor or Equal than Zero", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    grdOwner.CurrentRow.Cells["balancedue"].Value = Value;
                //    return;
                //}
                if (decimal.Parse(Value) < decimal.Parse(grdOwner.CurrentRow.Cells["balancedue"].Value.ToString()) || decimal.Parse(grdOwner.CurrentRow.Cells["balancedue"].Value.ToString()) < 0)
                {
                    MessageBox.Show($"Balance Amount Must Be Between 0 and {Value} ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //grdOwner.DataSource = DVSearch;
                    grdOwner.CurrentRow.Cells["balancedue"].Value = Value;
                    return;
                }
                _summaryformating();
            }
            catch (Exception) { MessageBox.Show("Invalid Amount", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void grdOwner_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {

        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdOwner.RowCount < 1) { MessageBox.Show("Nothing To Show","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            RealStatePaymentHistory frm = new RealStatePaymentHistory();
            frm.RealStateRegistryID = long.Parse(grdOwner.CurrentRow.Cells["RealStateRegistryID"].Value.ToString());
            frm.Controls["lblOwner"].Text = grdOwner.CurrentRow.Cells["firstname"].Value.ToString()+" "+grdOwner.CurrentRow.Cells["lastname"].Value.ToString();
            frm.ShowDialog();
        }

        private void grdOwner_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            viewHistoryToolStripMenuItem.PerformClick();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdOwner.RowCount < 1) { return; }
                if (dtpEfectiveDate.Text == "") { MessageBox.Show("Missing Effective Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpEfectiveDate.Focus(); return; }
                if (Convert.ToDateTime(dtpEfectiveDate.Text) > General.Globalvariables.Systemdate)
                {
                    MessageBox.Show($"Effective Date Is Greater Than {General.Globalvariables.Systemdate.ToShortDateString()}", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpEfectiveDate.Focus();
                    return;
                }
                StringBuilder sqlquery = new StringBuilder();
                string ProcessCode = General.Globalvariables.Systemdate.Year.ToString() + General.Globalvariables.Systemdate.Month.ToString() +
                    General.Globalvariables.Systemdate.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
                    General.Globalvariables.guserid.ToString();
                for (int row = 0; row <= grdOwner.RowCount - 1; row++)
                {
                    if (int.Parse(grdOwner.Rows[row].Cells["Select"].Value.ToString()) == 1 && decimal.Parse(grdOwner.Rows[row].Cells["balancedue"].Value.ToString()) != 0)
                    {
                        sqlquery.Append($"exec RealStatePaymentHistory_SPM 0,0,{decimal.Parse(grdOwner.Rows[row].Cells["balancedue"].Value.ToString())}," +
                            $"'{Convert.ToDateTime(dtpEfectiveDate.Text)}',{grdOwner.Rows[row].Cells["RealStateRegistryID"].Value.ToString()},{ProcessCode}," +
                            $"'{grdOwner.Rows[row].Cells["Reference"].Value.ToString().Trim().Replace("'","''")}',{General.Globalvariables.guserid}" + " ");
                    }
                }
                if (sqlquery.Length <= 0) { MessageBox.Show("Nothing To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Process", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                btnSearch.PerformClick();
                MessageBox.Show("Done \n\n Payments Processed", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RealStateFeeGeneration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void processHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealStateProcessHistory frm = new RealStateProcessHistory();
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (grdOwner.RowCount < 1) { return; }
            ReportViewer repo = new ReportViewer();
            string path = "Reports\\RealStateOwnerBalance.rpt";
            repo.reportpath = path;
            repo.Inforeport = DVSearch;
            repo.ShowDialog();
        }

        private void RealStateFeeGeneration_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
        }
        /*=============================================================================================================================*/
    }
}
