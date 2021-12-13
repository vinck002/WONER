using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Telerik.WinControls.UI;
using System.Drawing;
namespace Evolution.General
{
  public  class TravelAgentCommissionExport
    {
        public void ExportarGridview(RadGridView DV,int Option)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            /*-------------------------------------------------*/
            var xlSheets = libros_trabajo.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet2 = (Microsoft.Office.Interop.Excel.Worksheet) xlSheets.Add(xlSheets[1], Type.Missing);
            hoja_trabajoX = xlNewSheet2;
            /*---------------------------------------------------*/
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) libros_trabajo.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B6", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["D6", "D" + DV.RowCount + 1 + ""];
            rango2.NumberFormat = "m/d/yyyy";
            Microsoft.Office.Interop.Excel.Range rangoX2 = aplicacion.Range["A2", "B2"];
            rangoX2.Font.Bold = true;
            rangoX2.Font.Color = Color.DarkBlue;
            rangoX2.Font.Size = 18;
            int R1 = 0;
            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                { /*-----------------Report Header------------------------------------*/
                    hoja_trabajo.Cells[2, 1] = "";
                    hoja_trabajo.Cells[3, 1] = "TRAVEL AGENT COMMISSION REPORT";
                    hoja_trabajo.Cells[4, 1] = DateTime.Now.ToShortDateString(); 
                    hoja_trabajo.Cells[R + 6, 1] = "MEMBERS NAME";
                    hoja_trabajo.Cells[R + 6, 2] = "CONTRACT No.";
                    hoja_trabajo.Cells[R + 6, 3] = "ROOM TYPE";
                    hoja_trabajo.Cells[R + 6, 4] = "CONTRACTED DATE";
                    hoja_trabajo.Cells[R + 6, 5] = "AMOUNT";
                    hoja_trabajo.Cells[R + 6, 6] = "CLOSING_TAX";
                    hoja_trabajo.Cells[R + 6, 7] = "PERCENT %";
                    hoja_trabajo.Cells[R + 6, 8] = "PAYMENT RECEIVED";
                    hoja_trabajo.Cells[R + 6, 9] = ((Option ==1)? "TO PAY" : "AMOUNT PAID" );
                    hoja_trabajo.Cells[R + 6, 10] = "STATUS";
                    hoja_trabajo.Cells[R + 6, 11] = "TRAVEL AGENT";
                    hoja_trabajo.Cells[R + 6, 12] = "SALESFLOOR";

                }
                else
                {
                    hoja_trabajo.Cells[R + 6, 1] = DV.Rows[R1].Cells["membername"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DV.Rows[R1].Cells["contractno"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 3] = DV.Rows[R1].Cells["Roomtype"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 4] = DV.Rows[R1].Cells["contractdate"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 5] = DV.Rows[R1].Cells["Price"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 6] = DV.Rows[R1].Cells["Closing_Tax"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 7] = DV.Rows[R1].Cells["Percentage"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 8] = DV.Rows[R1].Cells["paymentmade"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 9] = ((Option == 1) ? DV.Rows[R1].Cells["toPay"].Value.ToString() : DV.Rows[R1].Cells["AmountPaid"].Value.ToString());
                    hoja_trabajo.Cells[R + 6, 10] = DV.Rows[R1].Cells["AccountStatus"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 11] = DV.Rows[R1].Cells["AgentName"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 12] = DV.Rows[R1].Cells["SALESFLOOR"].Value.ToString();
                    /*--------------Formato por cada linea----------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["E" + (R + 6) + "", "I" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "L" + (R + 6) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                }

            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6", "L6"];
            rangos.Columns.ColumnWidth = 13.75;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.DarkBlue;
            rangos.Font.Color = Color.White;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (R1 + 8) + "", "L" + (R1 + 8) + ""];
            rango5.Interior.Color = Color.Gainsboro;
            rango5.Font.Bold = true;
            rango5.NumberFormat = "#,##0.00";
            rango5.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 8, 1] = "TOTAL";
            hoja_trabajo.Cells[R1 + 8, 5] = "=sum(E7:E" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 6] = "=sum(F7:F" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 8] = "=sum(H7:H" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 9] = "=sum(I7:I" + (R1 + 7) + ")";

            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Travel Agent Commission";
            hoja_trabajo.Columns.AutoFit();
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*===================================================================================================================================*/
    }
}
