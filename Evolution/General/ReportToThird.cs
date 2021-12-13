using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;

namespace Evolution.General
{
   public class ReportToThird
    {
        /*==========================================================================================================================================================================*/
        public void ExportarGridview(RadGridView DV,string SalesFloor,string DateRange1,string DateRange2,int Option1,string  LIQUIDACION_MENSUALIDADES_VENTAS = "LIQUIDACION MENSUALIDADES Y VENTAS")
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = /*(Microsoft.Office.Interop.Excel.Worksheet)*/WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A7", "A"+DV.RowCount + 1 +""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0;
            double Percent = 0,TotalDistCCTax=0;
           

            for (int R = 0; R <= DV.RowCount; R++)
            {
                if (R == 0)
                {
                     hoja_trabajo.Cells[R + 6, 1] = "Contracto No";
                    hoja_trabajo.Cells[R + 6, 2] = "Fecha";
                    hoja_trabajo.Cells[R + 6, 3] = "Nombre Del Cliente";
                    hoja_trabajo.Cells[R + 6, 4] = "Ventas Netas";
                    hoja_trabajo.Cells[R + 6, 5] = "CC";
                    hoja_trabajo.Cells[R + 6, 6] = "ADM";
                    hoja_trabajo.Cells[R + 6, 7] = "Ventas";
                    hoja_trabajo.Cells[R + 6, 8] = "CC /ADM";
                    hoja_trabajo.Cells[R + 6, 9] = "Ajustes Prop. Cancelacion/Nulo";
                    hoja_trabajo.Cells[R + 6, 10] = "Pagos Recibidos";
                    hoja_trabajo.Cells[R + 6, 11] = "%";
                    hoja_trabajo.Cells[R + 6, 12] = "CxC Clientes";
                    hoja_trabajo.Cells[R + 6, 13] = "Ajuste CxC Cancelacion/Nulo";
                    hoja_trabajo.Cells[R + 6, 14] = "Venta";
                    hoja_trabajo.Cells[R + 6, 15] = "ADM";
                    hoja_trabajo.Cells[R + 6, 16] = "Venta";
                    hoja_trabajo.Cells[R + 6, 17] = "ADM";
                    hoja_trabajo.Cells[R + 6, 18] = "Venta";
                    hoja_trabajo.Cells[R + 6, 19] = "ADM";
                    hoja_trabajo.Cells[R + 6, 20] = "Status";
                    hoja_trabajo.Cells[R + 6, 21] = "Comentario";
                    /*-----------------------Parametro--------------------------------------*/
                    hoja_trabajo.Cells[R + 1, 1] = "Reporte";
                    hoja_trabajo.Cells[R + 2, 1] = "Sala De Ventas";
                    hoja_trabajo.Cells[R + 3, 1] = "Rango De Fecha";
                    hoja_trabajo.Cells[R + 1, 2] = LIQUIDACION_MENSUALIDADES_VENTAS;
                    hoja_trabajo.Cells[R + 2, 2] = SalesFloor;
                    hoja_trabajo.Cells[R + 3, 2] = DateRange1;
                    hoja_trabajo.Cells[R + 3, 3] = DateRange2;
                    /*-----------------------Formaro Merge de cada Grupo------------------------------------------*/
                    hoja_trabajo.Cells[R + 5, 7] = "Propietario";
                    hoja_trabajo.Cells[R + 5, 14] = "Liquidado";
                    hoja_trabajo.Cells[R + 5, 16] = "A Liquidar";
                    hoja_trabajo.Cells[R + 5, 18] = "Por Liquidar";
                    Microsoft.Office.Interop.Excel.Range rangoG1 = aplicacion.Range["G5", "H5"];
                    rangoG1.MergeCells = true;
                    rangoG1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoG1.Font.Bold = true;
                    rangoG1.Font.Size = 14;
                    rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
                    Microsoft.Office.Interop.Excel.Range rangoG2 = aplicacion.Range["N5", "O5"];
                    rangoG2.MergeCells = true;
                    rangoG2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoG2.Font.Bold = true;
                    rangoG2.Font.Size = 14;
                    rangoG2.Borders.LineStyle = BorderStyle.FixedSingle;
                    Microsoft.Office.Interop.Excel.Range rangoG3 = aplicacion.Range["P5", "Q5"];
                    rangoG3.MergeCells = true;
                    rangoG3.Interior.Color = Color.LightGreen;
                    rangoG3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoG3.Font.Bold = true;
                    rangoG3.Font.Size = 14;
                    rangoG3.Borders.LineStyle = BorderStyle.FixedSingle;
                    Microsoft.Office.Interop.Excel.Range rangoG4 = aplicacion.Range["R5", "S5"];
                    rangoG4.MergeCells = true;
                    rangoG4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoG4.Font.Bold = true;
                    rangoG4.Font.Size = 14;
                    rangoG4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*--------------------------------------------------------------------------------------------*/
                }
                else
                {
                    Percent = double.Parse(DV.Rows[R1].Cells["paymentpercent"].Value.ToString()); /*iniciarlizar el porciento para validar distribution sales*/
                    TotalDistCCTax = ((Percent >=25)? 0 : double.Parse(DV.Rows[R1].Cells["settledsales"].Value.ToString()) + double.Parse(DV.Rows[R1].Cells["settledtaxclosing"].Value.ToString()) 
                        + double.Parse(DV.Rows[R1].Cells["tosettlesales"].Value.ToString()) + double.Parse(DV.Rows[R1].Cells["tosettletaxclosing"].Value.ToString()) );
                    /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells[R + 6, 1] = DV.Rows[R1].Cells["AgreementNumber"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 2] = DV.Rows[R1].Cells["contractdate"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 3] = DV.Rows[R1].Cells["name"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 4] = DV.Rows[R1].Cells["netsales"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 5] = DV.Rows[R1].Cells["closingcost"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 6] =  DV.Rows[R1].Cells["tax"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 7] = ((Option1==1)? DV.Rows[R1].Cells["distsales"].Value.ToString() :((Percent >= 25) ? DV.Rows[R1].Cells["distsales"].Value.ToString() : "0"));
                    hoja_trabajo.Cells[R + 6, 8] = ((Option1 == 1) ? DV.Rows[R1].Cells["distclosingtax"].Value.ToString():((Percent >= 25) ? DV.Rows[R1].Cells["distclosingtax"].Value.ToString() : TotalDistCCTax.ToString()));
                    hoja_trabajo.Cells[R + 6, 9] = "";
                    hoja_trabajo.Cells[R + 6, 10] = DV.Rows[R1].Cells["paymentreceived"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 11] = DV.Rows[R1].Cells["paymentpercent"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 12] = DV.Rows[R1].Cells["accountreceive"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 13] = "";
                    hoja_trabajo.Cells[R + 6, 14] = DV.Rows[R1].Cells["settledsales"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 15] =  DV.Rows[R1].Cells["settledtaxclosing"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 16] = DV.Rows[R1].Cells["tosettlesales"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 17] = DV.Rows[R1].Cells["tosettletaxclosing"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 18] = ((Option1 == 1)? DV.Rows[R1].Cells["pendingtosales"].Value.ToString():((Percent >= 25) ? DV.Rows[R1].Cells["pendingtosales"].Value.ToString() : "0"));
                    hoja_trabajo.Cells[R + 6, 19] = ((Option1 == 1) ? DV.Rows[R1].Cells["pendingtotaxclosing"].Value.ToString():((Percent >= 25) ? DV.Rows[R1].Cells["pendingtotaxclosing"].Value.ToString() : "0"));
                    hoja_trabajo.Cells[R + 6, 20] = DV.Rows[R1].Cells["AccountStatus"].Value.ToString();
                    hoja_trabajo.Cells[R + 6, 21] = "";


                    /*--------------Formato por cada linea----------------------------------------------------*/
                    if (DV.Rows[R1].Cells["NCGuarantee"].Value.ToString() == "1")/*cuando tiene nota de credito de garantia pintar la celda del contracto*/
                    {
                        Microsoft.Office.Interop.Excel.Range rangon3 = aplicacion.Range["A" + (R + 6) + "", "A" + (R + 6) + ""];
                        rangon3.Interior.Color = Color.Lime;
                    }
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["D" + (R + 6) + "", "S" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "U" + (R + 6) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                }
            }
            /*--------------------------Formato------------------------------------------------------------*/
           Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6","U6"];
            rangos.Columns.ColumnWidth = 12;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.LightGoldenrodYellow;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A"+(R1+ 8)+"", "U" + (R1 + 8) + ""];
            rango2.Interior.Color = Color.LightGoldenrodYellow;
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 8, 1] = "TOTAL";
            hoja_trabajo.Cells[R1 + 8, 4] = "=sum(D7:D" + (R1 + 7) + ")"; 
            hoja_trabajo.Cells[R1 + 8, 5] = "=sum(E7:E" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 6] = "=sum(F7:F" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 7] = "=sum(G7:G" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 8] = "=sum(H7:H" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 10] = "=sum(I7:I" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 11] = "=sum(J7:J" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 12] = "=sum(L7:L" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 14] = "=sum(N7:N" + (R1 + 7 )  + ")";
            hoja_trabajo.Cells[R1 + 8, 15] = "=sum(O7:O" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 16] = "=sum(P7:P" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 17] = "=sum(Q7:Q" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 18] = "=sum(R7:R" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 8, 19] = "=sum(S7:S" + (R1 + 7) + ")";
            hoja_trabajo.Cells[R1 + 9, 14] = "TOTAL A PAGAR PROPIETARIA USD";
            hoja_trabajo.Cells[R1 + 9, 16] = "=sum(P"+(R1 + 8)+":Q" + (R1 + 8) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG5 = aplicacion.Range["P6", "Q6"];
            rangoG5.Interior.Color = Color.LightGreen;
            Microsoft.Office.Interop.Excel.Range rangoG6 = aplicacion.Range["N" + (R1 + 9) + ", O" + (R1 + 9) + ""];
            rangoG6.MergeCells = true;
            rangoG6.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG6.Font.Bold = true;
            rangoG6.Font.Size = 12;
            rangoG6.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG7 = aplicacion.Range["M" + (R1 + 9) + ", Q" + (R1 + 9) + ""];
            rangoG7.MergeCells = true;
            rangoG7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG7.Font.Bold = true;
            rangoG7.Font.Size = 12;
            rangoG7.Borders.LineStyle = BorderStyle.FixedSingle;
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
             System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }

        /*===========================================================================================================================================================================*/

    }
}
