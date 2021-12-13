using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
namespace Evolution.General
{
  public  class ExportPayments
    {
        /*==========================================================================================================================================================================*/
        public void ExportPaymentToExcel(DataView DV, string DateRange1, string DateRange2)
        {/*----------------------------------------------------------------------------------------*/
            if(DV.Count < 1) { MessageBox.Show("No Payments Applied", "Evolution", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A5", "A" + DV.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0,R=0;

            hoja_trabajo.Cells[2, 1] = "Customer Balance Detail";
            hoja_trabajo.Cells[3, 1] = "Period";
            hoja_trabajo.Cells[3, 2] = ((DateRange1 == null)?"01-01-1990" : DateRange1)+" To " + DateRange2;
            hoja_trabajo.Cells[R + 5, 1] = "Agreement No";
                    hoja_trabajo.Cells[R + 5, 2] = "Member Name";
                    hoja_trabajo.Cells[R + 5, 3] = "Reference";
                    hoja_trabajo.Cells[R + 5, 4] = "Amount";
            string Contract = "0", Contract1 = "0"; DateTime CreationDate;
                    /*--------------------------------------------------------------------------------------------*/
                
            foreach(DataRowView DV2 in DV)
            {
                
                if (Contract1 =="0")
                {
                    Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["A" + (R + 6) + "", "D" + (R + 6) + ""];
                    rango44.Font.Bold = true;
                    rango44.Font.Size = 16;
                    rango44.Interior.Color = Color.LightGray;
                }
                else
                {
                    R = R + ((Contract1 != DV2["AGREEMENT_NUMBER"].ToString()) ? 1 : 0);
                   if(Contract1 != DV2["AGREEMENT_NUMBER"].ToString()){  R1 = R; }
                    Microsoft.Office.Interop.Excel.Range rango45 = aplicacion.Range["A" + (R + 6) + "", "D" + (R + 6) + ""];
                    rango45.Font.Bold = ((Contract1 != DV2["AGREEMENT_NUMBER"].ToString()) ? true : false);
                    rango45.Font.Size = ((Contract1 != DV2["AGREEMENT_NUMBER"].ToString()) ? 16 : 12);
                    rango45.Interior.Color = ((Contract1 != DV2["AGREEMENT_NUMBER"].ToString()) ? Color.LightGray : Color.White);
                }
                hoja_trabajo.Cells[R + 6, 1] = DV2["AGREEMENT_NUMBER"].ToString();
                hoja_trabajo.Cells[R + 6, 2] = DV2["MemberName"].ToString();
                hoja_trabajo.Cells[R + 6, 3] = "";
                hoja_trabajo.Cells[R + 6, 4] = Decimal.Parse(DV2["NetSales"].ToString())+ Decimal.Parse(DV2["ClosingCost"].ToString())+ Decimal.Parse(DV2["Tax"].ToString());
                /*--------------------------------------------------------------------------------------------*/
                R = R + ((Contract != DV2["AGREEMENT_NUMBER"].ToString()) ? 1 : 0);
                Contract = DV2["AGREEMENT_NUMBER"].ToString();
                /*-------------------------Transacciones-------------------------------------------------------------------*/
                CreationDate = DateTime.Parse( DV2["DateCreate"].ToString());
                hoja_trabajo.Cells[R + 6, 1] = CreationDate.ToShortDateString();
                hoja_trabajo.Cells[R + 6, 2] = DV2["TransactionType"].ToString();
                hoja_trabajo.Cells[R + 6, 3] = DV2["Reference"].ToString(); 
                hoja_trabajo.Cells[R + 6, 4] = Decimal.Parse(DV2["Amount"].ToString());
                /*--------------------------Subtotal------------------------------------------------------------------*/
                hoja_trabajo.Cells[R + 7, 1] = "";
                hoja_trabajo.Cells[R + 7, 2] = "";
                hoja_trabajo.Cells[R + 7, 3] = "TOTAL";
                hoja_trabajo.Cells[R + 7, 4] = "=Sum(D"+ (R1 +6) + ":D" + (R + 6) + ")";
                /*--------------------Formato subtotal-----------------------------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango56 = aplicacion.Range["B" + (R + 7) + "", "D" + (R + 7) + ""];
                rango56.NumberFormat = "#,##0.00";
                rango56.Font.Bold = true;
                rango56.Font.Size = 14;
                rango56.Interior.Color = Color.LightSteelBlue;
                /*--------------Formato por cada linea----------------------------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["D" + (R + 6) + "", "D" + (R + 6) + ""];
                rango3.NumberFormat = "#,##0.00";
                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "D" + (R + 6) + ""];
                rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                /*-------------------------------------------------------------------------------------------------------*/
                Contract1 = DV2["AGREEMENT_NUMBER"].ToString();
                //R1 += 1;
                R += 1;
            }
            /*---------------------------------Sumatoria-----------------------------------------------------------------*/
            hoja_trabajo.Cells[(R + 2) + 6, 1] = "GRAND TOTAL";
            hoja_trabajo.Cells[(R + 2) + 6, 4] = "=SumIf(C1:C"+(R+6)+",\"TOTAL\","+"D1:D"+ (R + 6) + ")";
            /*---------------------------------Sumatoria Formato----------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango311 = aplicacion.Range["A" + (R + 8) + "", "D" + (R + 8) + ""];
            rango311.NumberFormat = "#,##0.00";
            rango311.Borders.LineStyle = BorderStyle.FixedSingle;
            rango311.Interior.Color = Color.DarkBlue;
            rango311.Font.Color = Color.White;
            rango311.Font.Bold = true;
            rango311.Font.Size = 16;
            /*-----------------------------Formato-------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango33 = aplicacion.Range["A5", "D5"];
            rango33.Columns.ColumnWidth = 35;
            rango33.RowHeight = 27.75;
            rango33.Columns.WrapText = true;
            rango33.Borders.LineStyle = BorderStyle.FixedSingle;
            rango33.Interior.Color = Color.DarkBlue;
            rango33.Font.Color = Color.White;
            rango33.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rango33.Font.Bold = true;
            rango33.Font.Size = 18;
            /*------------------------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*===============================================================================================================================================================*/
    }
}
