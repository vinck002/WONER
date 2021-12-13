using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace Evolution.General
{
 public static  class CommissionSummaryByCompany
    {
        public static void ExportCommission(DataView DV,string ReportType,string CommisionType)
        {
            /*----------------------------------------------------------------------------------------*/
            if (DV.Count <= 0) { MessageBox.Show("No Record Found", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range["A1:D2"];
            rangoA1.Font.Bold = true;
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango154 = aplicacion.Range[$"B1:B{DV.Count * 3}"];
            rango154.NumberFormat = "@";
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range[$"D3:D{DV.Count * 3}"];
            rango155.NumberFormat = "#,##0.00";
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango124 = aplicacion.Range["A3:D3"];
            rango124.Interior.Color = Color.FromArgb(153,204,235);
            rango124.Borders.LineStyle = BorderStyle.FixedSingle;
            rango124.Font.Bold = true;
            /*---------------------------------------------------------------*/
            hoja_trabajo.Cells[1, 1] = ReportType;
            hoja_trabajo.Cells[2, 1] = CommisionType;
            hoja_trabajo.Cells[3, 1] = "Company Name";
            hoja_trabajo.Cells[3, 2] = "Description";
            hoja_trabajo.Cells[3, 3] = "Transaction Date";
            hoja_trabajo.Cells[3, 4] = "Amount";

            string CompanyName = "";
            /*----------------------------------------------------------------------------*/
            for (int R = 0; R < DV.Count; R++)
            {
                Microsoft.Office.Interop.Excel.Range rango125 = aplicacion.Range["A" + (R + 3 ) + ":D" + (R + 3) + ""];
                rango125.Borders.LineStyle = BorderStyle.FixedSingle;

                hoja_trabajo.Cells[R + 4, 1] = ((CompanyName == DV.Table.Rows[R]["CompanyName"].ToString())? "" : DV.Table.Rows[R]["CompanyName"].ToString()); 
                hoja_trabajo.Cells[R + 4 , 2] = DV.Table.Rows[R]["Description"].ToString() ;
                hoja_trabajo.Cells[R + 4, 3] = DV.Table.Rows[R]["TransactionDate"].ToString();
                hoja_trabajo.Cells[R + 4 , 4] = DV.Table.Rows[R]["Amount"].ToString();

                CompanyName = DV.Table.Rows[R]["CompanyName"].ToString();
            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango126 = aplicacion.Range["A" + (DV.Count + 6 ) + ":D" + (DV.Count + 6 ) + ""];
            rango126.Interior.Color = Color.FromArgb(153, 204, 235);
            rango126.Font.Bold = true;
            hoja_trabajo.Cells[DV.Count + 6 , 1] = "Grand Total";
            hoja_trabajo.Cells[DV.Count + 6 , 4] = $"=Sum(D4:D{DV.Count + 4 })";
        
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = (ReportType+" "+ CommisionType);
            hoja_trabajo.Cells.EntireColumn.AutoFit();
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
