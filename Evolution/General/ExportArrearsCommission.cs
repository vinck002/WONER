using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
namespace Evolution.General
{
  public static class ExportArrearsCommission
    {
        public static void ExportarGridview(Telerik.WinControls.UI.RadGridView DV, string ReportDate)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            /*----------------------------------------------------*/
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B6", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango111 = aplicacion.Range["A1", "C1"];
            rango111.Font.Color = Color.FromArgb(0,0,139);
            rango111.Font.Size = 20;
            /*----------------------------------------------------------------------------*/
            hoja_trabajo.Cells[1, 1] = "Collections Of Arrears";
            hoja_trabajo.Cells[2, 1] = "COMMISSION REPORT";
            hoja_trabajo.Cells[3, 1] = ReportDate;
            /*----------------------------------------------------------------------------*/
            hoja_trabajo.Cells[5, 1] = "Contract Date";
            hoja_trabajo.Cells[5, 2] = "Contract No.";
            hoja_trabajo.Cells[5, 3] = "Financing Holder";
            hoja_trabajo.Cells[5, 4] = "Financing Sequence";
            hoja_trabajo.Cells[5, 5] = "Financing Pay Status";
            hoja_trabajo.Cells[5, 6] = "MP";
            hoja_trabajo.Cells[5, 7] = "Month In Arrears";
            hoja_trabajo.Cells[5, 8] = "Total Payment In Arrears";
            hoja_trabajo.Cells[5, 9] = "PaymentPlan Amount";
            hoja_trabajo.Cells[5, 10] = "PaymentPlan Amount Paid";
            hoja_trabajo.Cells[5, 11] = "Commission To Paid 1";
            hoja_trabajo.Cells[5, 12] = "Commission To Paid Adm.";
           
            /*------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG1 = aplicacion.Range["A5", "L5"];
            rangoG1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG1.Font.Bold = true;
            rangoG1.Font.Size = 11;
            rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoG1.WrapText = true;
            rangoG1.Interior.Color = Color.FromArgb(217, 226, 243);
            Microsoft.Office.Interop.Excel.Range rangoG311 = aplicacion.Range["A5", "B5"];
            rangoG311.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range rangoG3 = aplicacion.Range["C5", "C5"];
            rangoG3.ColumnWidth = 17;
            Microsoft.Office.Interop.Excel.Range rangoG4 = aplicacion.Range["D5", "L5"];
            rangoG4.ColumnWidth = 17;
            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0;
            for (int R = 0; R <= DV.RowCount - 1; R++)
            {
                    /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 6, 1] = DV.Rows[R].Cells["ContractDate"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DV.Rows[R].Cells["AgreementNumber"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 3] = DV.Rows[R].Cells["FinancingHolder"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 4] = DV.Rows[R].Cells["FinancingSeq"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 5] = DV.Rows[R].Cells["FinancingPayStatus"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 6] = DV.Rows[R].Cells["MP"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 7] = DV.Rows[R].Cells["MonthInArrears"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 8] = DV.Rows[R].Cells["BalanceInArrear"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 9] = DV.Rows[R].Cells["PaymentPlanAmount"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 10] = DV.Rows[R].Cells["PaymentPlanAmountPaid"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 11] = DV.Rows[R].Cells["ToPay"].Value.ToString();
                hoja_trabajo.Cells[R + 6, 12] = DV.Rows[R].Cells["ToPay"].Value.ToString();
                /*--------------Formato por cada linea----------------------------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["F" + (R + 6) + "", "L" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["A" + (R + 6) + "", "L" + (R + 6) + ""];
                rango44.Borders.LineStyle = BorderStyle.FixedSingle;
                /*-------------------------------------------------------------------------------------------------------*/
                R1 += 1;
                

            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["G" + (R1 + 7) + "", "L" + (R1 + 7) + ""];
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            rango2.Interior.Color = Color.FromArgb(208, 206, 206);
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 7, 7] = "TOTAL";
            hoja_trabajo.Cells[R1 + 7, 8] = "=sum(H6:H" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 7, 9] = "=sum(I6:I" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 7, 10] = "=sum(J6:J" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 7, 11] = "=sum(K6:K" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 7, 12] = "=sum(L6:L" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 9, 10] = "TOTAL TO BE PAID";
            hoja_trabajo.Cells[R1 + 9, 11] = "=sum(K6:K" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 9, 12] = "=sum(L6:L" + (R1 + 6) + ")";
            hoja_trabajo.Cells[R1 + 10, 10] = "TOTAL";
            hoja_trabajo.Cells[R1 + 10, 11] = "=sum(K6:L" + (R1 + 6) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG7 = aplicacion.Range["J" + (R1 + 9) + ", L" + (R1 + 9) + ""];
            rangoG7.Font.Bold = true;
            rangoG7.Font.Size = 11;
            rangoG7.Font.Color = Color.White;
            rangoG7.Interior.Color = Color.FromArgb(255,0,0);
            rangoG7.Borders.LineStyle = BorderStyle.FixedSingle;

            Microsoft.Office.Interop.Excel.Range rangoG71 = aplicacion.Range["J" + (R1 + 10) + ", K" + (R1 + 10) + ""];
            rangoG71.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoG71.Interior.Color = Color.FromArgb(255, 218, 101);
            rangoG71.Font.Bold = true;
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells.Font.Name = "Calibri";
            hoja_trabajo.Name = "Arrears";
            /*------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*===========================================================================================================================================================*/
    }
}
