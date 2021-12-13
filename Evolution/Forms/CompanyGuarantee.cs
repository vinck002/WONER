using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evolution.General;

namespace Evolution.Forms
{
    public partial class CompanyGuarantee : Form
    {
        public CompanyGuarantee()
        {
            InitializeComponent();
        }
        DataView Dv = new DataView();
        DataView DvSave = new DataView();
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        int CompanyGuaranteeID = 0;
        private void CompanyGarantee_Load(object sender, EventArgs e)
        {
            ddlSalesfloor.DataSource = SQLCMD.SQLdata("sp_l_salesfloor '5','0',''").DefaultView;
            ddlSalesfloor.DisplayMember = "Name";
            ddlSalesfloor.ValueMember = "SalesFloorID";
            _fillGrid();
            Btnclear.PerformClick();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            dtpStartDate.Text =General.Globalvariables.Systemdate.ToShortDateString();
            dtpEndDate.Text = General.Globalvariables.Systemdate.ToShortDateString();
            mebAmount.Text = "";
            mebYear.Text = "";
            ddlSalesfloor.Text = "";
            lblEditMode.Visible = false;
            btnRemove.Enabled = true;
            CompanyGuaranteeID = 0;
            dtpStartDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dtpEndDate.Text) <= DateTime.Parse(dtpStartDate.Text)) { MessageBox.Show("StartDate IS Greater Than EndDate", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpEndDate.Focus(); return; }
            if (ddlSalesfloor.Text == "" || ddlSalesfloor.SelectedValue == null) { MessageBox.Show("Missing Salesfloor", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlSalesfloor.Focus(); return; }
            if (int.Parse(mebYear.Text) <2000 || int.Parse(mebYear.Text) > 9999) { MessageBox.Show("Invalid Year", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); mebYear.Focus(); return; }
            if (decimal.Parse(mebAmount.Text) <= 0) { MessageBox.Show("Invalid Guarantee", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); mebAmount.Focus(); return; }
            if (GRDGarantee.RowCount > 0)
            {
                /*--------------------------------------------------------------------*/
                for (int row = 0; row <= GRDGarantee.RowCount - 1; row++)
                {
                    if (int.Parse(GRDGarantee.Rows[row].Cells["SalesfloorID"].Value.ToString()) == int.Parse(ddlSalesfloor.SelectedValue.ToString()) && 
                        int.Parse(GRDGarantee.Rows[row].Cells["Year"].Value.ToString()) == int.Parse(mebYear.Text) && int.Parse(GRDGarantee.Rows[row].Cells["CompanyGuaranteeID"].Value.ToString()) != CompanyGuaranteeID)
                    {
                        MessageBox.Show($"Salesfloor {ddlSalesfloor.Text} and Year {mebYear.Text} already Exists", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            /*------------------------------------------------------------------------------------------------------*/
            try
            {
                DvSave = SQLCMD.SQLdata($"LS_CompanyGuarantee_SPM {((CompanyGuaranteeID == 0) ? 0 : 1)},{CompanyGuaranteeID},{ddlSalesfloor.SelectedValue}," +
                    $"{mebYear.Text},'{dtpStartDate.Text}','{dtpEndDate.Text}',{decimal.Parse(mebAmount.Text)},1,{Globalvariables.guserid}").DefaultView;
                _fillGrid();
                Btnclear.PerformClick();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecc) { MessageBox.Show(ecc.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*------------------------------------------------------------------------------------------------------*/
        }
        private void _fillGrid() 
        {
            Dv = SQLCMD.SQLdata("LS_CompanyGuarantee_SPL 1").DefaultView;
            GRDGarantee.DataSource = Dv;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GRDGarantee_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(GRDGarantee.RowCount < 1) { return; }
            dtpStartDate.Text = GRDGarantee.CurrentRow.Cells["StartDate"].Value.ToString();
            dtpEndDate.Text = GRDGarantee.CurrentRow.Cells["EndDate"].Value.ToString();
            mebYear.Text = GRDGarantee.CurrentRow.Cells["year"].Value.ToString();
            mebAmount.Text = GRDGarantee.CurrentRow.Cells["Guarantee"].Value.ToString();
            ddlSalesfloor.SelectedValue = int.Parse(GRDGarantee.CurrentRow.Cells["Salesfloorid"].Value.ToString());
            CompanyGuaranteeID = int.Parse(GRDGarantee.CurrentRow.Cells["CompanyGuaranteeID"].Value.ToString());
            lblEditMode.Visible = true;
            btnRemove.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (GRDGarantee.RowCount < 1) { MessageBox.Show("No Garantee In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Conform Remove \n\n" +$"SalesFloor= {GRDGarantee.CurrentRow.Cells["Salesfloor"].Value.ToString()} \n Year= {GRDGarantee.CurrentRow.Cells["Year"].Value.ToString()} ", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No) { return; }
            /*------------------------------------------------------------------------------------------------------*/
            try
            {
                DvSave = SQLCMD.SQLdata($"LS_CompanyGuarantee_SPM 2,{GRDGarantee.CurrentRow.Cells["CompanyGuaranteeID"].Value.ToString()},@UserID={Globalvariables.guserid}").DefaultView;
                _fillGrid();
                Btnclear.PerformClick();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecc) { MessageBox.Show(ecc.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*------------------------------------------------------------------------------------------------------*/
        }
    }
}
