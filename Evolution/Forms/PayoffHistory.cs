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
    public partial class PayoffHistory : Form
    {
        public PayoffHistory()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSearch1 = new DataView();
        DataView DVSave = new DataView();
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void PayoffHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void PayoffHistory_Load(object sender, EventArgs e)
        {
            FillGrid();
            Btnclear.PerformClick();
        }
        private void FillGrid()
        {
            DVSearch1 = SQLCMD.SQLdata("ls_payoffcommisionhistory_L 0").DefaultView;
            TransactionList.DataSource = DVSearch1;
        }
        private void PayoffHistory_Activated(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
        }

        private void TransactionList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPage2;
            FillGridDetails();
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
        private void FillGridDetails()
        {   if(TransactionList.RowCount < 1) { TransactionDetailList.DataSource = null; return; }
            DVSearch = SQLCMD.SQLdata("ls_payoffcommisionhistory_L 1,"+TransactionList.CurrentRow.Cells["PayoffCommisionHistoryID"].Value.ToString()+"").DefaultView;
            TransactionDetailList.DataSource = DVSearch;
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            if (TransactionList.RowCount < 1) { MessageBox.Show("No Transactions", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            String Reference = Microsoft.VisualBasic.Interaction.InputBox("Type a Reference","Owner","");
            if(Reference.Trim() == "") { MessageBox.Show("Missing Reference", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
            try
            {
                wwt.Show(); wwt.Refresh();
                DVSave = SQLCMD.SQLdata("LS_PayoffCommisionHistory_M 1,"+TransactionList.CurrentRow.Cells["PayoffCommisionHistoryID"].Value.ToString()+",0,0,"+
                   General.Globalvariables.guserid +",'"+Reference+"'").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
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
            TransactionList.DataSource = DVSearch1;
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
           if(TransactionList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                FillGridDetails();
                if (DVSearch.Count < 1) { return; }
                General.ExportPayOff exportar = new General.ExportPayOff();
                exportar.ExportToExcel(DVSearch,1);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
