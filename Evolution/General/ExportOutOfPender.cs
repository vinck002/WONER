using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
namespace Evolution.General
{
  public  class ExportOutOfPender
    {
        public void ExportToExcel(DataView DV)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoy2 = aplicacion.Range["D2"];
            rangoy2.Font.Bold = true;
            rangoy2.Font.Size = 20;
            Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range["A1"];
            rangoA1.Columns.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range rangoAK = aplicacion.Range["A5", "J5"];
            rangoAK.Interior.Color = Color.DarkBlue;
            rangoAK.Font.Bold = true; rangoAK.Font.Color = Color.White;
            rangoAK.Rows.RowHeight = 30;
            rangoAK.WrapText = true;
            rangoAK.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoAK.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK.VerticalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rangoBK1 = aplicacion.Range["B1", "J1"];
            rangoBK1.Columns.ColumnWidth = 15;
            rangoBK1.WrapText = true;
            rangoBK1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A6", "A" + DV.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["A1"]; /*formato al nombre de la compañia*/
            rango155.Font.Bold = true;
            rango155.Font.Size = 16;
            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0;

            for (int R = 0; R <= DV.Count; R++)
            {
                if (R == 0)
                {
                    hoja_trabajo.Cells[R + 2, 4] = "OUT OF PENDER % COMMISION";
                    hoja_trabajo.Cells[R + 5, 1] = "Agreement Number";
                    hoja_trabajo.Cells[R + 5, 2] = "Contract Date";
                    hoja_trabajo.Cells[R + 5, 3] = "Price";
                    hoja_trabajo.Cells[R + 5, 4] = "Closing Cost";
                    hoja_trabajo.Cells[R + 5, 5] = "Tax";
                    hoja_trabajo.Cells[R + 5, 6] = "Status";
                    hoja_trabajo.Cells[R + 5, 7] = "Commision To Pay";
                    hoja_trabajo.Cells[R + 5, 8] = "Out Of Pender Amount";
                    hoja_trabajo.Cells[R + 5, 9] = "Out Of Pender Date";
                    hoja_trabajo.Cells[R + 5, 10] = "Amount Paid";
                    /*--------------------------------------------------------------------------------------------*/
                }
                else
                {
                    /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 1] = DV.Table.Rows[R1]["agreementnumber"].ToString();
                    hoja_trabajo.Cells[R + 5, 2] = DV.Table.Rows[R1]["contractdate"].ToString();
                    hoja_trabajo.Cells[R + 5, 3] = DV.Table.Rows[R1]["price"].ToString();
                    hoja_trabajo.Cells[R + 5, 4] = DV.Table.Rows[R1]["closingcost"].ToString();
                    hoja_trabajo.Cells[R + 5, 5] = DV.Table.Rows[R1]["tax"].ToString();

                    hoja_trabajo.Cells[R + 5, 6] =  DV.Table.Rows[R1]["Status"].ToString();
                    hoja_trabajo.Cells[R + 5, 7] =  DV.Table.Rows[R1]["CommisionToPay"].ToString();
                    hoja_trabajo.Cells[R + 5, 8] =  DV.Table.Rows[R1]["OutPenderAmount"].ToString();
                    hoja_trabajo.Cells[R + 5, 9] = DV.Table.Rows[R1]["OutPenderDate"].ToString();
                    hoja_trabajo.Cells[R + 5, 10] = DV.Table.Rows[R1]["AmountPaid"].ToString();

                    /*--------------Formato por cada linea----------------------------------------------------*/

                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 5) + "", "J" + (R + 5) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    rango4.Rows.RowHeight = 13.5;
                    rango4.Interior.Color = Color.GhostWhite;
                    rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    /*----------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango43 = aplicacion.Range["C" + (R + 5) + "", "E" + (R + 5) + ""];
                    rango43.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["G" + (R + 5) + "", "H" + (R + 5) + ""];
                    rango44.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango445 = aplicacion.Range["J" + (R + 5) + ""];
                    rango445.NumberFormat = "#,##0.00";
                    /*--------------------------------------------*/
                    R1 += 1;
                }

            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAK1 = aplicacion.Range["A" + (R1 + 7) + "", "J" + (R1 + 7) + ""];
            rangoAK1.NumberFormat = "#,##0.00";
            rangoAK1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK1.Interior.Color = Color.LightCyan;
            rangoAK1.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangoAK1.Font.Bold = true;
            /*--------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[(R1 * 1) + 7, 1] = "Total";
            hoja_trabajo.Cells[(R1 * 1) + 7, 3] = "=Sum(C6:C" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 4] = "=Sum(D6:D" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 5] = "=Sum(E6:E" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 7] = "=Sum(G6:G" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 8] = "=Sum(H6:H" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 10] = "=Sum(J6:J" + (R1 + 6) + "";

            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["A" + (R1 + 7) + ""];
            rango3.Font.Bold = true;

            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango31 = aplicacion.Range["F5" + (R1 + 7) + ""];
            rango31.Font.Bold = true;
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
