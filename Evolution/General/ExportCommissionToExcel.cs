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
  public  class ExportCommissionToExcel
    {
        public void ExportarGridview(RadGridView DV,string company,Double Paymentmade,DataView DVW )
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            /*-------------------------------------------------*/
            var xlSheets = libros_trabajo.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing);
            hoja_trabajoX = xlNewSheet2;
            /*---------------------------------------------------*/
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            hoja_trabajoX = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(2);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B6", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["D6", "D" + DV.RowCount + 1 + ""];
            rango2.NumberFormat = "m/d/yyyy";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rangoX2 = aplicacion.Range["A2", "B2"];
            rangoX2.Font.Bold = true; 
            rangoX2.Font.Color = Color.DarkBlue;
            rangoX2.Font.Size = 18;
            int R1 = 0;
            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                { /*-----------------Report Header------------------------------------*/
                    hoja_trabajo.Cells[2, 1] = company;
                    hoja_trabajo.Cells[3, 1] = "REFERRAL COMMISSION REPORT";
                    hoja_trabajo.Cells[4, 1] = DateTime.Now.ToShortDateString(); ;
                    hoja_trabajo.Cells[R + 6, 1] = "MEMBERS NAME";
                    hoja_trabajo.Cells[R + 6, 2] = "CONTRACT No.";
                    hoja_trabajo.Cells[R + 6, 3] = "TYPE";
                    hoja_trabajo.Cells[R + 6, 4] = "CONTRACTED DATE";
                    hoja_trabajo.Cells[R + 6, 5] = "AMOUNT";
                    hoja_trabajo.Cells[R + 6, 6] = "DP %";
                    hoja_trabajo.Cells[R + 6, 7] = "PAYMENT MADE";
                    hoja_trabajo.Cells[R + 6, 8] = "PAYMENT MADE";
                    hoja_trabajo.Cells[R + 6, 9] = "MR MADE";
                    hoja_trabajo.Cells[R + 6, 10] = "% COM";
                    hoja_trabajo.Cells[R + 6, 11] = "AMOUNT";
                    hoja_trabajo.Cells[R + 6, 12] = "COMMENTARIES";
                    hoja_trabajo.Cells[R + 6, 13] = "Pending Balance";
                    hoja_trabajo.Cells[R + 6, 14] = "Interest";
                    hoja_trabajo.Cells[R + 6, 15] = "Pending Balance To Pay";

                }
                else
                {
                    hoja_trabajo.Cells[R + 6, 1] = DV.Rows[R1].Cells["membername"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DV.Rows[R1].Cells["contractno"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 3] = DV.Rows[R1].Cells["type"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 4] = DV.Rows[R1].Cells["contractdate"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 5] = DV.Rows[R1].Cells["Price"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 6] = DV.Rows[R1].Cells["DP"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 7] = DV.Rows[R1].Cells["paymentmade"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 8] = DV.Rows[R1].Cells["paymentapplied"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 9] = DV.Rows[R1].Cells["mrapplied"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 10] = DV.Rows[R1].Cells["com"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 11] = DV.Rows[R1].Cells["amount"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 12] = DV.Rows[R1].Cells["comment"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 13] = DV.Rows[R1].Cells["pendingbalance"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 14] = DV.Rows[R1].Cells["interestapplied"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 15] = DV.Rows[R1].Cells["pendingbalancetopay"].Value.ToString();
                    /*--------------Formato por cada linea----------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango355 = aplicacion.Range["E" + (R + 6) + "", "O" + (R + 6) + ""];
                    rango355.NumberFormat = "dd-MMM-yyyy";
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["E" + (R + 6) + "", "O" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "O" + (R + 6) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    Microsoft.Office.Interop.Excel.Range rango88 = aplicacion.Range["A" + (R + 6) + "", "B" + (R + 6) + ""];
                    rango88.Font.Color = ((DV.Rows[R1].Cells["EvoStatusID"].Value.ToString() =="0")?Color.Red : Color.Black);
                    /*-------------------------------------------------------------------------------------------------------*/


                    R1 += 1;
                }
                
            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6", "O6"];
            rangos.Columns.ColumnWidth = 13.75;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.DarkBlue;
            rangos.Font.Color = Color.White;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (R1 + 8) + "", "O" + (R1 + 8) + ""];
            rango5.Interior.Color = Color.Gainsboro;
            rango5.Font.Bold = true;
            rango5.NumberFormat = "#,##0.00";
            rango5.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 8, 1] = "TOTAL";
            hoja_trabajo.Cells[R1 + 8, 5] = "=sum(E7:E" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 7] = "=sum(G7:G" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 8] = "=sum(H7:H" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 9] = "=sum(I7:I" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 11] = "=sum(K7:K" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 13] = "=sum(M7:M" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 14] = "=sum(N7:N" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 15] = "=sum(O7:O" + (R1 + 7) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["A" + (R1 + 9) + "", "O" + (R1 + 9) + ""];
            rango6.Interior.Color = Color.DimGray;
            rango6.Font.Bold = true;
            rango6.Font.Color = Color.White;
            rango6.NumberFormat = "#,##0.00";
            rango6.Borders.LineStyle = BorderStyle.FixedSingle;
            hoja_trabajo.Cells[R1 + 9, 1] = "PAYMENT MADE";
            hoja_trabajo.Cells[R1 + 9, 11] = Paymentmade;
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango7 = aplicacion.Range["A" + (R1 + 10) + "", "O" + (R1 + 10) + ""];
            rango7.Interior.Color = Color.Red;
            rango7.Font.Bold = true;
            rango7.Font.Color = Color.White;
            rango7.NumberFormat = "#,##0.00";
            rango7.Borders.LineStyle = BorderStyle.FixedSingle;
            hoja_trabajo.Cells[R1 + 10, 1] = "TOTAL TO BE PAID";
            hoja_trabajo.Cells[R1 + 10, 11] = "=sum(K"+(R1+8)+"-K" + (R1 + 9) + ")";
            hoja_trabajo.Name = "Report Update";
            /*===================================Otra hoja=======================================================================================================================================*/
            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*===================================================================================================================================================================================*/
            hoja_trabajoX.Cells[2, 1] = company;
            hoja_trabajoX.Cells[3, 1] = "Payment Report";

            int F1 = 0;
            if (DVW.Count > 0)
            {
                for (int R = 0; R <= DVW.Count; R++)
                {
                    if (R == 0)
                    {
                        hoja_trabajoX.Cells[5, 1] = "Description";
                        hoja_trabajoX.Cells[5, 2] = "Date";
                        hoja_trabajoX.Cells[5, 3] = "No.";
                        hoja_trabajoX.Cells[5, 4] = "Payment Made";
                    }
                    else
                    {
                        hoja_trabajoX.Cells[R + 5, 1] = DVW.Table.Rows[F1]["Reference"].ToString();
                        hoja_trabajoX.Cells[R + 5, 2] = DVW.Table.Rows[F1]["CreationDate"].ToString();
                        hoja_trabajoX.Cells[R + 5, 3] = DVW.Table.Rows[F1]["InvoiceNumber"].ToString();
                        hoja_trabajoX.Cells[R + 5, 4] = DVW.Table.Rows[F1]["TotalPaymentMade"].ToString();
                        /*--------------Formato por cada linea----------------------------------------------------*/
                        Microsoft.Office.Interop.Excel.Range rango333 = aplicacion.Worksheets.get_Item(2).Range["D" + (R + 6) + "", "D" + (R + 6) + ""];
                        rango333.NumberFormat = "#,##0.00";
                        Microsoft.Office.Interop.Excel.Range rango444 = aplicacion.Worksheets.get_Item(2).Range["A" + (R + 6) + "", "D" + (R + 6) + ""];
                        rango444.Borders.LineStyle = BorderStyle.FixedSingle;
                                                                              /*-------------------------------------------------------------------------------------------------------*/
                        F1 = F1 + 1;
                    }
                }
                /*----------------------------------------------------------------------------------------------*/
                hoja_trabajoX.Cells[F1 + 7, 3] = "TOTAL Payment";
                hoja_trabajoX.Cells[F1 + 7, 4] = "=sum(D6:D" + (F1 + 6) + ")";
                Microsoft.Office.Interop.Excel.Range rangos55 = aplicacion.Worksheets.get_Item(2).Range["A5", "D5"];
                rangos55.Columns.ColumnWidth = 28.75;
                rangos55.RowHeight = 27.75;
                rangos55.Columns.WrapText = true;
                rangos55.Borders.LineStyle = BorderStyle.FixedSingle;
                rangos55.Interior.Color = Color.DarkBlue;
                rangos55.Font.Color = Color.White;
                rangos55.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rangos55.Font.Bold = true;
                Microsoft.Office.Interop.Excel.Range rango777 = aplicacion.Worksheets.get_Item(2).Range["A" + (F1 + 7) + "", "D" + (F1 + 7) + ""];
                rango777.Interior.Color = Color.DarkBlue;
                rango777.Font.Bold = true;
                rango777.Font.Color = Color.White;
                rango777.NumberFormat = "#,##0.00";
                rango777.Borders.LineStyle = BorderStyle.FixedSingle;
                hoja_trabajoX.Name = "Payments Control";
                /*----------------------------------------------------------------------------------------------*/
            }
            /*==================================================================================================================================================================================*/
            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*===================================================================================================================================================================================*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*=============================================Tercero=======================================================================================================================*/
        public void ExportarGridviewToThird(RadGridView DV, string company, Double Paymentmade,DataView DVW,String Date,decimal PaidTotal)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            /*-------------------------------------------------*/
            var xlSheets = libros_trabajo.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing);
            hoja_trabajoX = xlNewSheet2;
            /*---------------------------------------------------*/
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            hoja_trabajoX = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(2);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangobb = aplicacion.Range["L6", "L6"];
            rangobb.Font.Bold = true;
            rangobb.Font.Color = Color.White;
            rangobb.Interior.Color = Color.Red;
            rangobb.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangobb.VerticalAlignment = XlHAlign.xlHAlignCenter;
            rangobb.Borders.LineStyle = BorderStyle.FixedSingle;
            rangobb.Columns.ColumnWidth = 17.43;
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAA1 = aplicacion.Range["M6", "M6"];
            rangoAA1.Font.Bold = true;
            rangoAA1.Font.Color = Color.White;
            rangoAA1.Interior.Color = Color.Green;
            rangoAA1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoAA1.VerticalAlignment = XlHAlign.xlHAlignCenter;
            rangoAA1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAA1.Columns.ColumnWidth = 17.43;
            /*----------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangob1 = aplicacion.Range["L7", "L" + (DV.RowCount +6) + ""];
            rangob1.Font.Color = Color.Red;
            rangob1.Borders.LineStyle = BorderStyle.FixedSingle;
            /*----------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangob1x1 = aplicacion.Range["M7", "M" + (DV.RowCount + 6) + ""];
            rangob1x1.Font.Color = Color.Green;
            rangob1x1.Borders.LineStyle = BorderStyle.FixedSingle;
            /*----------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["B6", "B" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rango667 = aplicacion.Range["A4", "A4"];
            rango667.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rango667.NumberFormat = "dd-MMM-yyyy";//
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["D6", "D" + DV.RowCount + 1 + ""];
            rango2.NumberFormat = "dd-MMM-yyyy";//
            Microsoft.Office.Interop.Excel.Range rangoX2 = aplicacion.Range["A2", "B2"];
            rangoX2.Font.Bold = true;
            rangoX2.Font.Color = Color.DarkBlue;
            rangoX2.Font.Size = 18; //rangoX2.Font.FontStyle = "Arial";
            int R1 = 0;
            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                { /*-----------------Report Header------------------------------------*/
                    hoja_trabajo.Cells[2, 1] = company;
                    hoja_trabajo.Cells[3, 1] = "REFERRAL COMMISSION REPORT";
                    hoja_trabajo.Cells[4, 1] = Date;
                    hoja_trabajo.Cells[R + 6, 1] = "MEMBERS NAME";
                    hoja_trabajo.Cells[R + 6, 2] = "CONTRACT No.";
                    hoja_trabajo.Cells[R + 6, 3] = "TYPE";
                    hoja_trabajo.Cells[R + 6, 4] = "CONTRACTED DATE";
                    hoja_trabajo.Cells[R + 6, 5] = "AMOUNT";
                    hoja_trabajo.Cells[R + 6, 6] = "DP %";
                    hoja_trabajo.Cells[R + 6, 7] = "PAYMENT MADE";
                    hoja_trabajo.Cells[R + 6, 8] = "MR MADE";
                    hoja_trabajo.Cells[R + 6, 9] = "% COM";
                    hoja_trabajo.Cells[R + 6, 10] = "AMOUNT";
                    hoja_trabajo.Cells[R + 6, 11] = "COMMENTARIES";
                    hoja_trabajo.Cells[R + 6, 12] = "CHARGEBACK";
                    hoja_trabajo.Cells[R + 6, 13] = "AMOUNT DATE";
                }
                else
                { 
                    hoja_trabajo.Cells[R + 6, 1] = DV.Rows[R1].Cells["membername"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DV.Rows[R1].Cells["contractno1"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 3] = DV.Rows[R1].Cells["type"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 4] = DV.Rows[R1].Cells["contractdate"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 5] = DV.Rows[R1].Cells["Price1"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 6] = ((decimal.Parse(DV.Rows[R1].Cells["DP"].Value.ToString()) >100)? 100 : decimal.Parse( DV.Rows[R1].Cells["DP"].Value.ToString()));
                    hoja_trabajo.Cells[R + 6, 7] = DV.Rows[R1].Cells["paymentapplied"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 8] = DV.Rows[R1].Cells["mrapplied"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 9] = DV.Rows[R1].Cells["com"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 10] = DV.Rows[R1].Cells["amount"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 11] = ((DV.Rows[R1].Cells["evostatusID"].Value.ToString()=="0" & DV.Rows[R1].Cells["evostatus"].Value.ToString() !="LEGAL") ? DV.Rows[R1].Cells["evostatus"].Value.ToString() : "");
                    hoja_trabajo.Cells[R + 6, 12] = ((decimal.Parse(DV.Rows[R1].Cells["ToPay"].Value.ToString()) <0) ? DV.Rows[R1].Cells["ToPay"].Value.ToString() : "");
                    hoja_trabajo.Cells[R + 6, 13] = DV.Rows[R1].Cells["ToPay"].Value.ToString();
                    /*--------------Formato por cada linea----------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango315 = aplicacion.Range["B" + (R + 6) + "", "D" + (R + 6) + ""];
                    rango315.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango316 = aplicacion.Range["F" + (R + 6) + "", "F" + (R + 6) + ""];
                    rango316.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango317 = aplicacion.Range["I" + (R + 6) + "", "I" + (R + 6) + ""];
                    rango317.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["E" + (R + 6) + "", "K" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "K" + (R + 6) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    rango4.Rows.RowHeight = 15.75;
                    Microsoft.Office.Interop.Excel.Range rango88 = aplicacion.Range["A" + (R + 6) + "", "K" + (R + 6) + ""];
                    rango88.Font.Color = ((DV.Rows[R1].Cells["EvoStatusID"].Value.ToString() == "0" & DV.Rows[R1].Cells["evostatus"].Value.ToString() != "LEGAL") ? Color.Red : Color.Black);
                    /*-------------------------------------------------------------------------------------------------------*/


                    R1 += 1;
                }

            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6", "K6"];
            rangos.Columns.ColumnWidth = 17.43;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.DarkBlue;
            rangos.Font.Color = Color.White;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.VerticalAlignment = XlHAlign.xlHAlignCenter; ;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (R1 + 8) + "", "K" + (R1 + 8) + ""];
            rango5.Interior.Color = Color.Gainsboro;
            rango5.Font.Bold = true;
            rango5.NumberFormat = "#,##0.00";
            rango5.Borders.LineStyle = BorderStyle.FixedSingle; 
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 8, 2] = "TOTAL";
            hoja_trabajo.Cells[R1 + 8, 5] = "=sum(E7:E" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 7] = "=sum(G7:G" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 8] = "=sum(H7:H" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 10] = PaidTotal; 

            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["A" + (R1 + 9) + "", "K" + (R1 + 9) + ""];
            rango6.Interior.Color = Color.DimGray;
            rango6.Font.Bold = true;
            rango6.Font.Color = Color.White;
            rango6.NumberFormat = "#,##0.00";
            rango6.Borders.LineStyle = BorderStyle.None; 
            hoja_trabajo.Cells[R1 + 9, 2] = "PAYMENT MADE";
            hoja_trabajo.Cells[R1 + 9, 10] = Paymentmade;
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango7 = aplicacion.Range["A" + (R1 + 10) + "", "K" + (R1 + 10) + ""];
            rango7.Interior.Color = Color.Red;
            rango7.Font.Bold = true;
            rango7.Font.Color = Color.White;
            rango7.NumberFormat = "#,##0.00";
            rango7.Borders.LineStyle = BorderStyle.FixedSingle; 
            hoja_trabajo.Cells[R1 + 10, 2] = "TOTAL TO BE PAID";
            hoja_trabajo.Cells[R1 + 10, 10] = "=J" + (R1 + 8) + "-J" + (R1 + 9) + "";
            hoja_trabajo.Name = "Report Update";
            /*===================================Otra hoja=======================================================================================================================================*/
            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*===================================================================================================================================================================================*/
            hoja_trabajoX.Cells[2, 1] = company;
            hoja_trabajoX.Cells[3, 1] = "Payment Report";
            hoja_trabajoX.Name = "Payments Control";
            int F1 = 0;
            if(DVW.Count > 0)
            {
                for (int R=0; R<= DVW.Count; R++)
                { if (R == 0)
                    {
                        hoja_trabajoX.Cells[5, 1] = "Description";
                        hoja_trabajoX.Cells[5, 2] = "Date";
                        hoja_trabajoX.Cells[5, 3] = "No.";
                        hoja_trabajoX.Cells[5, 4] = "Payment Made";
                    }
                    else
                    {
                        hoja_trabajoX.Cells[R + 5, 1] = DVW.Table.Rows[F1]["Reference"].ToString();
                        hoja_trabajoX.Cells[R + 5, 2] = DVW.Table.Rows[F1]["CreationDate"].ToString();
                        hoja_trabajoX.Cells[R + 5, 3] = DVW.Table.Rows[F1]["InvoiceNumber"].ToString();
                        hoja_trabajoX.Cells[R + 5, 4] = DVW.Table.Rows[F1]["TotalPaymentMade"].ToString();
                        /*--------------Formato por cada linea----------------------------------------------------*/
                        Microsoft.Office.Interop.Excel.Range rango333 = aplicacion.Worksheets.get_Item(2).Range["D" + (R + 6) + "", "D" + (R + 6) + ""];
                        rango333.NumberFormat = "#,##0.00";
                        Microsoft.Office.Interop.Excel.Range rango444 = aplicacion.Worksheets.get_Item(2).Range["A" + (R + 6) + "", "D" + (R + 6) + ""];
                        rango444.Borders.LineStyle = BorderStyle.FixedSingle; 
                        /*-------------------------------------------------------------------------------------------------------*/
                        F1 = F1 + 1;
                    }
                }
                /*----------------------------------------------------------------------------------------------*/
                hoja_trabajoX.Cells[F1 + 7, 3] = "TOTAL Payment";
                hoja_trabajoX.Cells[F1 + 7, 4] = "=sum(D6:D" + (F1 + 6) + ")";
                Microsoft.Office.Interop.Excel.Range rangos55 = aplicacion.Worksheets.get_Item(2).Range["A5", "D5"];
                rangos55.Columns.ColumnWidth = 28.75;
                rangos55.RowHeight = 27.75;
                rangos55.Columns.WrapText = true;
                rangos55.Borders.LineStyle = BorderStyle.FixedSingle;
                rangos55.Interior.Color = Color.DarkBlue;
                rangos55.Font.Color = Color.White;
                rangos55.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rangos55.Font.Bold = true;
                Microsoft.Office.Interop.Excel.Range rango777 = aplicacion.Worksheets.get_Item(2).Range["A" + (F1 + 7) + "", "D" + (F1 + 7) + ""];
                rango777.Interior.Color = Color.DarkBlue;
                rango777.Font.Bold = true;
                rango777.Font.Color = Color.White;
                rango777.NumberFormat = "#,##0.00";
                rango777.Borders.LineStyle = BorderStyle.FixedSingle;
                /*----------------------------------------------------------------------------------------------*/
            }
            /*==================================================================================================================================================================================*/
            /*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*===================================================================================================================================================================================*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*-------------------Export To Excel-----------------------------------------------------------------------------*/
        public  void ExportarExcelDataTable(System.Data.DataTable dt, string RutaExcel)
        {
            const string FIELDSEPARATOR = "\t";
            const string ROWSEPARATOR = "\n";
            StringBuilder output = new StringBuilder(); 
            foreach (DataColumn dc in dt.Columns)
            {
                output.Append(dc.ColumnName + ",");
                output.Append(FIELDSEPARATOR);
            }
            output.Append(ROWSEPARATOR);
            foreach (DataRow item in dt.Rows)
            {
                foreach (object value in item.ItemArray)
                {
                    output.Append(value.ToString().Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ') + ",");
                    output.Append(FIELDSEPARATOR);
                }
                // Escribir una línea de registro        
                output.Append(ROWSEPARATOR);
            }
            // Valor de retorno    
            // output.ToString();
            StreamWriter sw = new StreamWriter(RutaExcel);
            sw.Write(output.ToString());
            sw.Close();
        }
        /*=====================================================================================================================================================================*/
    }
}
