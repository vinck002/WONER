using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace Evolution.General
{
 public static   class AnnualSettlementSummary
    {
        public static void ExportarSummary(DataView DV,DateTime Date1, DateTime Date2 )
        {
            /*----------------------------------------------------------------------------------------*/
            if (DV.Count <= 0) { MessageBox.Show("No Record Found", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) WBook.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range["A2:S2"];
            rangoA1.Columns.ColumnWidth = 12;
            rangoA1.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoA1.Interior.Color = Color.FromArgb(169, 208, 142);

            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango154 = aplicacion.Range["A1:Z2"];
            rango154.NumberFormat = "@";
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range["A3:Z100"];
            rango155.NumberFormat = "#,##0.00";
            /*-----------------------------------------------------------------------------------------------------*/
            for(int m=0; m<=11; m++)
            {
                hoja_trabajo.Cells[2, m + 2] = Date1.AddMonths(m).ToString("MMM") + "-" + Date1.AddMonths(m).Year.ToString();
            }
            hoja_trabajo.Cells[2, 14] = "Total Liquidado";
            /*-----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[2, 17] = "% Pagado";
            hoja_trabajo.Cells[1, 18] = "Faltante para";
            hoja_trabajo.Cells[2, 18] = "Meta";
            hoja_trabajo.Cells[1, 19] = "% Faltante";
            hoja_trabajo.Cells[2, 19] = "Para Meta";
            /*------------------------Mensuales----------------------------------------------------*/
            int R = 0, Rw=3;
            DV.RowFilter = "Type=1";
            hoja_trabajo.Cells[2, 16] = ((DV.Count > 0) ? DV.Table.Rows[0]["YearNo"].ToString() : "");
            string Enterprise = ((DV.Count > 0) ? DV.Table.Rows[0]["Enterprise"].ToString() : "");
            hoja_trabajo.Cells[1, 2] = Enterprise;
            Microsoft.Office.Interop.Excel.Range range1 = aplicacion.Range["B1:M1"];
            range1.Font.Bold = true;
            range1.Merge();
            /*---------------------------------------------------------------------------------------*/
            foreach (DataRowView RV in DV)
            {
                if (Enterprise != RV["Enterprise"].ToString())
                {
                    R = R + 5;
                    Enterprise = RV["Enterprise"].ToString();
                    hoja_trabajo.Cells[R, 2] = Enterprise;
                    Microsoft.Office.Interop.Excel.Range range2 = aplicacion.Range[$"A{R -1}:N{R}"];
                    range2.Font.Bold = true;
                    range2.Merge();
                    R++;
                    Microsoft.Office.Interop.Excel.Range range02 = aplicacion.Range[$"A{R}:N{R}"];
                    range02.Interior.Color = Color.FromArgb(169, 208, 142);
                    range02.NumberFormat = "@";
                    for (int m = 0; m <= 11; m++)
                    {
                        hoja_trabajo.Cells[R, m + 2] = Date1.AddMonths(m).ToString("MMM") + "-" + Date1.AddMonths(m).Year.ToString();
                    }
                    hoja_trabajo.Cells[R, 14] = "Total Liquidado";
                   
                    R = R - 2;
                    Rw = 8;
                }
                hoja_trabajo.Cells[R + 3, 1] = RV["SalesName"].ToString();
                hoja_trabajo.Cells[R + 3, 2] = RV["Montn1"].ToString();
                hoja_trabajo.Cells[R + 3, 3] = RV["Montn2"].ToString();
                hoja_trabajo.Cells[R + 3, 4] = RV["Montn3"].ToString();
                hoja_trabajo.Cells[R + 3, 5] = RV["Montn4"].ToString();
                hoja_trabajo.Cells[R + 3, 6] = RV["Montn5"].ToString();
                hoja_trabajo.Cells[R + 3, 7] = RV["Montn6"].ToString();
                hoja_trabajo.Cells[R + 3, 8] = RV["Montn7"].ToString();
                hoja_trabajo.Cells[R + 3, 9] = RV["Montn8"].ToString();
                hoja_trabajo.Cells[R + 3, 10] = RV["Montn9"].ToString();
                hoja_trabajo.Cells[R + 3, 11] = RV["Montn10"].ToString();
                hoja_trabajo.Cells[R + 3, 12] = RV["Montn11"].ToString();
                hoja_trabajo.Cells[R + 3, 13] = RV["Montn12"].ToString();
                hoja_trabajo.Cells[R + 3, 14] = $"=sum(B{R + 3}:M{R + 3})";
                hoja_trabajo.Cells[R + 3, 16] = RV["GaranteeOfYear"].ToString(); //garantia
                hoja_trabajo.Cells[R + 3, 17] = $"=(N{R + 3}/P{R + 3})*100";//porciento pagado
                hoja_trabajo.Cells[R + 3, 18] = $"=P{R + 3}-N{R + 3}";//faltante para menta
                hoja_trabajo.Cells[R + 3, 19] = $"=(R{R + 3}/P{R + 3})*100";//porciento faltante para menta
                /*-----------------------------------------------------------------------------------------*/
                Enterprise = RV["Enterprise"].ToString();
                R++;
                /*--------------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango127 = aplicacion.Range[$"A{R + 3}:M{R + 3}"];
                    rango127.Interior.Color = Color.FromArgb(169, 208, 142);
                    rango127.Font.Bold = true;
                    hoja_trabajo.Cells[R + 3, 1] = "Total";
                    hoja_trabajo.Cells[R + 3, 2] = $"=Sum(B{Rw}:B{R + 2})";
                    hoja_trabajo.Cells[R + 3, 3] = $"=Sum(C{Rw}:C{R + 2})";
                    hoja_trabajo.Cells[R + 3, 4] = $"=Sum(D{Rw}:D{R + 2})";
                    hoja_trabajo.Cells[R + 3, 5] = $"=Sum(E{Rw}:E{R + 2})";
                    hoja_trabajo.Cells[R + 3, 6] = $"=Sum(F{Rw}:F{R + 2})";
                    hoja_trabajo.Cells[R + 3, 7] = $"=Sum(G{Rw}:G{R + 2})";
                    hoja_trabajo.Cells[R + 3, 8] = $"=Sum(H{Rw}:H{R + 2})";
                    hoja_trabajo.Cells[R + 3, 9] = $"=Sum(I{Rw}:I{R + 2})";
                    hoja_trabajo.Cells[R + 3, 10] = $"=Sum(J{Rw}:J{R + 2})";
                    hoja_trabajo.Cells[R + 3, 11] = $"=Sum(K{Rw}:K{R + 2})";
                    hoja_trabajo.Cells[R + 3, 12] = $"=Sum(L{Rw}:L{R + 2})";
                    hoja_trabajo.Cells[R + 3, 13] = $"=Sum(M{Rw}:M{R + 2})";

                    Microsoft.Office.Interop.Excel.Range rangoy1 = aplicacion.Range[$"N{R + 3}:N{R + 3}"];
                    rangoy1.Interior.Color = Color.Yellow;
                    rangoy1.Font.Bold = true;
                    hoja_trabajo.Cells[R + 3, 14] = $"=Sum(N{Rw}:N{R + 2})";
                    Microsoft.Office.Interop.Excel.Range rangoy11 = aplicacion.Range[$"A1:S{R + 3}"];
                    rangoy11.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rango50 = aplicacion.Range[$"A{R + 2}:N{R + 2}"];
                rango50.Font.Bold = false;
                rango50.Interior.Color = Color.White;
            }
            /*--------------------------anuales------------------------------------------------------------*/
            R = 0;
             Rw = 0; Enterprise = ((DV.Count > 0) ? DV.Table.Rows[0]["Enterprise"].ToString() : "");
            DV.RowFilter = "";
            DV.RowFilter = "Type=2";
            int head = 0;
            string SalesName = ((DV.Count > 0)? DV.Table.Rows[0]["SalesName"].ToString() : "");
            decimal TotalGarantia = 0;
            foreach (DataRowView RV in DV)
            {
                if (SalesName != RV["SalesName"].ToString())
                {
                    R++; Rw=0; TotalGarantia = 0;
                     SalesName = RV["SalesName"].ToString();
                    
                }
                if (Enterprise != RV["Enterprise"].ToString()) {Enterprise = RV["Enterprise"].ToString(); head = head + R + 3; }

                hoja_trabajo.Cells[1 + head +((head==0)?0 : 1), 21 + Rw] = "Garantizado";
                hoja_trabajo.Cells[1 + head + ((head == 0) ? 0 : 1), 21 + Rw +1] = "Total Garantizado";
                hoja_trabajo.Cells[2 + head + ((head == 0) ? 0 : 1), 21 + Rw] = RV["YearNo"].ToString();
                hoja_trabajo.Cells[R + 3 + head - ((head == 0) ? 0 : 1), 21 + Rw] = RV["Montn1"].ToString();
                TotalGarantia = TotalGarantia + decimal.Parse(RV["Montn1"].ToString());
                hoja_trabajo.Cells[R + 3 + head - ((head == 0) ? 0 : 1), 21 + Rw + 1] = TotalGarantia;

                Microsoft.Office.Interop.Excel.Range rangox0 = hoja_trabajo.Cells[R + 3+ head, 21 + Rw];
                rangox0.Borders.LineStyle = BorderStyle.FixedSingle;
                rangox0.Font.Bold = true;
                Microsoft.Office.Interop.Excel.Range rangox2 = hoja_trabajo.Cells[R + 1+ head, 21 + Rw];
                rangox2.Borders.LineStyle = BorderStyle.FixedSingle;
                rangox2.Font.Bold = true;
                Rw++;
            }
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Annual Settlement Summary";
            hoja_trabajo.Cells.EntireColumn.AutoFit();
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    }
}
