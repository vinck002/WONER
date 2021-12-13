using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace Evolution.General
{
   public class ReportProvisionOwner
    {
        public void ExportarEXCELL(DataTable DV, string SalesFloor, string DateRange1, string DateRange2,/* int Option1,*/ string LIQUIDACION_MENSUALIDADES_VENTAS = "PROVISION DE OWNER")
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = /*(Microsoft.Office.Interop.Excel.Worksheet)*/WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A7", "A" + DV.Rows.Count + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0;



            for (int R = 0; R <= DV.Rows.Count; R++)
            {
                if (R == 0)
                {
                    hoja_trabajo.Cells[R + 6, 1] = "Contracto No";
                    hoja_trabajo.Cells[R + 6, 2] = "NAME";
                    hoja_trabajo.Cells[R + 6, 3] = "Fecha";
                    hoja_trabajo.Cells[R + 6, 4] = "Ventas Netas";
                    hoja_trabajo.Cells[R + 6, 5] = "CC";
                    hoja_trabajo.Cells[R + 6, 6] = "ADM";
                    hoja_trabajo.Cells[R + 6, 7] = "Payment %";
                    hoja_trabajo.Cells [R + 6, 8] = "Sales Distribution";
                    hoja_trabajo.Cells [R + 6, 9] = "Dstribution Tax + Closing ";
                    hoja_trabajo.Cells [R + 6, 10] = "Activation Date ";
                    
                    /*-----------------------Parametro--------------------------------------*/
                    hoja_trabajo.Cells [R + 1, 1] = "Reporte";
                    hoja_trabajo.Cells [R + 2, 1] = "Sala De Ventas";
                    hoja_trabajo.Cells [R + 3, 1] = "Rango De Fecha";
                    hoja_trabajo.Cells [R + 1, 2] = LIQUIDACION_MENSUALIDADES_VENTAS;
                    hoja_trabajo.Cells [R + 2, 2] = SalesFloor;
                    hoja_trabajo.Cells [R + 3, 2] = DateRange1;
                    hoja_trabajo.Cells [R + 3, 3] = DateRange2;
                    /*-----------------------Formaro MergeCellse de cada Grupo------------------------------------------*/
                    hoja_trabajo.Cells [R + 5, 8] = "PROVISION";

                    Microsoft.Office.Interop.Excel.Range rangoG1 = aplicacion.Range["H5", "I5"];
                    rangoG1.MergeCells  = true;
                    rangoG1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rangoG1.Font.Bold = true;
                    rangoG1.Font.Size = 14;
                    rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
                   
                   
                    /*--------------------------------------------------------------------------------------------*/
                }
                else
                {
                 /*----------------------------------------------------------------------------*/
                    hoja_trabajo.Cells [R + 6, 1] = DV.Rows[R1] ["AgreementNumber"] .ToString();
                    hoja_trabajo.Cells [R + 6, 2] = DV.Rows[R1] ["Name"] .ToString();
                    hoja_trabajo.Cells [R + 6, 3] = DV.Rows[R1] ["ContractDate"] .ToString();
                    hoja_trabajo.Cells [R + 6, 4] = DV.Rows[R1] ["NetSale"] .ToString();
                    hoja_trabajo.Cells [R + 6, 5] = DV.Rows[R1] ["Cc"] .ToString();
                    hoja_trabajo.Cells [R + 6, 6] = DV.Rows[R1] ["ADM"] .ToString();
                    hoja_trabajo.Cells [R + 6, 7] = DV.Rows[R1]["PAYMENT_PERCENT"].ToString();
                    hoja_trabajo.Cells [R + 6, 8] = DV.Rows[R1]["DISTRIBUTION_SALES"].ToString();
                    hoja_trabajo.Cells [R + 6, 9] = DV.Rows[R1]["DISTRIBUTION_TAXCC"].ToString();
                    hoja_trabajo.Cells [R + 6, 10] = DV.Rows[R1]["ACTIVATION_DATE"].ToString();
                   


                    /*--------------Formato por cada linea----------------------------------------------------*/
               
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["D" + (R + 6) + "", "I" + (R + 6) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 6) + "", "J" + (R + 6) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;

                    Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (R + 6) + "", "J" + (R + 6) + ""];
                    
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                }
            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6", "J6"];
            
            rangos.Columns.ColumnWidth = 12;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.LightGoldenrodYellow;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A" + (R1 + 8) + "", "J" + (R1 + 8) + ""];
            rango2.Interior.Color = Color.LightGoldenrodYellow;
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells [R1 + 8, 1] = "TOTAL";
            hoja_trabajo.Cells [R1 + 8, 4] = "=sum(D7:D" + (R1 + 7) + ")";
            hoja_trabajo.Cells [R1 + 8, 5] = "=sum(E7:E" + (R1 + 7) + ")";
            hoja_trabajo.Cells [R1 + 8, 6] = "=sum(F7:F" + (R1 + 7) + ")";
            //hoja_trabajo.Cells [R1 + 8, 7] = "=sum(G7:G" + (R1 + 7) + ")";
            hoja_trabajo.Cells [R1 + 8, 8] = "=sum(H7:H" + (R1 + 7) + ")";
            hoja_trabajo.Cells [R1 + 8, 9] = "=sum(I7:I" + (R1 + 7) + ")";
           
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG5 = aplicacion.Range["H6", "I6"];
            rangoG5.Interior.Color = Color.LightGreen;
            rangos.EntireColumn.AutoFit();
    
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
