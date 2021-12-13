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
  public  class AgedAccountReceivable
    {
        public void ExportToExcel(DataView DV1)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAK = aplicacion.Range["A1", "AA1"];
            rangoAK.Interior.Color = Color.DarkBlue;
            rangoAK.Font.Bold = true; rangoAK.Font.Color = Color.White;
            rangoAK.Rows.RowHeight = 30;
            rangoAK.WrapText = true;
            rangoAK.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoAK.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK.VerticalAlignment = XlHAlign.xlHAlignCenter;
            rangoAK.Columns.ColumnWidth = 20;
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A1", "A" + (DV1.Count + 10) + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rango121 = aplicacion.Range["B1", "B" + (DV1.Count + 10) + ""];
            rango121.NumberFormat = "mmm-dd-yyyy";//formato fecha
            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0, R = 0;
            hoja_trabajo.Cells[R + 1, 1] = "Contract No.";
            hoja_trabajo.Cells[R + 1, 2] = "Contract Date";
            hoja_trabajo.Cells[R + 1, 3] = "Last Payment Date";
            hoja_trabajo.Cells[R + 1, 4] = "Last Year";
            hoja_trabajo.Cells[R + 1, 5] = "Net Sales";
            hoja_trabajo.Cells[R + 1, 6] = "Closing Cost";
            hoja_trabajo.Cells[R + 1, 7] = "Tax";
            hoja_trabajo.Cells[R + 1, 8] = "Total Membership";
            hoja_trabajo.Cells[R + 1, 9] = "Accounting Status";
            hoja_trabajo.Cells[R + 1, 10] = "Contract Status";
            hoja_trabajo.Cells[R + 1, 11] = "Payments Received";
            hoja_trabajo.Cells[R + 1, 12] = "DownPayment";
            hoja_trabajo.Cells[R + 1, 13] = "MR Amount";
            hoja_trabajo.Cells[R + 1, 14] = "Future Payment";
            hoja_trabajo.Cells[R + 1, 15] = "Expected Payment";
            hoja_trabajo.Cells[R + 1, 16] = "Diference";
            hoja_trabajo.Cells[R + 1, 17] = "Sales_Settled";
            hoja_trabajo.Cells[R + 1, 18] = "CC_Tac_Settled";
            hoja_trabajo.Cells[R + 1, 19] = "Sales_Distribution";
            hoja_trabajo.Cells[R + 1, 20] = "CC_Tax_Distribution";
            hoja_trabajo.Cells[R + 1, 21] = "Payment_Percentage";
            hoja_trabajo.Cells[R + 1, 22] = "Distribution_Diference";
            hoja_trabajo.Cells[R + 1, 23] = "PendingToGlobalia";
            hoja_trabajo.Cells[R + 1, 24] = "PendingToLHVC";
            hoja_trabajo.Cells[R + 1, 25] = "Expected_Percent";
            hoja_trabajo.Cells[R + 1, 26] = "PendingToGlobaliaSales_VS%";
            hoja_trabajo.Cells[R + 1, 27] = "PendingToGlobaliaTaxCC_VS%";
            R = 1;
            /*--------------------------------------------------------------------------------------------*/
            foreach (DataRowView DV in DV1)
            {
                /*----------------------------------------------------------------------------*/
                hoja_trabajo.Cells[R + 1, 1] = DV["agreementnumber"].ToString();
                hoja_trabajo.Cells[R + 1, 2] = DV["contractdate"].ToString();
                hoja_trabajo.Cells[R + 1, 3] = DV["lastpaydate"].ToString();
                hoja_trabajo.Cells[R + 1, 4] = DV["lastyear"].ToString();
                hoja_trabajo.Cells[R + 1, 5] = DV["netsales"].ToString();
                hoja_trabajo.Cells[R + 1, 6] = DV["closingcost"].ToString();
                hoja_trabajo.Cells[R + 1, 7] = DV["tax"].ToString();
                hoja_trabajo.Cells[R + 1, 8] = DV["totalmembership"].ToString();
                hoja_trabajo.Cells[R + 1, 9] = DV["contractstatuspayment"].ToString();
                hoja_trabajo.Cells[R + 1, 10] = DV["contractstatus"].ToString();
                hoja_trabajo.Cells[R + 1, 11] = DV["payments_received"].ToString();
                hoja_trabajo.Cells[R + 1, 12] = DV["downpayment"].ToString();
                hoja_trabajo.Cells[R + 1, 13] = DV["financingamount"].ToString();
                hoja_trabajo.Cells[R + 1, 14] = DV["futurepayment"].ToString();
                hoja_trabajo.Cells[R + 1, 15] = DV["expectedpayment"].ToString();
                hoja_trabajo.Cells[R + 1, 16] = DV["diference"].ToString();
                hoja_trabajo.Cells[R + 1, 17] = DV["sales_settled"].ToString();
                hoja_trabajo.Cells[R + 1, 18] = DV["tax_settled"].ToString();
                hoja_trabajo.Cells[R + 1, 19] = DV["sales_distribution"].ToString();
                hoja_trabajo.Cells[R + 1, 20] = DV["tax_closing_distribution"].ToString();
                hoja_trabajo.Cells[R + 1, 21] = DV["payment_percentage"].ToString();
                hoja_trabajo.Cells[R + 1, 22] = DV["Distribution_Diference"].ToString();
                hoja_trabajo.Cells[R + 1, 23] = DV["PendingToGlobalia"].ToString();
                hoja_trabajo.Cells[R + 1, 24] = DV["PendingToLHVC"].ToString();
                hoja_trabajo.Cells[R + 1, 25] = DV["ExpectedPercent"].ToString();
                hoja_trabajo.Cells[R + 1, 26] = DV["PendingToGlobaliaSales"].ToString();
                hoja_trabajo.Cells[R + 1, 27] = DV["PendingToGlobaliaTaxCC"].ToString();
                /*--------------Formato por cada linea----------------------------------------------------*/

                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 1) + "", "AA" + (R + 1) + ""];
                rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                rango4.Rows.RowHeight = 13.5;
                rango4.Interior.Color = Color.GhostWhite;
                rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                /*-----------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango414 = aplicacion.Range["E" + (R + 1) + "", "AA" + (R + 1) + ""];
                rango414.NumberFormat = "#,##0.00";
                /*----------------------------------------------*/
                R += 1;
                R1 += 1;

            }
            hoja_trabajo.Name = "Aged Accounts Receivable";
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*¿¿¿¿¿¿¿¿¿¿¿¿¿¿'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''*/
    }
}
