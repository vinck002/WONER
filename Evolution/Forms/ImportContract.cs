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
    public partial class ImportContract : Form
    {
        public ImportContract()
        {
            InitializeComponent();
        }
        DataView DVSaveContract = new DataView();
        DataView dvcompany = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void bSave_Click(object sender, EventArgs e)
        {
            if (TransactionsList.RowCount  <1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Companylist.Text == "") { MessageBox.Show("Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Companylist.Focus(); return; }
            /*-----------------------------------------------------------------------------------------*/
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
               
                /*---------------------------------------------------------------*/
                String HistoryID = "0", Query = "";
               
                /*---------------------------------------------------------------*/
                for (int Record = 0; Record <= TransactionsList.RowCount - 1; Record++)
                {
                    
                        
                   Query = Query + " " + "Exec LS_CompanyCommissionReport_M 2,0," + HistoryID + "," + TransactionsList.Rows[Record].Cells["agreementID"].Value.ToString() + ",'" +
                    TransactionsList.Rows[Record].Cells["ContractNo"].Value.ToString() + "'," + TransactionsList.Rows[Record].Cells["PaymentApplied1"].Value.ToString() + "," +
                    TransactionsList.Rows[Record].Cells["MrToApply"].Value.ToString() + "," + TransactionsList.Rows[Record].Cells["InterestToApply"].Value.ToString() + "," +
                    TransactionsList.Rows[Record].Cells["ToPay"].Value.ToString() + "," + TransactionsList.Rows[Record].Cells["Price"].Value.ToString() + "," + General.Globalvariables.guserid + ",''," +
                    Companylist.SelectedValue + ",'" + DateTime.Parse(TransactionsList.Rows[Record].Cells["ContractDate"].Value.ToString()) + "',''";
                    
                }
                /*--------------------------------------------------------------------*/
                if (Query != "") { DVSaveContract = SQLCMD.SQLdata(Query).DefaultView; }
                /*---------------------------------------------------------------*/
                TransactionsList.Rows.Clear();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }

        }

        private void bImport_Click(object sender, EventArgs e)
        {
            /*-------------------------------------------------------------------------------------*/
           
            if (Companylist.Text == "") { MessageBox.Show("Select A Company","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            /*-------------------------------------------------------------------------------------*/
            string Pathfile = "";
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files (*.xlsx)|*.xls";
            openfile1.Title = "Select An Excel File";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false) { Pathfile = openfile1.FileName; }
            }
            else { return; }
            TransactionsList.Rows.Clear();
            /*-------------------------Read Excel File-----------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            aplicacion.Workbooks.Open(openfile1.FileName);
            libros_trabajo = aplicacion.Workbooks.Open(openfile1.FileName);
            hoja_trabajo = libros_trabajo.Worksheets.get_Item(1);
           
            int fila = hoja_trabajo.Rows.Count;
            for (int record = 8; record <= fila; record++)
            {
               
                Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["B" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["C" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["D" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["E" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["F" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango7 = aplicacion.Range["G" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango8 = aplicacion.Range["H" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango9 = aplicacion.Range["I" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango10 = aplicacion.Range["J" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango11 = aplicacion.Range["K" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango12 = aplicacion.Range["L" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango13 = aplicacion.Range["M" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango14 = aplicacion.Range["O" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango15 = aplicacion.Range["R" + record + ""];
                if (rango1.Value == null) { break; }
                TransactionsList.Rows.Add(rango1.Value, rango2.Value, rango3.Value,
                 rango4.Value, rango5.Value, rango6.Value,
                rango7.Value, rango8.Value, rango9.Value,
                 rango10.Value, ((rango11.Value == null) ? "0" : rango11.Value), rango11.Value, rango12.Value,
                 rango13.Value, rango14.Value, rango15.Value, 0, "", "", ((rango7.Value == null) ? "0" : rango7.Value),
                 ((rango9.Value == null) ? "0" : rango9.Value), ((rango14.Value == null) ? "0" : rango14.Value));
                // if(record == 22) { break; }
            }
            aplicacion.DisplayAlerts = false;
            libros_trabajo.Close();
            aplicacion.Quit();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportContract_Load(object sender, EventArgs e)
        {
            dvcompany = SQLCMD.SQLdata("Ls_CompanyPercent_L").DefaultView;
            Companylist.DataSource = dvcompany;
            Companylist.DisplayMember = "CompanyName";
            Companylist.ValueMember = "CompanyPercentID";
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportContract_Activated(object sender, EventArgs e)
        {
            Companylist.Text = "";
        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
