using Microsoft.Office.Interop.Excel;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Evolution.General.RealEstateData
{
    public class ExportRaelEstatePayment
    {
        public void ExportarGridview(List<RealEstateProcessContractDto> _realEstateProcessContract, int SelectedYear)
        {/*----------------------------------------------------------------------------------------*/
            Application aplicacion;
            Workbook libros_trabajo;
            Worksheet hoja_trabajo;
            Worksheet hoja_trabajoX;
            aplicacion = new Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            /*-------------------------------------------------*/
            //var xlSheets = libros_trabajo.Sheets as Sheets;
            //var xlNewSheet2 = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing);
            //hoja_trabajoX = xlNewSheet2;
            /*---------------------------------------------------*/
            hoja_trabajo = (Worksheet)libros_trabajo.Worksheets.get_Item(1);



            //Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["D6", "D" + _realEstateProcessContract.Count + 1 + ""];
            //rango2.NumberFormat = "m/d/yyyy";//solo texto en los contractos
            //Microsoft.Office.Interop.Excel.Range rangoX2 = aplicacion.Range["A2", "B2"];
            //rangoX2.Font.Bold = true;
            //rangoX2.Font.Color = Color.DarkBlue;
            //rangoX2.Font.Size = 18;

            Range tituloPrincipal = aplicacion.Range["A3", "D3"];
            tituloPrincipal.Merge();
            //tituloPrincipal.Borders.Value = 2;
            tituloPrincipal.RowHeight = 12.75;
            tituloPrincipal.Columns.WrapText = true;
            //tituloPrincipal.Borders.LineStyle = BorderStyle.FixedSingle;
            //tituloPrincipal.Interior.Color = Color.Gray;
            tituloPrincipal.Font.Color = Color.Black;
            tituloPrincipal.Font.Bold = true;
            tituloPrincipal.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            tituloPrincipal.VerticalAlignment = XlVAlign.xlVAlignCenter;
            tituloPrincipal.Value2 = "REAL ESTATE OWNERS PAYMENT";

            Range HeaderPayment = aplicacion.Range["G3", "K3"];
            HeaderPayment.Merge();
            HeaderPayment.Value2 = "Payment and Status";
            HeaderPayment.Borders.Value = 1;
            HeaderPayment.Borders.LineStyle = BorderStyle.FixedSingle;
            HeaderPayment.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            Range fromEtoO = aplicacion.Range["E5", "O" + _realEstateProcessContract.Count + 1 + ""];
            fromEtoO.NumberFormat = "#,##0.00";
            fromEtoO.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            Range formatAnualBen = aplicacion.Range["C5", "C" + _realEstateProcessContract.Count + 1 + ""];
            formatAnualBen.NumberFormat = "#,##0.00";
            formatAnualBen.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            Range Prindatdate = aplicacion.Range["A1", "B2"];
            Prindatdate.Font.Bold = true;
            Prindatdate.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            int R1 = 1;

            hoja_trabajo.Cells[1, 1] = "Print Date";
            hoja_trabajo.Cells[1, 2] = DateTime.Now.ToShortDateString();
            hoja_trabajo.Cells[2, 1] = "Year";
            hoja_trabajo.Cells[2, 2] = SelectedYear;



            

            //hoja_trabajo.Cells[4, 1] = DateTime.Now.ToShortDateString(); 
            hoja_trabajo.Cells[0 + 4, 1] = "Property";
            hoja_trabajo.Cells[0+ 4, 2] = "Owner";
            hoja_trabajo.Cells[0 + 4, 3] = "Annual Benefit";
            hoja_trabajo.Cells[0+ 4, 4] = "Pay Every";
            hoja_trabajo.Cells[0 + 4, 5] = "Installment";
            hoja_trabajo.Cells[0 + 4, 6] = "Jan - Feb";
            hoja_trabajo.Cells[0 + 4, 7] = "Mar - Apr";
            hoja_trabajo.Cells[0+ 4, 8] = "May - Jun";
            hoja_trabajo.Cells[0 + 4, 9] = "Jul - Aug";
            hoja_trabajo.Cells[0+ 4, 10] = "Sep - Oct";
            hoja_trabajo.Cells[0 + 4, 11] = "Nov - Dec";
            hoja_trabajo.Cells[0 + 4, 12] = "Deductions";
            hoja_trabajo.Cells[0 + 4, 13] = "Total Paid";
            hoja_trabajo.Cells[0 + 4, 14] = "Diffence Between Annual B. and Todal Paid";
            hoja_trabajo.Cells[0 + 4, 15] = "Extra Pay";
            hoja_trabajo.Cells[0+ 4, 16] = "Payment Execution";
            hoja_trabajo.Cells[0 + 4, 17] = "Name in WT Detail";
            foreach (var item in _realEstateProcessContract)
            {
                    hoja_trabajo.Cells[R1 + 4, 1] = item.PropertyDescription;
                    hoja_trabajo.Cells[R1 + 4, 2] = item.OwnerInfo;
                    hoja_trabajo.Cells[R1 + 4, 3] = item.AnualBenefit;
                    hoja_trabajo.Cells[R1 + 4, 4] = item.PayEvery;
                    hoja_trabajo.Cells[R1 + 4, 5] = item.PaymentAmount;
                    hoja_trabajo.Cells[R1 + 4, 6] = item.JanToFeb;
                    hoja_trabajo.Cells[R1 + 4, 7] = item.MarToApr;
                    hoja_trabajo.Cells[R1 + 4, 8] = item.MayToJun;
                    hoja_trabajo.Cells[R1 + 4, 9] = item.JulToAug;
                    hoja_trabajo.Cells[R1 + 4, 10] = item.SepToOct;
                    hoja_trabajo.Cells[R1 + 4, 11] = item.NovToDec;
                    hoja_trabajo.Cells[R1 + 4, 12] = item.DN;
                    hoja_trabajo.Cells[R1 + 4, 13] = item.TotalPaid;
                    hoja_trabajo.Cells[R1 + 4, 14] = item.B_AnnualTotPaid;
                    hoja_trabajo.Cells[R1 + 4, 15] = item.ExtraPay;
                    hoja_trabajo.Cells[R1 + 4, 16] = item.PaymentExecution;
                    hoja_trabajo.Cells[R1 + 4, 17] = item.NameWTdetails;
                   
                R1++;
              
            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A4", "Q4"];
            rangos.Columns.ColumnWidth = 13.75;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.Gray;
            rangos.Font.Color = Color.White;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            
            Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (R1 + 6) + "", "Q" + (R1 + 6) + ""];
            rango5.Interior.Color = Color.Gainsboro;
            rango5.Font.Bold = true;
            rango5.NumberFormat = "#,##0.00";
            rango5.Borders.LineStyle = BorderStyle.FixedSingle;
            rango5.Interior.Color = Color.LightGray;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 6, 1] = "TOTAL";
            hoja_trabajo.Cells[R1 + 6, 3] = "=sum(C5:C" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 5] = "=sum(E5:E" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 6] = "=sum(F5:F" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 7] = "=sum(G5:G" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 8] = "=sum(H5:H" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 9] = "=sum(I5:I" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 10] = "=sum(J5:J" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 11] = "=sum(K5:K" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 12] = "=sum(L5:L" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 13] = "=sum(M5:M" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 14] = "=sum(N5:N" + (R1 + 5) + ")";
            hoja_trabajo.Cells[R1 + 6, 15] = "=sum(O5:O" + (R1 + 5) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["A" + (R1 + 7) + "", "Q" + (R1 + 7) + ""];
            rango6.Interior.Color = Color.DimGray;
            rango6.Font.Bold = true;
            rango6.Font.Color = Color.White;
            rango6.NumberFormat = "#,##0.00";
            rango6.Borders.LineStyle = BorderStyle.FixedSingle;
            //hoja_trabajo.Cells[R1 + 7, 1] = "Payment and Status";

            /*----------------------------------------------------------------------------------------------*/
            Range gridToContent = aplicacion.Range["A5", "Q" + R1 + 1 + ""];
            //gridToContent.Borders.LineStyle = BorderStyle.FixedSingle;
            
            /*==================================================================================================================================================================================*/
            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*===================================================================================================================================================================================*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
