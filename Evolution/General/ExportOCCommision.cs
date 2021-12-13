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
 public   class ExportOCCommision
    {
        public void ExportToExcel(DataView DV1)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoy2 = aplicacion.Range["B1"];
            rangoy2.Font.Bold = true;
            rangoy2.Font.Size = 16;
            Microsoft.Office.Interop.Excel.Range rangoAK = aplicacion.Range["A4", "H4"];
            rangoAK.Interior.Color = Color.DarkBlue;
            rangoAK.Font.Bold = true; rangoAK.Font.Color = Color.White;
            rangoAK.Rows.RowHeight = 30;
            rangoAK.WrapText = true;
            rangoAK.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoAK.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK.VerticalAlignment = XlHAlign.xlHAlignCenter;
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["A1:H1"]; /*formato al nombre de la compañia*/
            rango155.Columns.ColumnWidth = 20;
            /*-----------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoBK1 = aplicacion.Range["D1", "D2"];
            rangoBK1.Columns.ColumnWidth = 80;
            rangoBK1.WrapText = true;
            rangoBK1.Font.Size = 16;
            rangoBK1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A1", "A"+(DV1.Count + 10)+""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            Microsoft.Office.Interop.Excel.Range rango121 = aplicacion.Range["B1", "B" + (DV1.Count + 10) + ""];
            rango121.NumberFormat = "@";//solo texto en los contractos
            /*-----------------------------------------------------------------------------------------------------*/
            int R1 = 0, R = 0;
            hoja_trabajo.Cells[1, 2] = "Reporte Comisiones Pagadas a Tercero Owner Circle";
            hoja_trabajo.Cells[R + 4, 1] = "Contract No.";
            hoja_trabajo.Cells[R + 4, 2] = "Request Date";
            hoja_trabajo.Cells[R + 4, 3] = "OC Name";
            hoja_trabajo.Cells[R + 4, 4] = "Week Period";
            hoja_trabajo.Cells[R + 4, 5] = "Service Fee";
            hoja_trabajo.Cells[R + 4, 6] = "Nights";
            hoja_trabajo.Cells[R + 4, 7] = "Commision To Pay";
            hoja_trabajo.Cells[R + 4, 8] = "Member Period Per Year";
            R = 1;
            /*--------------------------------------------------------------------------------------------*/
            foreach (DataRowView DV in DV1)
            {
                /*----------------------------------------------------------------------------*/
                hoja_trabajo.Cells[R +4, 1] = DV["ContractNo"].ToString(); 
                hoja_trabajo.Cells[R + 4, 2] = DV["RequestDate"].ToString();
                hoja_trabajo.Cells[R + 4, 3] = DV["MemberName"].ToString();
                hoja_trabajo.Cells[R + 4, 4] = DV["WeekPeriod"].ToString();
                hoja_trabajo.Cells[R + 4, 5] = DV["ServiceFee"].ToString();
                hoja_trabajo.Cells[R + 4, 6] = DV["TotalNight"].ToString();
                hoja_trabajo.Cells[R + 4, 7] = DV["ToPay"].ToString();
                hoja_trabajo.Cells[R + 4, 8] = DV["NightPerYear"].ToString();
                /*--------------Formato por cada linea----------------------------------------------------*/

                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 4) + "", "H" + (R + 4) + ""];
                rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                rango4.Rows.RowHeight = 13.5;
                rango4.Interior.Color = Color.GhostWhite;
                rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                /*-----------------------------------*/
                Microsoft.Office.Interop.Excel.Range rango414 = aplicacion.Range["E" + (R + 4) + "", "G" + (R + 4) + ""];
                rango414.NumberFormat = "#,##0.00";        
                /*----------------------------------------------*/
                R += 1;
                R1 += 1;

            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoAK1 = aplicacion.Range["A" + (R1 + 7) + "", "H" + (R1 + 7) + ""];
            rangoAK1.NumberFormat = "#,##0.00";
            rangoAK1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoAK1.Interior.Color = Color.LightCyan;
            rangoAK1.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangoAK1.Font.Bold = true;
            /*--------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[(R1 * 1) + 7, 1] = "Total";
            hoja_trabajo.Cells[(R1 * 1) + 7, 5] = "=Sum(E5:E" + (R1 + 6) + "";
            hoja_trabajo.Cells[(R1 * 1) + 7, 7] = "=Sum(G5:G" + (R1 + 6) + "";
            /*----------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango33 = aplicacion.Range["A" + (R1 + 10) + ":H" + (R1 + 10) + ""];
            rango33.Font.Bold = true;
            hoja_trabajo.Cells[(R1 * 1) + 10, 1] = "Preparado Por:";
            hoja_trabajo.Cells[(R1 * 1) + 10, 4] = "Revisado Por:";
            hoja_trabajo.Cells[(R1 * 1) + 10, 7] = "Aprobado Por:";
            hoja_trabajo.get_Range("A" + ((R1 * 1) + 10) + ":B" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("D" + ((R1 * 1) + 10) + ":E" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            hoja_trabajo.get_Range("G" + ((R1 * 1) + 10) + ":H" + ((R1 * 1) + 10) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = true;
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Owner Circle Commision";
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*==========================================================================================================================================*/
    }
}
