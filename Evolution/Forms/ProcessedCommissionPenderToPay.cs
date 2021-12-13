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
    public partial class ProcessedCommissionPenderToPay :Form
    {
        public ProcessedCommissionPenderToPay()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DV = new DataView();
        DataView DVSave = new DataView();
        DataView DVSearch = new DataView();
        bool _loaded = false;
        private void ProcessedCommissionPenderToPay_Load(object sender, EventArgs e)
        {
            DV = SQLCMD.SQLdata("LS_CompanyProcess_SPL 1").DefaultView;
            ddlType.DataSource = SQLCMD.SQLdata("LS_CompanyProcess_SPL 0").DefaultView;
            ddlType.DisplayMember = "Description";
            ddlType.ValueMember = "TypeID";
            Btnclear.PerformClick();
            _loaded = true;
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            ddlType.SelectedValue = 0;
            ddlCompany.SelectedValue = 0;
            CreationDate1.Text = Convert.ToString( Convert.ToDateTime(General.Globalvariables.Systemdate.ToShortDateString()).AddDays(1 - General.Globalvariables.Systemdate.Day));
            CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            ckbPaid.Checked = false;
            dtpApplyDate.SetToNullValue();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcessedCommissionPenderToPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void ddlType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(_loaded == false) { return; }
            DV.RowFilter = "";
            DV.RowFilter = $"Type={((ddlType.Text == "" || ddlType.SelectedValue == null) ? "0" : ddlType.SelectedValue.ToString())}";
            ddlCompany.DataSource = DV;
            ddlCompany.DisplayMember = "Description";
            ddlCompany.ValueMember = "CompanyNameID";
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"LS_CompanyProcessPenderToPay_SPL {((ddlType.Text == "" || ddlType.SelectedValue == null) ? "null" : ddlType.SelectedValue.ToString())},'{CreationDate1.Text}','{CreationDate2.Text}',"+
            $"{((ddlCompany.Text == "" || ddlCompany.SelectedValue == null) ? "null" : ddlCompany.SelectedValue.ToString())},{((ckbPaid.Checked == true ) ? 1 : 0)}").DefaultView;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GRDHistory.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {   try
            { 
                if (DateTime.Parse(CreationDate1.Text) > DateTime.Parse(CreationDate2.Text)) { MessageBox.Show("Invalid Date Range","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
                bProccess.Text = ((ckbPaid.Checked == true)? "Reverse" : "Apply");
                backgroundWorker2.RunWorkerAsync();
                Wait wwt = new Wait();
                wwt.ShowDialog();
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            try
            {
                if (GRDHistory.RowCount < 1) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (ckbPaid.Checked==false) { if (dtpApplyDate.Text.Trim() == "") { MessageBox.Show("Missing Apply Date", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpApplyDate.Focus(); return; } }
                StringBuilder sqlquery = new StringBuilder();
                for (int row = 0; row <= GRDHistory.RowCount - 1; row++)
                {
                    if (int.Parse(GRDHistory.Rows[row].Cells["Select"].Value.ToString()) == 1)
                    {
                        sqlquery.Append($"exec LS_CompanyProcessPenderToPay_SPM {GRDHistory.Rows[row].Cells["StatusID"].Value.ToString()},{GRDHistory.Rows[row].Cells["ProcessID"].Value.ToString()}," +
                        $"{GRDHistory.Rows[row].Cells["CompanyType"].Value.ToString()},'{((ckbPaid.Checked==false)? dtpApplyDate.Text : "01-01-2000") }',{General.Globalvariables.guserid}" + " ");
                    }
                }
                if (sqlquery.Length <= 0) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Apply", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                //-----------------------------------------------------------
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                bSearch.PerformClick();
                cbCheckAll.Checked = false;
                dtpApplyDate.SetToNullValue();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cbCheckAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (GRDHistory.RowCount < 1) { cbCheckAll.CheckState = CheckState.Unchecked; return; }
            for (int row = 0; row <= GRDHistory.RowCount - 1; row++)
            {
                    GRDHistory.Rows[row].Cells["Select"].Value = ((cbCheckAll.CheckState == CheckState.Checked) ? 1 : 0);
            }
        }

        private void ckbPaid_CheckStateChanged(object sender, EventArgs e)
        {
           
        }
    }
}
