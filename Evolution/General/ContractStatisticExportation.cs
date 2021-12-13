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
  public   class ContractStatisticExportation
    {
        public  void ExportContractStatistic(DataView DV,DateTime StartDate,DateTime EndDate,int ReportType,DataView DvCompany,string CompanyID,int summary )
        {
            /*----------------------------------------------------------------------------------------*/
            if (DV.Count <= 0) { MessageBox.Show("No Record Found", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);
            int DvCount = 0;
            /*----------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[2, 1] = "Description";
            hoja_trabajo.Cells[2,  2] = "Company";
            if(summary == 0) { hoja_trabajo.Cells[2, 3] = "Membership Amount"; }
            if (ReportType == 1)
            {
                for (int month = 0; month <= int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()); month++)
                {
                    Microsoft.Office.Interop.Excel.Range rng = hoja_trabajo.Cells[ 2, month + ((summary == 1)? 3 : 4)];
                    rng.NumberFormat = "@";
                    rng.Interior.Color = Color.FromArgb(185, 253, 187);
                    rng.Font.Color = Color.FromArgb(5, 195, 10);
                    rng.Font.Bold = true;
                    rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng.Borders.LineStyle = BorderStyle.FixedSingle;
                    hoja_trabajo.Cells[2, month + ((summary == 1) ? 3 : 4)] = StartDate.AddMonths(month).ToString("MMM") + "-" + StartDate.AddMonths(month).Year.ToString();
                  
                }
                hoja_trabajo.Cells[2, int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + ((summary == 1) ? 4 : 5)] = "TOTAL";
                if (summary == 0) { hoja_trabajo.Cells[2, int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 6] = "Total % Paid"; }
            }
            else
            {
                if (CompanyID != "") { DvCompany.RowFilter = $"TypeID in({CompanyID})"; }
                DvCompany.Sort = "Description";
                int month = 0;
                foreach (DataRowView dr in DvCompany)
                {
                    Microsoft.Office.Interop.Excel.Range rng = hoja_trabajo.Cells[2, month + ((summary == 1) ? 3 : 4)];
                    rng.NumberFormat = "@";
                    rng.Interior.Color = Color.FromArgb(185, 253, 187);
                    rng.Font.Color = Color.FromArgb(5, 195, 10);
                    rng.Font.Bold = true;
                    rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rng.Borders.LineStyle = BorderStyle.FixedSingle;
                    hoja_trabajo.Cells[2, month + ((summary == 1) ? 3 : 4)] = dr["Description"].ToString();
                    month++;
                }
                hoja_trabajo.Cells[2, DvCompany.Count + ((summary == 1) ? 3 : 4)] = "TOTAL";
                if (summary == 0) { hoja_trabajo.Cells[2, DvCompany.Count + 5] = "Total % Paid"; }
                DvCount = DvCompany.Count;
                if (CompanyID != "") { DvCompany.RowFilter = ""; }
            }
            /*-----------------------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango154 = aplicacion.Range[$"A3:B{DV.Count + 2000}"];
            rango154.NumberFormat = "@";
            Microsoft.Office.Interop.Excel.Range rango155 = aplicacion.Range[$"C3:Z{DV.Count + 2000}"];
            rango155.NumberFormat = "#,##0.00";
            /*---------------------------------------------------------------*/
            int Row = 0,RowNo=0;
            string GroupName = "", GroupName2="";
            /*----------------------------------------------------------------------------*/
            for (int R = 0; R < DV.Count; R++)
            {
                RowNo = int.Parse(DV.Table.Rows[R]["RowNo"].ToString());
                if (GroupName != DV.Table.Rows[R]["GroupName"].ToString()) 
                {
                    Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range[$"A{3 + Row }"];
                    rango1.Interior.Color = Color.FromArgb(68, 114, 196);
                    rango1.Font.Color = Color.White;
                    rango1.Font.Bold = true;
                    hoja_trabajo.Cells[3+ Row , 1] = DV.Table.Rows[R]["GroupName"].ToString();
                    GroupName = DV.Table.Rows[R]["GroupName"].ToString();
                    GroupName2 = "";
                   
                }
                else
                {
                    if (summary ==0) { hoja_trabajo.Cells[3 + Row, 1] = DV.Table.Rows[R]["GroupName"].ToString(); }
                }
                if (GroupName2 != DV.Table.Rows[R]["GroupName2"].ToString())
                {
                    hoja_trabajo.Cells[Row + 3 , 2] = DV.Table.Rows[R]["GroupName2"].ToString();
                    GroupName2 = DV.Table.Rows[R]["GroupName2"].ToString();
                    Row++;
                   
                }
                if (summary == 0) { hoja_trabajo.Cells[Row + 2, 3] = DV.Table.Rows[R]["MembershipPrice"].ToString(); }
                hoja_trabajo.Cells[Row + 2  , RowNo + ((summary ==1)? 2 : 3)] = DV.Table.Rows[R]["Amount"].ToString();
                if (summary == 1)
                {
                    hoja_trabajo.Cells[Row + 2, ((ReportType == 2) ? DvCount + 3 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 4)] = $"=sum(C{Row + 2}:{Columna(Row + 2, ((ReportType == 2) ? DvCount + 2 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 3))})";
                }
                else 
                {
                    hoja_trabajo.Cells[Row + 2, ((ReportType == 2) ? DvCount + 4 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 5)] = $"=sum(D{Row + 2}:{Columna(Row + 2, ((ReportType == 2) ? DvCount + 3 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 4))})";
                    hoja_trabajo.Cells[Row + 2, ((ReportType == 2) ? DvCount + 5 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 6)] = $"=({Columna(Row + 2, ((ReportType == 2) ? DvCount + 4 : int.Parse(DV.Table.Rows[0]["MontnNo"].ToString()) + 5))} / C{Row + 2} ) *100";
                }
            }
            /*--------------------------Suma y formato------------------------------------------------------------*/
           

            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Contract Statitistic";
            hoja_trabajo.Cells.EntireColumn.AutoFit();
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*-------------------------------------------------------------------------*/
        public static string Columna(int rowexcel, int Number) 
        {
            string columnName = "";
            List<Columnas> lista = new List<Columnas>() {
            new Columnas {Id=3, columna="C" },
            new Columnas {Id=4, columna="D" },
            new Columnas {Id=5, columna="E" },
            new Columnas {Id=6, columna="F" },
            new Columnas {Id=7, columna="G" },
            new Columnas {Id=8, columna="H" },
            new Columnas {Id=9, columna="I" },
            new Columnas {Id=10, columna="J" },
            new Columnas {Id=11, columna="K" },
            new Columnas {Id=12, columna="L" },
            new Columnas {Id=13, columna="M" },
            new Columnas {Id=14, columna="N" },
            new Columnas {Id=15, columna="O" },
            new Columnas {Id=16, columna="P" },
            new Columnas {Id=17, columna="Q" },
            new Columnas {Id=18, columna="R" },
            new Columnas {Id=19, columna="S" },
            new Columnas {Id=20, columna="T" },
            new Columnas {Id=21, columna="U" },
            new Columnas {Id=22, columna="V" },
            new Columnas {Id=23, columna="W" },
            new Columnas {Id=24, columna="X" },
            new Columnas {Id=25, columna="Y" },
            new Columnas {Id=26, columna="Z" },
            new Columnas {Id=27, columna="AA" },
            new Columnas {Id=28, columna="AB" },
            new Columnas {Id=29, columna="AC" },
            new Columnas {Id=30, columna="AD" },
            };
            var rep = lista.FirstOrDefault(x=> x.Id == Number);
            columnName = rep.columna+""+ rowexcel.ToString();
            return columnName;
        }
        public  class Columnas 
        {
            public  int Id { get; set; }
            public  string columna { get; set; }
        }
    }
}
