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
    public partial class OutOfPenderHistory : Form
    {
        public OutOfPenderHistory()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSearch1 = new DataView();
        DataView DVSave = new DataView();
        private void OutOfPenderHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OutOfPenderHistory_Load(object sender, EventArgs e)
        {
            FillGrid();
            Btnclear.PerformClick();
        }
        private void FillGrid()
        {
            DVSearch1 = SQLCMD.SQLdata("LS_OutOfPenderCommisionHistory_L 0,0").DefaultView;
            TransactionList.DataSource = DVSearch1;
        }
        private void FillGridDetails()
        {
            if (TransactionList.RowCount < 1) { TransactionDetailList.DataSource = null; return; }
            DVSearch = SQLCMD.SQLdata("LS_OutOfPenderCommisionHistory_L 1," + TransactionList.CurrentRow.Cells["OutOfPenderCommisionID"].Value.ToString() + "").DefaultView;
            TransactionDetailList.DataSource = DVSearch;
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            if (TransactionList.RowCount < 1) { MessageBox.Show("No Transactions", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            String Reference = Microsoft.VisualBasic.Interaction.InputBox("Type a Reference", "Owner", "");
            if (Reference.Trim() == "") { MessageBox.Show("Missing Reference", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            try
            {
                wwt.Show(); wwt.Refresh();
                DVSave = SQLCMD.SQLdata("LS_OutOfPenderCommision_M 1," + TransactionList.CurrentRow.Cells["OutOfPenderCommisionID"].Value.ToString() + ",0," +
                   General.Globalvariables.guserid + ",'" + Reference + "'").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            DVSearch1.RowFilter = "CreationDate >='" + ((Contractdate1.Text == "") ? "01/01/1990" : DateTime.Parse(Contractdate1.Text).ToShortDateString()) + "' and CreationDate <='" +
               ((Contractdate2.Text == "") ? "01/01/3000" : DateTime.Parse(Contractdate2.Text).ToShortDateString()) + "'";

            //DVSearch1.RowFilter = "CreationDate >= '07/05/2018'";
            TransactionList.DataSource = DVSearch1;
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPage1;
        }

        private void radPageView1_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage2)
            { //overviewToolStripMenuItem.PerformClick();
                if (TransactionList.RowCount < 1) { return; }
                FillGridDetails();
            }
        }

        private void TransactionList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPage2;
            FillGridDetails();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (TransactionList.RowCount < 1) { return; }
             Wait wwt = new Wait();
            try
            {
                 wwt.Show(); wwt.Refresh();
                DVSearch = SQLCMD.SQLdata("LS_OutOfPenderCommisionHistory_L 2," + TransactionList.CurrentRow.Cells["OutOfPenderCommisionID"].Value.ToString() + "").DefaultView;
                if (DVSearch.Count < 1) { MessageBox.Show("No Record Found","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information); return; }
                General.ExportOutOfPender exportar = new General.ExportOutOfPender();
                exportar.ExportToExcel(DVSearch);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
