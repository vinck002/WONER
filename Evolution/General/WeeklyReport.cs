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
using System.IO;

namespace Evolution.General
{
  public  class WeeklyReport
    { /*==========================================================================================================================================================================*/
        public void ExportarGridview(DataView DV, string SalesFloor, string DateRange1, string DateRange2,int SalesFloorID)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range["A1"];
            rangoA1.Columns.ColumnWidth = 33.71;
                    Microsoft.Office.Interop.Excel.Range rangoAK = aplicacion.Range["A5","K5"];
                    rangoAK.Interior.Color = Color.LightCyan;
                    rangoAK.Font.Bold = true;
                    rangoAK.Rows.RowHeight = 30;
                    rangoAK.WrapText = true;   
                    rangoAK.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoAK.Borders.LineStyle = BorderStyle.FixedSingle;
                    rangoAK.VerticalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rangoBK1 = aplicacion.Range["B1","K1"];
                    rangoBK1.Columns.ColumnWidth = 15;
                    rangoBK1.WrapText = true;
                    rangoBK1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["D6", "D" + DV.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["A1"]; /*formato al nombre de la compañia*/
            rango155.Font.Bold = true;
            rango155.Font.Size = 16;
            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0,Records=0,RecordRead=0;
            for (int R = 0; R <= DV.Count; R++)
            {
                if (R == 0)
                {
                    hoja_trabajo.Cells[R + 5, 1] = "Miembro";
                    hoja_trabajo.Cells[R + 5, 2] = "Fecha Contracto";
                    hoja_trabajo.Cells[R + 5, 3] = "Concepto";
                    hoja_trabajo.Cells[R + 5, 4] = "Contracto #";
                    hoja_trabajo.Cells[R + 5, 5] = "Valor Contracto";
                    hoja_trabajo.Cells[R + 5, 6] = "% Pagado Por Cliente";
                    hoja_trabajo.Cells[R + 5, 7] = "Downpayment Realizado";
                    hoja_trabajo.Cells[R + 5, 8] = "Pagos Adicionales";
                    hoja_trabajo.Cells[R + 5, 9] = ((SalesFloorID == 5 || SalesFloorID == 16) ? "Pagar a Media & Design" : "Pagar a DPM SALES");
                    hoja_trabajo.Cells[R + 5, 10] = "Comision a Pagar";
                    hoja_trabajo.Cells[R + 5, 11] = "Comentarios";
                    /*-----------------------Parametro--------------------------------------*/
                    hoja_trabajo.Cells[R + 1, 1] = ((SalesFloorID == 5 || SalesFloorID == 16)? "MEDIA & DESIGN, S.A.U." : "DPM SALES & MARKETING, S.L.U.") +" - "+ SalesFloor;
                    hoja_trabajo.Cells[R + 2, 1] = "LIQUIDACION SEMANAL";
                    hoja_trabajo.Cells[R + 3, 1] = "Semana Del "+ DateRange1+ " Hasta" + " " + DateRange2;
                  
                    /*--------------------------------------------------------------------------------------------*/
                }
                else
                {
                    Records = R;
                    RecordRead = ((R == 1) ? 0 : RecordRead + 1);
                    R =  ((R == 1) ? 1 : R+RecordRead);
                    RecordRead = RecordRead + 1;
                    /*----------------------------------------------------------------------------*/
                    decimal PayReceived = 0, PaySales = 0,PayClosing=0,PayTax = 0,NetSales1=0;
                    String EvoStatus = "",NoPayment="";
                    EvoStatus = DV.Table.Rows[R1]["EvoStatus"].ToString();
                    NoPayment = DV.Table.Rows[R1]["EvoStatus2"].ToString();
                    NetSales1 = decimal.Parse(DV.Table.Rows[R1]["Netsales"].ToString());
                    PayReceived = decimal.Parse( DV.Table.Rows[R1]["payments_received"].ToString());
                    PayReceived = ((NoPayment == "0") ? 0 : PayReceived); 
                    PayClosing = decimal.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString());
                    PayTax = decimal.Parse(DV.Table.Rows[R1]["Tax"].ToString());
                    PaySales = ((PayReceived - (PayClosing + PayTax) > 0)? PayReceived - (PayClosing + PayTax) : 0);
                    String SignoCC = "", SignoTax = "";
                    SignoCC = ((PayTax >0)? ((decimal.Parse(DV.Table.Rows[R1]["CC_Value"].ToString())<=100)? "%" : "") : "");
                    SignoTax = ((decimal.Parse(DV.Table.Rows[R1]["Tax_Value"].ToString()) <= 100) ? "%" : "");
                    /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 1] = DV.Table.Rows[R1]["MemberName"].ToString();
                    hoja_trabajo.Cells[R + 5, 2] = DV.Table.Rows[R1]["contractdate"].ToString();
                    hoja_trabajo.Cells[R + 5, 3] = "Membresia";//DV.Rows[R1].Cells["Netsales"].Value.ToString();
                    /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
                    hoja_trabajo.Cells[R + 5 + 1, 3] = "Cierre";
                    hoja_trabajo.Cells[R + 5 + 2, 3] = ((PayTax >0)? "Admin" : "") ;
                    /*------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 4] = DV.Table.Rows[R1]["AgreementNumber"].ToString();
                    hoja_trabajo.Cells[R + 5 + 1, 4] = ((PayTax >0)?"" :"Exit");
                    hoja_trabajo.Cells[R + 5, 5] = ((PayReceived < PayClosing) ? "0" : DV.Table.Rows[R1]["Netsales"].ToString());
                    /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
                    hoja_trabajo.Cells[R + 5+1, 5] = ((PayReceived < PayClosing) ? "0" : DV.Table.Rows[R1]["ClosingCost"].ToString());
                    hoja_trabajo.Cells[R + 5+2, 5] = ((PayTax > 0) ? ((PayReceived < PayClosing) ? "0" : DV.Table.Rows[R1]["Tax"].ToString()) : "");
                    /*------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 6] = ((NoPayment == "0") ? "0%" : DV.Table.Rows[R1]["payments_received_perc"].ToString() +"%"+"");
                    hoja_trabajo.Cells[R + 5, 7] = PaySales.ToString();
                    /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
                    hoja_trabajo.Cells[R + 5+1, 7] = ((PayTax > 0) ?  ((PayReceived >=PayClosing)? PayClosing.ToString() :  "0" ) : "");/*cuando son exit no llevan pago de tax ni closing*/
                    hoja_trabajo.Cells[R + 5+2, 7] = ((PayTax > 0 ) ? ((PayReceived >= (PayClosing + PayTax)) ? PayTax.ToString() : ((PayReceived >PayClosing )? Convert.ToString( PayReceived - PayClosing) : "0")) : "");
                    /*---------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 8] = "";// DV.Rows[R1].Cells["distclosingtax"].Value.ToString() ;
                    hoja_trabajo.Cells[R + 5, 9] = ((NoPayment == "0") ? "0%" : (decimal.Parse(DV.Table.Rows[R1]["ToSettle_Sales"].ToString()) / ((NetSales1==0)? 1 : decimal.Parse(DV.Table.Rows[R1]["Netsales"].ToString()))) * 100 + "%");
                    /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
                    hoja_trabajo.Cells[R + 5 + 1, 9] = ((PayTax ==0)? "" : ((NoPayment == "0") ? "0" : ((PayReceived <PayClosing)? "0" : DV.Table.Rows[R1]["CC_Value"].ToString())) + SignoCC);
                    hoja_trabajo.Cells[R + 5+2, 9] = ((PayTax == 0) ? "" : ((NoPayment == "0") ? "0" : ((decimal.Parse(DV.Table.Rows[R1]["payments_received_perc"].ToString()) < decimal.Parse(DV.Table.Rows[R1]["TAX_SETTLEMENT_PERCENTAGE"].ToString())) ? "0" : DV.Table.Rows[R1]["Tax_Value"].ToString()) + SignoTax));
                    /*---------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 10] = ((NoPayment == "0") ? "0" : DV.Table.Rows[R1]["ToSettle_Sales"].ToString());
                    /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
                    hoja_trabajo.Cells[R + 5+1, 10] = ((PayTax == 0) ? "" : ((NoPayment == "0") ? "0" : DV.Table.Rows[R1]["ClosingToSettle"].ToString()));
                    hoja_trabajo.Cells[R + 5+2, 10] = ((PayTax == 0) ? "" : ((NoPayment == "0") ? "0" : DV.Table.Rows[R1]["TaxToSettle"].ToString()));
                    /*---------------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 11] = ((NoPayment =="0")? EvoStatus : ((PayReceived < PayClosing ) ?"PENDIENTE "+NetSales1.ToString("#,##0.00") : "")); 

                    /*--------------Formato por cada linea----------------------------------------------------*/
                   
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 5) + "", "K" + (R + 5) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    rango4.Rows.RowHeight = 13.5;
                    rango4.Interior.Color = Color.Azure;
                    rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango41 = aplicacion.Range["A" + (R + 5+1) + "", "K" + (R + 5+1) + ""];
                    rango41.Rows.RowHeight = 13.5;
                    rango41.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango42 = aplicacion.Range["A" + (R + 5+2) + "", "K" + (R + 5+2) + ""];
                    rango42.Rows.RowHeight = 13.5;
                    rango42.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    /*--------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango44 = aplicacion.Range["B" + (R + 5) + "", "D" + (R + 5) + ""];
                    rango44.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                    rango44.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango412 = aplicacion.Range["B" + (R + 5 + 1) + "", "D" + (R + 5 + 1) + ""];
                    rango412.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                    rango412.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    Microsoft.Office.Interop.Excel.Range rango423 = aplicacion.Range["B" + (R + 5 + 2) + "", "D" + (R + 5 + 2) + ""];
                    rango423.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                    rango423.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R = Records;
                    R1 += 1;
                }


            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAK1 = aplicacion.Range["A" + ((R1 * 3) + 7) + "", "K" + ((R1 * 3) + 7) + ""];
            rangoAK1.NumberFormat = "#,##0.00";
            rangoAK1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK1.Interior.Color = Color.LightCyan;
            rangoAK1.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangoAK1.Font.Bold = true;
            /*--------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[(R1*3) + 7, 1] = "Total";
            hoja_trabajo.Cells[(R1 * 3) + 7, 5] = "=Sum(E6:E" + ((R1 * 3) + 6) + "";
            hoja_trabajo.Cells[(R1 * 3) + 7, 7] = "=Sum(G6:G" + ((R1 * 3) + 6) + "";
            hoja_trabajo.Cells[(R1 * 3) + 7, 10] = "=Sum(J6:J"+ ((R1 * 3) +6) +"";
            hoja_trabajo.Cells[(R1 * 3) + 9, 9] = "Total a Pagar";
            hoja_trabajo.Cells[(R1 * 3) + 9, 10] = "=J" + ((R1 * 3) + 7) + "";
            hoja_trabajo.Cells[(R1 * 3) + 12, 1] = "Preparado Por:";
            hoja_trabajo.Cells[(R1 * 3) + 12, 4] = "Revisado Por:";
            hoja_trabajo.Cells[(R1 * 3) + 12, 8] = "Aprobado Por:";
          
            /*-----------------------------Formato de Borde-----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangosuma = aplicacion.Range["I"+ ((R1 * 3) + 9) + "", "I" + ((R1 * 3) + 9) + ""];
            rangosuma.Interior.Color = Color.LightCyan;
            rangosuma.Font.Bold = true;
            rangosuma.Rows.RowHeight = 17;
            rangosuma.WrapText = true;
            rangosuma.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangosuma.Borders.LineStyle = BorderStyle.FixedSingle;
            rangosuma.VerticalAlignment = XlHAlign.xlHAlignCenter;
            /*-------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangomonto = aplicacion.Range["J" + ((R1 * 3) + 9) + "", "J" + ((R1 * 3) + 9) + ""];
            rangomonto.Font.Bold = true;
            rangomonto.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangomonto.Borders.LineStyle = BorderStyle.FixedSingle;
            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["E5", "E" + ((R1 * 3) + 7) + ""];
            rango3.NumberFormat = "#,##0.00";
            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango31 = aplicacion.Range["G5", "g" + ((R1 * 3) + 7) + ""];
            rango31.NumberFormat = "#,##0.00";
            /*----------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango32 = aplicacion.Range["J5", "J" + ((R1 * 3) + 7) + ""];
            rango32.NumberFormat = "#,##0.00";
            /*--------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoK1 = aplicacion.Range["K5", "K" + ((R1 * 3) + 7) + ""];
            rangoK1.Columns.ColumnWidth = 20.71;
            /*-------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango414 = aplicacion.Range["A" + ((R1 * 3) + 5) + "", "A" + ((R1 * 3) + 12) + ""];
            rango414.Rows.RowHeight = 13.5;
            rango414.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango424 = aplicacion.Range["A" + ((R1 * 3) + 5) + "", "K" + ((R1 * 3) + 12) + ""];
            rango424.Font.Bold = true;
            /*------------------------------------------------------*/
            hoja_trabajo.get_Range("A5:A" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("A5:A" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = true;
            hoja_trabajo.get_Range("B5:B" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("C5:C" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("D5:D" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("E5:E" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("F5:F" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("G5:G" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("H5:H" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("I5:I" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("J5:J" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            hoja_trabajo.get_Range("K5:K" + ((R1 * 3) + 7) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = true;
            /*----------------------------------------------------------------------------------*/
            hoja_trabajo.get_Range("A"+ ((R1 * 3) + 12) + ":B" + ((R1 * 3) + 12) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("D"+ ((R1 * 3) + 12) +":F" + ((R1 * 3) + 12) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("H"+ ((R1 * 3) + 12)+":J" + ((R1 * 3) + 12) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Weekly Report";
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
/*==========FINAL===============================================================================================================================================================================*/
    }
}
