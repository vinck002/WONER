using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Evolution.General
{
  public  class OpenExcelFile
    {
        OleDbConnection conn;
        OleDbDataAdapter da;
        DataTable dt;
      public  DataView DV = new DataView();
        public void OpenExcelData(string sheetname)
        {
            string Pathfile = "";
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files (*.xlsx)|*.xls";
            openfile1.Title = "Select An Excel File";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false) { Pathfile = openfile1.FileName; }
            }
            else { return; }
            /*------------------------- muestra los datos-----------------------------------------------*/
            conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; data source=" + Pathfile + ";  Extended Properties= Excel 8.0;");/*xml;HDR=yes*/

             da = new OleDbDataAdapter("select type,date,num,name,memo,amount,code,[Codigo DTS/Owner],[X (cargar con cotejo en Owner)] from [" + sheetname+"$]",conn);
            dt = new DataTable();
            da.Fill(dt);
            DV = dt.DefaultView;
        }
        /*----------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void OpenExcelToThird()
        {
           
            string Pathfile = "";
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files (*.xlsx)|*.xls";
            openfile1.Title = "Select An Excel File";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false) { Pathfile = openfile1.FileName; }
            }
            else { return; }
            /*------------------------- muestra los datos-----------------------------------------------*/
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
                DV.AllowNew = true;
               
                if (hoja_trabajo.Columns.Rows.Cells[record, 1].Text == "") { break; }
            }
            aplicacion.DisplayAlerts = false;
            libros_trabajo.Close();
            aplicacion.Quit();
            MessageBox.Show("Done","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }
        /*========================================================================================================================================================*/
    }
}