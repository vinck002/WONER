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
    public partial class OutofPender : Form
    {
        public OutofPender()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DVSave = new DataView();
        private void OutofPender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void FillGrid()
        {
            Found.Text = DVSearch.Count.ToString();
            ContractList.DataSource = DVSearch;
            if (DVSearch.Count < 1) { return; }
            SumTotalCommision();
            /*---------------------------------------------------------------------------------------------------------------*/

        }
        private void SumTotalCommision()
        {
            decimal CommisionToPay = 0;
            foreach (DataRowView fila in DVSearch)
            {
                if (fila["Selected"].ToString() == "1")
                {
                    CommisionToPay = CommisionToPay + decimal.Parse(fila["CommisionToPay"].ToString());
                }
            }
            TotalToPay.Text = CommisionToPay.ToString("#,##0.00");
            /*---------------------------------------------------------------------------------------------------------------*/
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

        private void OutofPender_Load(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void ContractList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SumTotalCommision();

            }
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            if(ContractList.RowCount < 1) { return; }
            if(decimal.Parse(TotalToPay.Text) <= 0) { MessageBox.Show("Nothing To Pay","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            StringBuilder Query = new StringBuilder();
            Query.Append("Declare @OutOfPenderCommisionID1 bigint ");
            Query.Append("Exec LS_OutOfPenderCommision_M 0,0," +  decimal.Parse(TotalToPay.Text) + ", " +
              General.Globalvariables.guserid + ",null,@OutOfPenderCommisionID1 output" + " ");
            for (int record=0; record<= ContractList.RowCount -1; record++)
            {
                if (Convert.ToBoolean(ContractList.Rows[record].Cells["Select"].Value) && Convert.ToBoolean(ContractList.Rows[record].Cells["CommisionToPay"].Value))
                {
                    
                    Query.Append("Exec LS_OutOfPenderCommisionDetail_M 0," + ContractList.Rows[record].Cells["AgreementID"].Value.ToString() + "," +
                            decimal.Parse(ContractList.Rows[record].Cells["CommisionToPay"].Value.ToString()) + ",@OutOfPenderCommisionID1," +
                           General.Globalvariables.guserid + "" + " ");
                }
            }
            if (MessageBox.Show("Confirm Process", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            DVSave = SQLCMD.SQLdata(Query.ToString()).DefaultView;
            bSearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void bHidtory_Click(object sender, EventArgs e)
        {
            OutOfPenderHistory outpender = new OutOfPenderHistory();
            outpender.ShowDialog();
        }

        private void ContractList_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "CommisionToPay")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.Red;
                e.CellElement.NumberOfColors = 1;
            }
            if (e.CellElement.ColumnInfo.Name == "AmountPaid")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.Green;
                e.CellElement.NumberOfColors = 1;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            try
            {
                if (DVSearch.Count < 1) { return; }
                General.ExportOutOfPender exportar = new General.ExportOutOfPender();
                exportar.ExportToExcel(DVSearch);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_OutOfPenderCommision_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text + "'") + ",'" +
                        ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "', " + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +
                        ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + ","+((CkbIncludeAll.Checked==true)? 1 : 0)+"").DefaultView;
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
            if (e.KeyChar == 13) { Contract2.Focus(); Contract2.SelectAll(); }
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim().Length >= 2) { PropertyID.Focus(); PropertyID.SelectAll(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.Text.Trim().Length >= 2) { Contract1.Focus(); Contract1.SelectAll(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
