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
    public partial class CommissionSummaryByCompany :Form
    {
        public CommissionSummaryByCompany()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DV = new DataView();
        DataView DvType = new DataView();
        DataView DVSearch = new DataView();
        string TypeID = "", CompanyID = "";
        private void CommissionSummaryByCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void CommissionSummaryByCompany_Load(object sender, EventArgs e)
        {
            DV = SQLCMD.SQLdata("LS_CompanyProcess_SPL 1").DefaultView;
            DvType = SQLCMD.SQLdata("LS_CompanyProcess_SPL 0").DefaultView;
            GRDType.DataSource = DvType;
            Btnclear.PerformClick();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            CreationDate1.Text = Convert.ToString(Convert.ToDateTime(General.Globalvariables.Systemdate.ToShortDateString()).AddDays(1 - General.Globalvariables.Systemdate.Day));
            CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            cbCheckAll.Checked = false;
            ckbsummary.Checked = true;
            rdbProcess.IsChecked = true;
             DV.RowFilter = "Type in(0)";
           GRDCompany.DataSource = DV;
            if (GRDType.RowCount < 1) { return; }
            for (int R = 0; R <= GRDType.RowCount - 1; R++)
            {
                GRDType.Rows[R].Cells["Select"].Value = 0;
            }
        }

        private void GRDType_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
          //  if (e.ColumnIndex == 1){ CompanySelection(); } 
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
                GRDCompany.DataSource = DV;
                
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void cbCheckAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (GRDCompany.RowCount < 1) { cbCheckAll.CheckState = CheckState.Unchecked; return; }
            for (int row = 0; row <= GRDCompany.RowCount - 1; row++)
            {
                GRDCompany.Rows[row].Cells["Select"].Value = ((cbCheckAll.CheckState == CheckState.Checked) ? 1 : 0);
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TypeID = ""; CompanyID = "";
                if (GRDType.RowCount > 0)
                {
                    for (int row = 0; row <= GRDType.RowCount - 1; row++)
                    {
                       if(int.Parse(GRDType.Rows[row].Cells["Select"].Value.ToString()) == 1)
                        {
                            TypeID = TypeID + ((TypeID.Length <= 0) ? "" : ",") + GRDType.Rows[row].Cells["TypeID"].Value.ToString();
                        }
                    }
                }
                //-----------------------------------------------------------------------------------
                if (GRDCompany.RowCount > 0)
                {
                    for (int row = 0; row <= GRDCompany.RowCount - 1; row++)
                    {
                        if (int.Parse(GRDCompany.Rows[row].Cells["Select"].Value.ToString()) == 1)
                        {
                            CompanyID = CompanyID + ((CompanyID.Length <= 0) ? "" : ",") + GRDCompany.Rows[row].Cells["TypeID"].Value.ToString()+"-"+ GRDCompany.Rows[row].Cells["CompanyNameID"].Value.ToString();
                        }
                    }
                }
                //-----------------------------------------------------------------------------------
                bgwSearch.RunWorkerAsync();
                Wait wwt = new Wait();
                wwt.ShowDialog();
                //-----------------------------------------------------------------------------------
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"LS_CommissionSummaryByCompany_SPR '{TypeID}','{CreationDate1.Text}','{CreationDate2.Text}'," +
               $"'{CompanyID}',{((rdbPaid.IsChecked == true) ? 1 : 0)},{((ckbsummary.Checked == true) ? 1 : 0)}").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            General.CommissionSummaryByCompany.ExportCommission(DVSearch, ((ckbsummary.Checked == true) ? "Summarized" : "Detailed"), "Commission " + ((rdbPaid.IsChecked == true) ? "Paid" : "Processed"));
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "Wait").FirstOrDefault();
            frm.Close();
        }
        private void GRDType_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                int record = 0;
                foreach(DataRowView row in DvType) 
                {
                    DvType.AllowEdit = true;
                    if(int.Parse(row["TypeID"].ToString()) == int.Parse(GRDType.CurrentRow.Cells["TypeID"].Value.ToString()))
                    {
                        DvType[record]["selected"] = ((int.Parse(GRDType.CurrentRow.Cells["Select"].Value.ToString()) == 1) ? 0 : 1);
                    }
                    DvType[record].EndEdit();
                    record++;
                }
                GRDType.DataSource = DvType;
                CompanySelection();
               
            }
        }
    }
}
