using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace Evolution.General
{
   public class ExportMemberCommision
    {
        public void ExportToExcel(DataView DV1)
        {
            //EXPORTED DATETIME
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
            Microsoft.Office.Interop.Excel.Range rangoAK = aplicacion.Range["A5", "L5"];
            rangoAK.Interior.Color = Color.DarkBlue;
            rangoAK.Font.Bold = true; rangoAK.Font.Color = Color.White;
            rangoAK.Rows.RowHeight = 30;
            rangoAK.WrapText = true;
            rangoAK.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoAK.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK.VerticalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rangoBK1 = aplicacion.Range["B1", "L1"];
            rangoBK1.Columns.ColumnWidth = 15;
            rangoBK1.WrapText = true;
            rangoBK1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A6", "A" + DV1.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["A1"]; /*formato al nombre de la compañia*/
            rango155.Font.Bold = true;
            rango155.Font.Size = 16;
            /*-----------------------------------------------------------------------------------------------------*/
                Range rngExportDate = aplicacion.Range["A3", "D3"];
                rngExportDate.Font.Bold = true;
          


            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0,R=0;
                    hoja_trabajo.Cells[R + 2, 4] = "Member % COMMISION";
                    hoja_trabajo.Cells[R + 5, 1] = "Agreement Number";
                    hoja_trabajo.Cells[R + 5, 2] = "Contract Date";
                    hoja_trabajo.Cells[R + 5, 3] = "Price";
                    hoja_trabajo.Cells[R + 5, 4] = "Closing Cost";
                    hoja_trabajo.Cells[R + 5, 5] = "Tax";
                    hoja_trabajo.Cells[R + 5, 6] = "Payment Made";
                    hoja_trabajo.Cells[R + 5, 7] = "Payment %";
                    hoja_trabajo.Cells[R + 5, 8] = "Request Date";
                    hoja_trabajo.Cells[R + 5, 9] = "Commision To Pay";
                    hoja_trabajo.Cells[R + 5, 10] = "Commision %";
                    hoja_trabajo.Cells[R + 5, 11] = "Commision Paid";
                    hoja_trabajo.Cells[R + 5, 12] = "Member Agreement No.";
                    //*****************Fecha de Exportacion
                    hoja_trabajo.Cells[R + 3, 1] = "Export Date: ";
                    var culture = new CultureInfo("en-US");
                    hoja_trabajo.Cells[R + 3, 2] =  DateTime.Now.ToString(culture.DateTimeFormat);
            R = 1;
                    /*--------------------------------------------------------------------------------------------*/
               foreach(DataRowView DV  in DV1)
            {
                    /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 1] = DV["agreementnumber"].ToString(); 
                hoja_trabajo.Cells[R + 5, 2] = DV["contractdate"].ToString();
                    hoja_trabajo.Cells[R + 5, 3] = DV["price"].ToString();
                    hoja_trabajo.Cells[R + 5, 4] = DV["closingcost"].ToString();
                    hoja_trabajo.Cells[R + 5, 5] = DV["tax"].ToString();

                    hoja_trabajo.Cells[R + 5, 6] = DV["PaymentMade"].ToString();
                    hoja_trabajo.Cells[R + 5, 7] = DV["PaymentPercent"].ToString();
                    hoja_trabajo.Cells[R + 5, 8] = DV["RequestDate"].ToString();
                    hoja_trabajo.Cells[R + 5, 9] = DV["ToPay"].ToString();
                    hoja_trabajo.Cells[R + 5, 10] = DV["CommisionPercent"].ToString();
                    hoja_trabajo.Cells[R + 5, 11] = DV["CommisionPaid"].ToString();
                    hoja_trabajo.Cells[R + 5, 12] = DV["MemberAgreementNo"].ToString();

                    /*--------------Formato por cada linea----------------------------------------------------*/

                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 5) + "", "L" + (R + 5) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    rango4.Rows.RowHeight = 13.5;
                    rango4.Interior.Color = Color.GhostWhite;
                    rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    /*----------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango43 = aplicacion.Range["C" + (R + 5) + "", "G" + (R + 5) + ""];
                    rango43.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["I" + (R + 5) + "", "K" + (R + 5) + ""];
                    rango44.NumberFormat = "#,##0.00";
                /*--------------------------------------------*/
                R += 1;
                R1 += 1;
                //}

            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAK1 = aplicacion.Range["A" + (R1 + 7) + "", "L" + (R1 + 7) + ""];
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
            hoja_trabajo.Cells[(R1 * 1) + 7, 6] = "=Sum(F6:F" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 9] = "=Sum(I6:I" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 11] = "=Sum(K6:K" + (R1 + 6) + "";

            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["A" + (R1 + 7) + ""];
            rango3.Font.Bold = true;

            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango31 = aplicacion.Range["F5" + (R1 + 7) + ""];
            rango31.Font.Bold = true;
            /*----------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango33 = aplicacion.Range["A" + (R1 + 10) + ":H" + (R1 + 10) + ""];
            rango33.Font.Bold = true;
            hoja_trabajo.Cells[(R1 * 1) + 10, 1] = "Preparado Por:";
            hoja_trabajo.Cells[(R1 * 1) + 10, 4] = "Revisado Por:";
            hoja_trabajo.Cells[(R1 * 1) + 10, 8] = "Aprobado Por:";
            hoja_trabajo.get_Range("A" + ((R1 * 1) + 10) + ":B" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("D" + ((R1 * 1) + 10) + ":F" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("H" + ((R1 * 1) + 10) + ":J" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
