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
    public partial class ArrearsContractCommissionHistory : Form //DevComponents.DotNetBar.Metro.MetroForm //Form
    {
        public ArrearsContractCommissionHistory()
        {
            InitializeComponent();
        }
        int ActionType = 1;
        DataView DV = new DataView();
        DataView DVDetail = new DataView();
        DataView DVSave = new DataView();
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        private void ArrearsContractCommissionHistory_Load(object sender, EventArgs e)
        {
            FillGrids(1);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage1)
            {
                if (GRDTransaction.RowCount < 1) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                try
                {
                    if (MessageBox.Show($"Confirm Undo \n\n Process Code ={GRDTransaction.CurrentRow.Cells["ProcessCode"].Value.ToString()}", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                    DVSave = SQLCMD.SQLdata($"LS_ArrearsContractCommission_SPM 2,0,0,0,0,'',{GRDTransaction.CurrentRow.Cells["ProcessCode"].Value.ToString()},{Globalvariables.guserid}").DefaultView;
                    FillGrids(1);
                    MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else 
            {
                if (GRDTransactionDetail.RowCount < 1) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                try
                {
                    StringBuilder SqlQuery = new StringBuilder();
                    for (int Rw=0; Rw<= GRDTransactionDetail.RowCount -1; Rw++) 
                    {
                        if (int.Parse(GRDTransactionDetail.Rows[Rw].Cells["Select"].Value.ToString()) ==1) 
                        {
                            SqlQuery.Append($"Exec LS_ArrearsContractCommission_SPM 1,{GRDTransactionDetail.Rows[Rw].Cells["ArrearsContractCommissionId"].Value.ToString()},0,0,0,'',0,{Globalvariables.guserid}"+" ");
                        }
                    }
                    /*-----------------------------------------------------*/
                    if (SqlQuery.Length <=0) { MessageBox.Show("Select At Least A Transaction", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (MessageBox.Show("Confirm Undo", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                    DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                    FillGrids(1);
                    radPageView1.SelectedPage = radPageViewPage1;
                    MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bDetail_Click(object sender, EventArgs e)
        {
            if (GRDTransaction.RowCount < 1) { MessageBox.Show("No Transaction In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            FillGrids(2);
            if (radPageView1.SelectedPage == radPageViewPage2) { return;  }
            radPageView1.SelectedPage = radPageViewPage2;
            CkbAll.Visible = true;
            grbCheckall.Visible = true;
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ActionType == 1)
            {
                DV = SQLCMD.SQLdata("LS_ArrearsContractCommission_SPL 1").DefaultView;
            }
            /*----------------------------------------------------*/
            if (ActionType == 2)
            {
                DVDetail = SQLCMD.SQLdata($"LS_ArrearsContractCommission_SPL 2,{GRDTransaction.CurrentRow.Cells["ProcessCode"].Value.ToString()}").DefaultView;
            }
            /*----------------------------------------------------*/
        }
        private void FillGrids(int OptionType) 
        {
            ActionType = OptionType;
            bgwSearch.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActionType == 1)
            {
                GRDTransaction.DataSource = DV;
            }
            /*----------------------------------------------------*/
            if (ActionType == 2)
            {
                GRDTransactionDetail.DataSource = DVDetail;
            }
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name =="Wait");
            frm.Close();
        }

        private void radPageView1_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage2)
            {
                bDetail.PerformClick();
            }
            else { CkbAll.Visible = false; grbCheckall.Visible = false; }
        }

        private void ArrearsContractCommissionHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
        }

        private void GRDTransaction_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            bDetail.PerformClick();
        }

        private void CkbAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (GRDTransactionDetail.RowCount < 1) { return; }
            for (int row=0; row <= GRDTransactionDetail.RowCount -1; row++) 
            {
                GRDTransactionDetail.Rows[row].Cells["Select"].Value = ((CkbAll.CheckState == CheckState.Checked)? 1 : 0);
            }
        }
    }
}
