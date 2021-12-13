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
    public partial class R_AnnualSettlementSummary :Form
    {
        public R_AnnualSettlementSummary()
        {
            InitializeComponent();
        }
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        string SalesFloorID = "", GaranteeYear="";
        private void R_AnnualSettlementSummary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void R_AnnualSettlementSummary_Load(object sender, EventArgs e)
        {
            ddlSalesfloor.DataSource = SQLCMD.SQLdata("sp_l_salesfloor '5','0',''").DefaultView;
            ddlSalesfloor.DisplayMember = "Name";
            ddlSalesfloor.ValueMember = "SalesFloorID";
           
            Btnclear.PerformClick();
        }

       

        private void Btnclear_Click(object sender, EventArgs e)
        {
            CreationDate1.Text = General.Globalvariables.Systemdate.ToShortDateString();
            CreationDate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            mebYear.Text = "";
            ddlSalesfloor.Text = "";
            GRDSalesfloor.Rows.Clear();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SalesFloorID = "";
                GaranteeYear = "";
                if (DateTime.Parse(CreationDate1.Text) > DateTime.Parse(CreationDate2.Text)) { MessageBox.Show("Invalid Date Range", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); CreationDate1.Focus(); return; }
                if (GRDSalesfloor.RowCount <= 0) { MessageBox.Show("Add At Least A SalesFloor combination", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                /*--------------------------------------------------------------------*/
                for (int row = 0; row <= GRDSalesfloor.RowCount - 1; row++)
                {
                        SalesFloorID = SalesFloorID + ((SalesFloorID.Length <= 0) ? "" : ",") + GRDSalesfloor.Rows[row].Cells["SalesFloorID"].Value.ToString();
                    GaranteeYear = GaranteeYear + ((GaranteeYear.Length <= 0) ? "" : ",") + GRDSalesfloor.Rows[row].Cells["SalesFloorID"].Value.ToString() + "-" +
                         GRDSalesfloor.Rows[row].Cells["year"].Value.ToString();
                }
                 bgwSearch.RunWorkerAsync();
                 Wait wwt = new Wait();
                 wwt.Show();
              
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*--------------------------------------------------------------------*/
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVSearch = SQLCMD.SQLdata($"LS_AnnualSettlementSummary_SPR 1,'{SalesFloorID}','{CreationDate1.Text}','{CreationDate2.Text}','{GaranteeYear}'," +
                $"{((rdbPaid.IsChecked==true)? 1 : 0)}").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AnnualSettlementSummary.ExportarSummary(DVSearch, DateTime.Parse(CreationDate1.Text), DateTime.Parse(CreationDate2.Text));
            /*------------------------------------------------*/
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "Wait").FirstOrDefault();
            frm.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlSalesfloor.Text =="" || ddlSalesfloor.SelectedValue ==null) { MessageBox.Show("Missing Salesfloor", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlSalesfloor.Focus(); return; }
            if (int.Parse(mebYear.Text) < 2000 || int.Parse(mebYear.Text) > 9999) { MessageBox.Show("Invalid Year", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); mebYear.Focus(); return; }
            if (GRDSalesfloor.RowCount > 0)
            {
                /*--------------------------------------------------------------------*/
                for (int row = 0; row <= GRDSalesfloor.RowCount - 1; row++)
                {
                    if (int.Parse(GRDSalesfloor.Rows[row].Cells["SalesfloorID"].Value.ToString()) == int.Parse(ddlSalesfloor.SelectedValue.ToString()) && int.Parse(GRDSalesfloor.Rows[row].Cells["Year"].Value.ToString()) == int.Parse(mebYear.Text))
                    {
                        MessageBox.Show($"Salesfloor {ddlSalesfloor.Text} and Year {mebYear.Text} already Exists", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                /*--------------------------------------------------------------------*/
            }
            GRDSalesfloor.Rows.Add(ddlSalesfloor.SelectedValue,mebYear.Text,ddlSalesfloor.Text);
            mebYear.Text = "";
            ddlSalesfloor.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (GRDSalesfloor.RowCount < 1) { return; }
            if (MessageBox.Show("Confirm Remove \n"+ GRDSalesfloor.CurrentRow.Cells["Salesfloor"].Value.ToString()+"\n"+ GRDSalesfloor.CurrentRow.Cells["Year"].Value.ToString(),
                "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            GRDSalesfloor.Rows.RemoveAt(GRDSalesfloor.CurrentRow.Index);
        }
    }
}
