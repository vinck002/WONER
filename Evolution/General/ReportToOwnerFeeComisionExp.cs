using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Drawing;
using System.Globalization;
using Range = Microsoft.Office.Interop.Excel.Range;
using DataTable = System.Data.DataTable;

namespace Evolution.General
{
    public class ReportToOwnerFeeComisionExp
    {
        public void ExportarGridview(DataTable DATA, string TargetMonth , string OwnerfeeExpired )
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
            Workbook WBook;
            Worksheet hoja_trabajo;
            //aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = /*(Microsoft.Office.Interop.Excel.Worksheet)*/WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Range rango1 = aplicacion.Range["A7", "A" + DATA.Rows.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0;
            
            for (int R = 0; R <= DATA.Rows.Count; R++)
            {
                if (R == 0)
                {
                    /*-----------------------Parametro--------------------------------------*/
                    hoja_trabajo.Cells[R + 1, 1] = "Report";
                    hoja_trabajo.Cells[R + 3, 1] = "Export Date";
                    hoja_trabajo.Cells[R + 4, 1] = "Target Month";
                    hoja_trabajo.Cells[R + 1, 2] = OwnerfeeExpired;
                    var culture = new CultureInfo("en-US");
                    hoja_trabajo.Cells[R + 3, 2] = DateTime.Now.ToString(culture.DateTimeFormat); ;
                    hoja_trabajo.Cells[R + 4, 2] = TargetMonth;

                    /*-----------------------HEADERS----------------------------------------*/
                    hoja_trabajo.Cells[R + 6, 1] = "Contract #";
                    hoja_trabajo.Cells[R + 6, 2] = "OC Name";
                    hoja_trabajo.Cells[R + 6, 3] = "US$ / Week";
                    hoja_trabajo.Cells[R + 6, 4] = "Week Period Year";
                    hoja_trabajo.Cells[R + 6, 5] = "4 Week";
                    hoja_trabajo.Cells[R + 6, 6] = "Contract Status";

                    Range rngreportName = aplicacion.Range["B1", "D1"];
                    rngreportName.MergeCells = true;
                    rngreportName.Font.Bold = true;
                    rngreportName.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                }
                else
                {
                  
                    hoja_trabajo.Cells[R + 6, 1] = DATA.Rows[R1]["AgreementNumber"].ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DATA.Rows[R1]["MemberName"].ToString();
                    hoja_trabajo.Cells[R + 6, 3] = DATA.Rows[R1]["Us_Per_Week"].ToString();
                    hoja_trabajo.Cells[R + 6, 4] = DATA.Rows[R1]["Week_period_Year"].ToString();
                    hoja_trabajo.Cells[R + 6, 5] = DATA.Rows[R1]["FourWeek"].ToString();
                    hoja_trabajo.Cells[R + 6, 6] = DATA.Rows[R1]["ContractStatus"].ToString();
                    

                    R1 += 1;
                }
            }
            /*--------------------------Formato------------------------------------------------------------*/
            Range InfoRng = aplicacion.Range["A1", "C6"];
            InfoRng.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            Range rango3 = aplicacion.Range["C7" , "C" + (R1 + 6) + ""];
            rango3.NumberFormat = "#,##0.00";

            Range rango4 = aplicacion.Range["E7", "E" + (R1 + 6) + ""];
            rango4.NumberFormat = "#,##0.00";


            Range rangos = aplicacion.Range["A6", "F6"];
            rangos.Columns.ColumnWidth = 12;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.LightGoldenrodYellow;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            
            rangos.Font.Bold = true;

            Range rangosfit = aplicacion.Range["A1", $"F{R1 + 5}"];
            rangosfit.Columns.AutoFit();
            

            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            //hoja_trabajo.Cells[R1 + 8, 1] = "TOTAL";
            //hoja_trabajo.Cells[R1 + 8, 4] = "=sum(D7:D" + (R1 + 7) + ")";

            /*-------------------------------------------------------------------------------------*/


            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
