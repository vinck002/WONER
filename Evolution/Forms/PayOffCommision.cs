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
    public partial class PayOffCommision : Form
    {
        public PayOffCommision()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void bSearch_Click(object sender, EventArgs e)
        {
            if (CkbYear.Checked==true && ( int.Parse(MebYear.Text) < 1000 || int.Parse(MebYear.Text) > 9999 )) { MessageBox.Show("Invalid Year Number","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); MebYear.Focus(); return; }
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void FillGrid()
        {
            Found.Text = DVSearch.Count.ToString();
            ContractList.DataSource = DVSearch;
            if(DVSearch.Count < 1) { return; }
            SumTotalPercent();
            /*---------------------------------------------------------------------------------------------------------------*/

        }
        private void SumTotalPercent()
        {
            decimal Percent1 = 0, Percent2 = 0;
            //for (int record = 0; record <= ContractList.RowCount - 1; record++)
            //{
            //    Percent1 = Percent1 + decimal.Parse(ContractList.Rows[record].Cells["Percent1"].Value.ToString());
            //    Percent2 = Percent2 + decimal.Parse(ContractList.Rows[record].Cells["Percent2"].Value.ToString());
            //}
            foreach (DataRowView fila in DVSearch)
            {
                if (fila["Selected"].ToString() == "1")
                {
                    Percent1 = Percent1 + decimal.Parse(fila["Percent_1"].ToString());
                    Percent2 = Percent2 + decimal.Parse(fila["Percent_2"].ToString());
                }
            }
            TotalPercent1.Text = Percent1.ToString("#,##0.00");
            TotalPercent2.Text = Percent2.ToString("#,##0.00");
            /*---------------------------------------------------------------------------------------------------------------*/
        }
        private void PayOffCommision_Load(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
           // radDateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"); 
            SalesfloorID.Focus();
            General.GlobalAccess aceso = new General.GlobalAccess();
            aceso.groubox(grbButtons);
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PayOffCommision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); } 
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text; 
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if(SalesfloorID.Text.Trim().Length >= 2) { PropertyID.Focus(); PropertyID.SelectAll(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.Text.Trim().Length >= 2) { Contract1.Focus(); Contract1.SelectAll(); }
        }
        private void bProccess_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(TotalPercent1.Text) + decimal.Parse(TotalPercent2.Text) == 0) { MessageBox.Show("Nothing To Pay", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (ChkFirstPercent.CheckState == CheckState.Unchecked & ChkSecondPercent.CheckState == CheckState.Unchecked) {MessageBox.Show("Select At Least A Percent To Pay", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);return;}
            //Wait wwt = new Wait();
            try
            {
               // wwt.Show(); wwt.Refresh();
                StringBuilder SqlQuery = new StringBuilder();
                SqlQuery.Append("Declare @PayoffCommisionHistoryID1 bigint ");
                SqlQuery.Append("Exec LS_PayoffCommisionHistory_M 0,0," + ((ChkFirstPercent.CheckState == CheckState.Unchecked) ? 0 : decimal.Parse(TotalPercent1.Text)) + ", " +
                    ((ChkSecondPercent.CheckState == CheckState.Unchecked) ? 0 : decimal.Parse(TotalPercent2.Text)) + "," + General.Globalvariables.guserid + ",null,@PayoffCommisionHistoryID1 output" + " ");
                foreach (DataRowView fila in DVSearch)
                {
                    
                    if (int.Parse(fila["Selected"].ToString()) == 1)
                    {
                        
                        SqlQuery.Append("Exec LS_PayoffCommisionHistoryDetail_M 0," + fila["AgreementID"] + "," +
                            ((ChkFirstPercent.CheckState == CheckState.Unchecked) ? 0 : decimal.Parse(fila["Percent_1"].ToString())) + ", " +
                           ((ChkSecondPercent.CheckState == CheckState.Unchecked) ? 0 : decimal.Parse(fila["Percent_2"].ToString())) + ",@PayoffCommisionHistoryID1," +
                           General.Globalvariables.guserid + "" + " ");
                    }
                }
                
                if (MessageBox.Show("Confirm Process", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                bSearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           // finally { wwt.Close(); }
        }

        private void ContractList_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "Select")
            {
                e.CellElement.DrawFill = true;
                 e.CellElement.BackColor = Color.White;
                  e.CellElement.NumberOfColors = 1;
            }
            if (e.CellElement.ColumnInfo.Name == "Percent1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.LightCyan;
                e.CellElement.NumberOfColors = 1;
            }
            if (e.CellElement.ColumnInfo.Name == "Percent2")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.LightYellow;
                e.CellElement.NumberOfColors = 1;
            }
            /*-------Inactivar color para las demas columnas----*/
            if (e.CellElement.ColumnInfo.Name == "ContractNo") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "Price") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "ClosingCost") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "Tax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "ContractDate") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "PayoffAmount") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "Status") { e.CellElement.DrawFill = false; }
        }

        private void ContractList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
        }

        private void ContractList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            { 
                SumTotalPercent();

            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            PayoffHistory ph = new PayoffHistory();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(PayoffHistory))
                {
                    frm.BringToFront();

                    return;
                }

            }
            ph.MdiParent = MdiParent;
            ph.Show();
        }

        private void bPrint_Click_1(object sender, EventArgs e)
        {
            //bHidtory.PerformClick();
            if (ContractList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (DVSearch.Count < 1) { return; }
                General.ExportPayOff exportar = new General.ExportPayOff();
                exportar.ExportToExcel(DVSearch,0);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13) { Contract2.Focus(); Contract2.SelectAll(); }
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_PayoffCommision_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text + "'") + ",'" +
                        ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "', " + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +
                        ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + ","+((CkbYear.Checked==true)? MebYear.Text : "3000")+"").DefaultView;
                
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void CkbYear_CheckStateChanged(object sender, EventArgs e)
        {
            MebYear.Enabled = ((CkbYear.CheckState == CheckState.Checked)? true: false);
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
