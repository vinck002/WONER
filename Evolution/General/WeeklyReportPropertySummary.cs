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
 public static  class WeeklyReportPropertySummary
    {
        public static void ExportarSummary(DataView DV)
        {
            /*----------------------------------------------------------------------------------------*/
            if (DV.Count <=0) { MessageBox.Show("No Record Found","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range[$"A1:E{DV.Count + 8}"];
            rangoA1.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoA0 = aplicacion.Range["A2:E2"];
            rangoA0.Font.Bold = true;
            rangoA0.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango154 = aplicacion.Range["B1:B30"];
            rango154.NumberFormat = "@";
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["C2:E30"];
            rango155.NumberFormat = "#,##0.00";
            /*---------------------------------------------------------------*/
            hoja_trabajo.Cells[1, 3] = DV.Table.Rows[0]["DateRange"].ToString();
            hoja_trabajo.Cells[2, 3] = "Sales";
            hoja_trabajo.Cells[2, 4] = "CC + Tax";
            hoja_trabajo.Cells[2, 5] = "Total";

            string CompanyName = DV.Table.Rows[0]["CompanyName"].ToString();
            int Row = 0,Rw=0;
            /*----------------------------------------------------------------------------*/
            for (int R = 0; R < DV.Count; R++)
            {
                if(CompanyName != DV.Table.Rows[R]["CompanyName"].ToString())
                {
                    Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["A" + (R + 3 + Row) + ":D" + (R + 3 + Row) + ""];
                    rango44.Font.Bold = true;
                    Microsoft.Office.Interop.Excel.Range rango125 = aplicacion.Range["E"+(R + 3 + Row) +":E"+(R + 3 + Row) +""];
                    rango125.Interior.Color = Color.FromArgb(146,208,80);
                    hoja_trabajo.Cells[R + 3 + Row, 1] = CompanyName;
                    hoja_trabajo.Cells[R + 3 + Row, 2] = "Total";
                    hoja_trabajo.Cells[R + 3 + Row, 3] = "=Sum(C"+ (Rw + 3) + ":C" + (R + 2 + Row) + "";
                    hoja_trabajo.Cells[R + 3 + Row, 4] = "=Sum(D"+ (Rw + 3) + ":D" + (R + 2 + Row) + "";
                    hoja_trabajo.Cells[R + 3 + Row, 5] = "=Sum(E"+ (Rw + 3) + ":E" + (R + 2 + Row) + "";
                    CompanyName = DV.Table.Rows[R]["CompanyName"].ToString();
                    Row = Row + 3;
                    Rw = R + Row + 2 ;
                }
                hoja_trabajo.Cells[R + 3 + Row, 1] = DV.Table.Rows[R]["PropertyName"].ToString();
                hoja_trabajo.Cells[R + 3 + Row, 2] = DV.Table.Rows[R]["SalesID"].ToString() + "-" + DV.Table.Rows[R]["PropertyID"].ToString();
                hoja_trabajo.Cells[R + 3 + Row, 3] = DV.Table.Rows[R]["SalesSettled"].ToString();
                hoja_trabajo.Cells[R + 3 + Row, 4] = DV.Table.Rows[R]["TaxSettled"].ToString();
                hoja_trabajo.Cells[R + 3 + Row, 5] = DV.Table.Rows[R]["Total"].ToString();

                Microsoft.Office.Interop.Excel.Range rango20 = aplicacion.Range["E" + (R + 3 + Row) + ":E" + (R + 3 + Row) + ""];
                rango20.Interior.Color = Color.FromArgb(226, 239, 218);

            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango55 = aplicacion.Range["A" + (DV.Count + 3 + Row) + ":D" + (DV.Count + 3 + Row) + ""];
            rango55.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango126 = aplicacion.Range["E" + (DV.Count + 3 + Row) + ":E" + (DV.Count + 3 + Row) + ""];
            rango126.Interior.Color = Color.FromArgb(146, 208, 80);
            hoja_trabajo.Cells[DV.Count + 3 + Row, 1] = CompanyName;
            hoja_trabajo.Cells[DV.Count + 3 + Row, 2] = "Total";
            hoja_trabajo.Cells[DV.Count + 3 + Row, 3] = "=Sum(C" + (Rw + 1) + ":C" + (DV.Count + 2 + Row) + "";
            hoja_trabajo.Cells[DV.Count + 3 + Row, 4] = "=Sum(D" + (Rw + 1) + ":D" + (DV.Count + 2 + Row) + "";
            hoja_trabajo.Cells[DV.Count + 3 + Row, 5] = "=Sum(E" + (Rw + 1) + ":E" + (DV.Count + 2 + Row) + "";
            /*--------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango12 = aplicacion.Range["A" + (DV.Count + 8) + ":D" + (DV.Count + 8) + ""];
            rango12.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango127 = aplicacion.Range["E" + (DV.Count + 8) + ":E" + (DV.Count + 8) + ""];
            rango127.Interior.Color = Color.Yellow;
            hoja_trabajo.Cells[DV.Count + 8 , 1] = "Total General";
            hoja_trabajo.Cells[DV.Count + 8, 3] = "=SumIf(B1:B" + (DV.Count + 7) + ",\"TOTAL\"," + "C1:C" + (DV.Count + 7) + ")";
            hoja_trabajo.Cells[DV.Count + 8, 4] = "=SumIf(B1:B" + (DV.Count + 7) + ",\"TOTAL\"," + "D1:D" + (DV.Count + 7) + ")";
            hoja_trabajo.Cells[DV.Count + 8, 5] = "=SumIf(B1:B" + (DV.Count + 7) + ",\"TOTAL\"," + "E1:E" + (DV.Count + 7) + ")";

            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Weekly Report Summary";
            hoja_trabajo.Cells.EntireColumn.AutoFit();
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
