using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Telerik.WinControls.UI;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
namespace Evolution.General
{
   public class ContractsCommission
    {
        public void ExportContractCommission( RadGridView DV,RadGridView DV1)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B1", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0, R2 = DV.RowCount, R3 = DV1.RowCount, R4 = DV.RowCount;
            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                {

                    hoja_trabajo.Cells[R + 1, 1] = "COMPANY";
                    hoja_trabajo.Cells[R + 1, 2] = "AGREEMENT NUMBER";
                    hoja_trabajo.Cells[R + 1, 3] = "MEMBERSHIP";
                    hoja_trabajo.Cells[R + 1, 4] = "CLOSING COST";
                    hoja_trabajo.Cells[R + 1, 5] = "TAX";
                    hoja_trabajo.Cells[R + 1, 6] = "PAY AFTER %";
                    hoja_trabajo.Cells[R + 1, 7] = "MEMBERSHIP %";
                    hoja_trabajo.Cells[R + 1, 8] = "CLOSING COST %";
                    hoja_trabajo.Cells[R + 1, 9] = "TAX %";
                    hoja_trabajo.Cells[R + 1, 10] = "MEMBERSHIP DISTRIBUTION";
                    hoja_trabajo.Cells[R + 1, 11] = "CLOSING COST DISTRIBUTION";
                    hoja_trabajo.Cells[R + 1, 12] = "TAX DISTRIBUTION";
                    hoja_trabajo.Cells[R + 1, 13] = "TOTAL DISTRIBUTION";
                    hoja_trabajo.Cells[R + 1, 14] = "MEMBER CONTRACT #";
                    /*-------------------Header Comision pagada--------------------------------------*/
                    hoja_trabajo.Cells[R2 + 5, 1] = "COMPANY";
                    hoja_trabajo.Cells[R2 + 5, 2] = "AGREEMENT NUMBER";
                    hoja_trabajo.Cells[R2 + 5, 3] = "MEMBERSHIP COMMISSION";
                    hoja_trabajo.Cells[R2+ 5, 4] = "CLOSING COST COMMISSION";
                    hoja_trabajo.Cells[R2 + 5, 5] = "TAX COMMISSION";
                    /*-------------------Header Total Neto--------------------------------------*/
                    hoja_trabajo.Cells[R2 + 5, 7] = "AGREEMENT NUMBER";
                    hoja_trabajo.Cells[R2 + 5, 8] = "TOTAL CONTRACT";
                    hoja_trabajo.Cells[R2 + 5, 9] = "TOTAL MEMBERSHIP DIST";
                    hoja_trabajo.Cells[R2 + 5, 10] = "TOTAL CLOSING COST DIST";
                    hoja_trabajo.Cells[R2 + 5, 11] = "TOTAL TAX DIST";
                    hoja_trabajo.Cells[R2 + 5, 12] = "NET TOTAL";
                }
                else
                {
                    hoja_trabajo.Cells[R + 1, 1] = DV.Rows[R1].Cells["Company"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 2] = DV.Rows[R1].Cells["AgreementNumber"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 3] = DV.Rows[R1].Cells["Price"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 4] = DV.Rows[R1].Cells["ClosingCost"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 5] = DV.Rows[R1].Cells["Tax"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 6] = DV.Rows[R1].Cells["PayAfter"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 7] = DV.Rows[R1].Cells["PricePercent"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 8] = DV.Rows[R1].Cells["ClosingPercent"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 9] = DV.Rows[R1].Cells["TaxPercent"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 10] = DV.Rows[R1].Cells["PriceDist"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 11] = DV.Rows[R1].Cells["ClosingDist"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 12] = DV.Rows[R1].Cells["TaxDist"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 13] = DV.Rows[R1].Cells["TotalDist"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 14] = DV.Rows[R1].Cells["MembercontractNo"].Value.ToString();
                    /*-------------------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R2 + 6, 1] = DV.Rows[R1].Cells["Company"].Value.ToString();
                    hoja_trabajo.Cells[R2 + 6, 2] = DV.Rows[R1].Cells["AgreementNumber"].Value.ToString();
                    hoja_trabajo.Cells[R2 + 6, 3] = DV.Rows[R1].Cells["pricepaid"].Value.ToString();
                    hoja_trabajo.Cells[R2 + 6, 4] = DV.Rows[R1].Cells["closingpaid"].Value.ToString();
                    hoja_trabajo.Cells[R2 + 6, 5] = DV.Rows[R1].Cells["taxpaid"].Value.ToString();
                    //                            
                    /*--------------Formato por cada linea----------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["C" + (R + 1) + "", "N" + (R + 1) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 1) + "", "N" + (R + 1) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*---------------------second format---------------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango333 = aplicacion.Range["C" + (R2 + 6) + "", "E" + (R2 + 6) + ""];
                    rango333.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango444 = aplicacion.Range["A" + (R2 + 6) + "", "E" + (R2 + 6) + ""];
                    rango444.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                    R2 += 1;
                }

            }
            /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Grid NetTotal>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
            Microsoft.Office.Interop.Excel.Range rango111 = aplicacion.Range["G"+ (R4 +2) +"", "G" + (DV1.RowCount +(R4+ 7)) + ""];
            rango111.NumberFormat = "@";//solo texto en los contractos
            for (int R=0; R<=DV1.RowCount -1; R++)
            {
                hoja_trabajo.Cells[R4 + 6, 7] = DV1.Rows[R].Cells["AgreementNumber"].Value.ToString();
                hoja_trabajo.Cells[R4 + 6, 8] = DV1.Rows[R].Cells["totalcontract"].Value.ToString();
                hoja_trabajo.Cells[R4 + 6, 9] = DV1.Rows[R].Cells["totalmembership"].Value.ToString();
                hoja_trabajo.Cells[R4 + 6, 10] = DV1.Rows[R].Cells["totalclosing"].Value.ToString();
                hoja_trabajo.Cells[R4 + 6, 11] = DV1.Rows[R].Cells["totaltax"].Value.ToString();
                hoja_trabajo.Cells[R4 + 6, 12] = DV1.Rows[R].Cells["nettotal"].Value.ToString();
                /*---------------------second format---------------------------------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango3331 = aplicacion.Range["H" + (R4 + 6) + "", "L" + (R4 + 6) + ""];
                rango3331.NumberFormat = "#,##0.00";
                Microsoft.Office.Interop.Excel.Range rango4441 = aplicacion.Range["G" + (R4 + 6) + "", "L" + (R4 + 6) + ""];
                rango4441.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rango5551 = aplicacion.Range["L" + (R4 + 6) + "", "L" + (R4 + 6) + ""];
                rango5551.Font.Color = ((decimal.Parse(DV1.Rows[R].Cells["nettotal"].Value.ToString()) <0)? Color.Red : Color.Black);
                /*------------------------------------------------------*/
                R3 = R3 + 1;
                R4 = R4 + 1;
            }
            /*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A1", "N1"];
            rangos.Columns.ColumnWidth = 15;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.Azure;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A" + (R1 + 3) + "", "N" + (R1 + 3) + ""];
            rango2.Interior.Color = Color.Azure ;
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------Formato2--------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos33 = aplicacion.Range["A"+ (DV.RowCount +5)+ "", "E"+(DV.RowCount + 5)+""];
            rangos33.Columns.ColumnWidth = 15;
            rangos33.RowHeight = 27.75;
            rangos33.Columns.WrapText = true;
            rangos33.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos33.Interior.Color = Color.LightGoldenrodYellow;
            rangos33.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos33.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango34 = aplicacion.Range["A" + (R2 + 6) + "", "E" + (R2 + 6) + ""];
            rango34.Interior.Color = Color.LightGoldenrodYellow;
            rango34.Font.Bold = true;
            rango34.NumberFormat = "#,##0.00";
            rango34.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------Formato3 para total neto--------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos331 = aplicacion.Range["G" + (DV.RowCount + 5) + "", "L" + (DV.RowCount + 5) + ""];
            rangos331.Columns.ColumnWidth = 17;
            rangos331.RowHeight = 27.75;
            rangos331.Columns.WrapText = true;
            rangos331.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos331.Interior.Color = Color.Blue ;
            rangos331.Font.Color = Color.White;
            rangos331.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos331.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango341 = aplicacion.Range["G" + (R4 + 6) + "", "L" + (R4 + 6) + ""];
            rango341.Interior.Color = Color.LightGoldenrodYellow;
            rango341.Font.Bold = true;
            rango341.NumberFormat = "#,##0.00";
            rango341.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 3, 1] = "TOTAL"; 
            hoja_trabajo.Cells[R1 + 3, 3] = "=sum(C2:C" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 4] = "=sum(D2:D" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 5] = "=sum(E2:E" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 10] = "=sum(J2:J" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 11] = "=sum(K2:K" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 12] = "=sum(L2:L" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 13] = "=sum(M2:M" + (R1 + 2) + ")";
            /*----------------------------Totales de comision----------------------------------------*/
            hoja_trabajo.Cells[R2 + 6, 1] = "TOTAL";
            hoja_trabajo.Cells[R2 + 6, 3] = "=sum(C"+ (DV.RowCount + 6) + ":C" + (R2 + 5) + ")";
            hoja_trabajo.Cells[R2 + 6, 4] = "=sum(D"+ (DV.RowCount + 6) + ":D" + (R2 + 5) + ")";
            hoja_trabajo.Cells[R2 + 6, 5] = "=sum(E"+ (DV.RowCount + 5) + ":E" + (R2 + 5) + ")";
            /*----------------------------Totales de total neto----------------------------------------*/
            hoja_trabajo.Cells[R4 + 6, 7] = "TOTAL";
            hoja_trabajo.Cells[R4 + 6, 8] = "=sum(H" + (DV.RowCount + 6) + ":H" + (R4 + 5) + ")";
            hoja_trabajo.Cells[R4 + 6, 9] = "=sum(I" + (DV.RowCount + 6) + ":I" + (R4 + 5) + ")";
            hoja_trabajo.Cells[R4 + 6, 10] = "=sum(J" + (DV.RowCount + 6) + ":J" + (R4 + 5) + ")";
            hoja_trabajo.Cells[R4 + 6, 11] = "=sum(K" + (DV.RowCount + 6) + ":K" + (R4 + 5) + ")";
            hoja_trabajo.Cells[R4 + 6, 12] = "=sum(L" + (DV.RowCount + 6) + ":L" + (R4 + 5) + ")";
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
            // aplicacion.Quit();
        }
        /*================================================================================================================================================================================*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*================================================================================================================================================================================*/
        public void ExportContractOnly(RadGridView DV)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B1", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0, R2 = DV.RowCount;
            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                {

                    hoja_trabajo.Cells[R + 1, 1] = "COMPANY";
                    hoja_trabajo.Cells[R + 1, 2] = "AGREEMENT NUMBER";
                }
                else
                {
                    hoja_trabajo.Cells[R + 1, 1] = DV.Rows[R1].Cells["Company"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 2] = DV.Rows[R1].Cells["AgreementNumber"].Value.ToString();
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 1) + "", "B" + (R + 1) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                    R2 += 1;
                }

            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A1", "B1"];
            rangos.Columns.ColumnWidth = 15;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.Azure;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*================================================================================================================================================================================*/
    }
}
