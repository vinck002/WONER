using Evolution.General;
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
    public partial class R_ContractStatistic : Form
    {
        public R_ContractStatistic()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DV = new DataView();
        DataView DVSearch = new DataView();
        DataView DVCompany = new DataView();
        string SalesfloorID = "", CompanyID = "", SubCompanyID="";
        private void R_ContractStatistic_Load(object sender, EventArgs e)
        {
            GRDSalesfloor.DataSource = SQLCMD.SQLdata("LS_CompanyProcess_SPL 2").DefaultView;
            DVCompany = SQLCMD.SQLdata("LS_CompanyProcess_SPL 0").DefaultView;
            DV = SQLCMD.SQLdata("LS_CompanyProcess_SPL 3").DefaultView;
            GRDType.DataSource = DVCompany;
            Btnclear.PerformClick();
        }

        private void R_ContractStatistic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            CreationDate1.Text = General.Globalvariables.Systemdate.ToShortDateString();
            CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            cbCheckAll.Checked = false;
            ckbSalesfloor.Checked = false;
            ckbsummary.Checked = true;
            rdbProcess.IsChecked = true;
            rdbMonthly.IsChecked = true;
            CreationDate1.Focus();
            DV.RowFilter = "Type in(0)";
            GRDSubCompany.DataSource = DV;
            if (GRDType.RowCount > 0)
            {
                for (int R = 0; R <= GRDType.RowCount - 1; R++)
                {
                    GRDType.Rows[R].Cells["Select"].Value = 0;
                }
            }
            if (GRDSalesfloor.RowCount < 1) { return; }
            for (int R = 0; R <= GRDSalesfloor.RowCount - 1; R++)
            {
                GRDSalesfloor.Rows[R].Cells["Select"].Value = 0;
            }
        }

        private void cbCheckAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (GRDSubCompany.RowCount < 1) { cbCheckAll.CheckState = CheckState.Unchecked; return; }
            for (int row = 0; row <= GRDSubCompany.RowCount - 1; row++)
            {
                GRDSubCompany.Rows[row].Cells["Select"].Value = ((cbCheckAll.CheckState == CheckState.Checked) ? 1 : 0);
            }
        }

        private void ckbSalesfloor_CheckStateChanged(object sender, EventArgs e)
        {
            if (GRDSalesfloor.RowCount < 1) { ckbSalesfloor.CheckState = CheckState.Unchecked; return; }
            for (int row = 0; row <= GRDSalesfloor.RowCount - 1; row++)
            {
                GRDSalesfloor.Rows[row].Cells["Select"].Value = ((ckbSalesfloor.CheckState == CheckState.Checked) ? 1 : 0);
            }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"LS_ContractStatistic_SPR 1,'{SalesfloorID}','{CreationDate1.Text}','{CreationDate2.Text}','{CompanyID}'," +
                $"{((rdbPaid.IsChecked==true)? 1 : 0)},{((ckbsummary.Checked == true) ? 1 : 0)},{((rdbMonthly.IsChecked == true) ? 1 : 2)},'{SubCompanyID}'").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContractStatisticExportation expo = new ContractStatisticExportation();
            expo.ExportContractStatistic(DVSearch,DateTime.Parse(CreationDate1.Text), DateTime.Parse(CreationDate2.Text),((rdbMonthly.IsChecked==true)? 1 : 2), DVCompany, CompanyID,
               ((ckbsummary.Checked==true)? 1 : 0) );
             var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "Wait").FirstOrDefault();
            frm.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GRDType_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {   
                if(e.RowIndex < 0) { return; }
                int record = 0;
                foreach (DataRowView row in DVCompany)
                {
                    DVCompany.AllowEdit = true;
                    if (int.Parse(row["TypeID"].ToString()) == int.Parse(GRDType.CurrentRow.Cells["TypeID"].Value.ToString()))
                    {
                        DVCompany[record]["selected"] = ((int.Parse(GRDType.CurrentRow.Cells["Select"].Value.ToString()) == 1) ? 0 : 1);
                    }
                    DVCompany[record].EndEdit();
                    record++;
                }
                GRDType.DataSource = DVCompany;
                CompanySelection();

            }
        }

        private void GRDType_CellClick_1(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex <0) { return; }
                int record = 0;
                foreach (DataRowView row in DVCompany)
                {
                    DVCompany.AllowEdit = true;
                    if (int.Parse(row["TypeID"].ToString()) == int.Parse(GRDType.CurrentRow.Cells["TypeID"].Value.ToString()))
                    {
                        DVCompany[record]["selected"] = ((int.Parse(GRDType.CurrentRow.Cells["Select"].Value.ToString()) == 1) ? 0 : 1);
                    }
                    DVCompany[record].EndEdit();
                    record++;
                }
                GRDType.DataSource = DVCompany;
                CompanySelection();

            }
        }

        private void CompanySelection()
        {
            try
            {
                if (GRDType.RowCount < 1) { return; }
                cbCheckAll.Checked = false;
                string _companyID = "";
                for (int R = 0; R <= GRDType.RowCount - 1; R++)
                {
                    if (int.Parse(GRDType.Rows[R].Cells["Select"].Value.ToString()) == 1)
                    {
                        _companyID = _companyID + ((_companyID.Length <= 0) ? "" : ",") + GRDType.Rows[R].Cells["TypeID"].Value.ToString();
                    }
                }
                DV.RowFilter = "";
                DV.RowFilter = $"Type in({((_companyID.Length <= 0) ? "0" : _companyID)})";
                GRDSubCompany.DataSource = DV;

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(CreationDate1.Text) > DateTime.Parse(CreationDate2.Text)) { MessageBox.Show("Invalid Date Range", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); CreationDate2.Focus(); return; }
                if ((DateTime.Parse(CreationDate2.Text) - DateTime.Parse(CreationDate1.Text)).TotalDays > 735 && rdbMonthly.IsChecked == true) { MessageBox.Show("Header By Month Only Support 24 Months", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); CreationDate2.Focus(); return; }
                SalesfloorID = ""; CompanyID = ""; SubCompanyID = "";
                if (GRDSalesfloor.RowCount > 0)
                {
                    for (int row = 0; row <= GRDSalesfloor.RowCount - 1; row++)
                    {
                        if (int.Parse(GRDSalesfloor.Rows[row].Cells["Select"].Value.ToString()) == 1)
                        {
                            SalesfloorID = SalesfloorID + ((SalesfloorID.Length <= 0) ? "" : ",") + GRDSalesfloor.Rows[row].Cells["SalesfloorID"].Value.ToString();
                        }
                    }
                }
                //-----------------------------------------------------------------------------------
                if (GRDType.RowCount > 0)
                {
                    for (int row = 0; row <= GRDType.RowCount - 1; row++)
                    {
                        if (int.Parse(GRDType.Rows[row].Cells["Select"].Value.ToString()) == 1)
                        {
                            CompanyID = CompanyID + ((CompanyID.Length <= 0) ? "" : ",") + GRDType.Rows[row].Cells["TypeID"].Value.ToString();
                        }
                    }
                }
                //-----------------------------------------------------------------------------------
                if (GRDSubCompany.RowCount > 0)
                {
                    for (int row = 0; row <= GRDSubCompany.RowCount - 1; row++)
                    {
                        if (int.Parse(GRDSubCompany.Rows[row].Cells["Select"].Value.ToString()) == 1 &&
                            (int.Parse(GRDSubCompany.Rows[row].Cells["TypeID"].Value.ToString()) == 2 || int.Parse(GRDSubCompany.Rows[row].Cells["TypeID"].Value.ToString()) == 3) )
                        {
                            SubCompanyID = SubCompanyID + ((SubCompanyID.Length <= 0) ? "" : ",") + GRDSubCompany.Rows[row].Cells["CompanyNameID"].Value.ToString();
                        }
                    }
                }
                //-----------------------------------------------------------------------------------
                bgwSearch.RunWorkerAsync();
                Wait wwt = new Wait();
                wwt.ShowDialog();
                //-----------------------------------------------------------------------------------
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
