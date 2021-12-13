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
  public  class VerificationSheetExport
    {
        public void ExportVS(DataView DV)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo; 
          aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet) WBook.Worksheets.get_Item(1);
            /*--------------------------Formato Columnas--------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoA = aplicacion.Range["A1", "A" + DV.Count * 18 + ""];
             rangoA.NumberFormat = "@"; //solo texto en los contractos
            rangoA.ColumnWidth = 21.8; rangoA.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rangoB = aplicacion.Range["B1", "B" + DV.Count * 15 + ""];  rangoB.ColumnWidth = 16.6; 
            Microsoft.Office.Interop.Excel.Range rangoC = aplicacion.Range["C1", "C" + DV.Count * 15 + ""]; rangoC.ColumnWidth = 16.7; rangoC.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rangoD = aplicacion.Range["D1", "D" + DV.Count * 15 + ""]; rangoD.ColumnWidth = 47.7; 
            Microsoft.Office.Interop.Excel.Range rangoE = aplicacion.Range["E1", "E" + DV.Count * 15 + ""]; rangoE.ColumnWidth = 13.7; rangoE.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rangoF = aplicacion.Range["F1", "F" + DV.Count * 15 + ""]; rangoF.ColumnWidth = 41.6; 
            Microsoft.Office.Interop.Excel.Range rangoG = aplicacion.Range["G1", "G" + DV.Count * 15 + ""]; rangoG.ColumnWidth = 7.6; rangoG.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rangoH = aplicacion.Range["H1", "H" + DV.Count * 15 + ""]; rangoH.ColumnWidth = 51.6; 
            /*-----------------------------------------------------------------------------------------------------*/
            int R = 1, Row1 = 1;
            for (int Vs = 0; Vs <= DV.Count -1; Vs++)
            {
                hoja_trabajo.Cells[Row1 , 1] = DV.Table.Rows[Vs]["agreementnumber"].ToString();
                hoja_trabajo.Cells[Row1, 2] = DV.Table.Rows[Vs]["ContractDate"].ToString();
                /*-----------------------*/
                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + Row1 + "", "H" + Row1 + ""];
                rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                rango4.Rows.RowHeight = 20;
                rango4.Font.Color = Color.White;
                rango4.Font.Bold = true;rango4.Font.Size = 14; rango4.Interior.Color = Color.DarkBlue;
                rango4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                /*-------Tour Information---------------------------------*/
                hoja_trabajo.Cells[R + Row1 , 1] = "TOUR INFORMATION";
                Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["A" + (Row1 + 1) + "", "A" + (Row1 +1) + ""];;
                rango5.Font.Bold = true; rango5.Font.Size = 11; rango5.Interior.Color = Color.Gold;
                /*----------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 1, 1] = "LEAD # & DATE";
                hoja_trabajo.Cells[R + Row1 + 1, 2] = DV.Table.Rows[Vs]["LeadNo"].ToString()+" "+ DV.Table.Rows[Vs]["LeadDATE"].ToString();
                hoja_trabajo.Cells[R + Row1 + 2, 3] = "OPC";
                hoja_trabajo.Cells[R + Row1 + 2, 4] = DV.Table.Rows[Vs]["OPC"].ToString();
                hoja_trabajo.Cells[R + Row1 + 1, 3] = "LINER";
                hoja_trabajo.Cells[R + Row1 + 1, 4] = DV.Table.Rows[Vs]["LINER"].ToString();
                hoja_trabajo.Cells[R + Row1 + 1, 5] = "CLOSER";
                hoja_trabajo.Cells[R + Row1 + 1, 6] = DV.Table.Rows[Vs]["CLOSER"].ToString();
                hoja_trabajo.Cells[R + Row1 + 1, 7] = "SV";
                hoja_trabajo.Cells[R + Row1 + 1, 8] = DV.Table.Rows[Vs]["OPCSUPERVISOR"].ToString();
                hoja_trabajo.Cells[R + Row1 + 2, 5] = "VLO";
                hoja_trabajo.Cells[R + Row1 + 2, 6] = DV.Table.Rows[Vs]["VLO"].ToString();
                /*-------MEMBER INFORMATION---------------------------------*/
                hoja_trabajo.Cells[R + Row1+ 3, 1] = "MEMBER INFORMATION";
                Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["A" + (Row1 + 4) + "", "A" + (Row1 + 4) + ""]; ;
                rango6.Font.Bold = true; rango6.Font.Size = 11; rango6.Interior.Color = Color.Gold ;
                /*----------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 4, 3] = "MEMBER";
                hoja_trabajo.Cells[R + Row1 + 4, 4] = DV.Table.Rows[Vs]["MEMBERNAME1"].ToString();
                hoja_trabajo.Cells[R + Row1 + 6, 3] = "ADDRESS";
                hoja_trabajo.Cells[R + Row1 + 6, 4] = DV.Table.Rows[Vs]["ADDRESS"].ToString();
                hoja_trabajo.Cells[R + Row1 + 5, 1] = "CITY";
                hoja_trabajo.Cells[R + Row1 + 5, 2] = DV.Table.Rows[Vs]["CITY"].ToString();
                hoja_trabajo.Cells[R + Row1 + 6, 5] = "PROVINCE";
                hoja_trabajo.Cells[R + Row1 + 6, 6] = DV.Table.Rows[Vs]["PROVINCE"].ToString();
                hoja_trabajo.Cells[R + Row1 + 6, 1] = "ZIP CODE";
                hoja_trabajo.Cells[R + Row1 + 6, 2] = DV.Table.Rows[Vs]["ZIPCODE"].ToString();
                hoja_trabajo.Cells[R + Row1 + 4, 1] = "COUNTRY";
                hoja_trabajo.Cells[R + Row1 + 4, 2] = DV.Table.Rows[Vs]["COUNTRY"].ToString();
                hoja_trabajo.Cells[R + Row1 + 5, 7] = "CITIZEN";
                hoja_trabajo.Cells[R + Row1 + 5, 8] = DV.Table.Rows[Vs]["CITIZEN"].ToString();
                hoja_trabajo.Cells[R + Row1 + 5, 5] = "DL / ID NO";
                hoja_trabajo.Cells[R + Row1 + 5, 6] = DV.Table.Rows[Vs]["IDNO"].ToString();
                hoja_trabajo.Cells[R + Row1 + 5, 3] = "PHONE/OFFICE";
                hoja_trabajo.Cells[R + Row1 + 5, 4] = DV.Table.Rows[Vs]["PHONE"].ToString()+" "+ DV.Table.Rows[Vs]["CELLULAR"].ToString();
                hoja_trabajo.Cells[R + Row1 + 4, 5] = "EMAIL";
                hoja_trabajo.Cells[R + Row1 + 4, 6] = DV.Table.Rows[Vs]["EMAIL"].ToString();
                hoja_trabajo.Cells[R + Row1 + 4, 7] = "FAX NO";
                hoja_trabajo.Cells[R + Row1 + 4, 8] = DV.Table.Rows[Vs]["FAX"].ToString();
                hoja_trabajo.Cells[R + Row1 + 6, 7] = "CITIZEN";
                hoja_trabajo.Cells[R + Row1 + 6, 8] = DV.Table.Rows[Vs]["NATIONALITY"].ToString();
                /*-------SCHEDULE---------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 7, 1] = "SCHEDULE";
                Microsoft.Office.Interop.Excel.Range rango7 = aplicacion.Range["A" + (Row1 + 8) + "", "A" + (Row1 + 8) + ""]; ;
                rango7.Font.Bold = true; rango7.Font.Size = 11; rango7.Interior.Color = Color.Gold;
                /*--------------------------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 9, 3] = "RESORT";
                hoja_trabajo.Cells[R + Row1 + 9, 4] = DV.Table.Rows[Vs]["RESORT"].ToString();
                hoja_trabajo.Cells[R + Row1 + 8, 1] = "APARTMENT TYPE";
                hoja_trabajo.Cells[R + Row1 + 8, 2] = DV.Table.Rows[Vs]["APARTMENTTYPE"].ToString();
                hoja_trabajo.Cells[R + Row1 + 8, 3] = "NO. OF OCUPANTS";
                hoja_trabajo.Cells[R + Row1 + 8, 4] = DV.Table.Rows[Vs]["OCUPANTNO"].ToString();
                hoja_trabajo.Cells[R + Row1 + 9, 1] = "SEASON";
                hoja_trabajo.Cells[R + Row1 + 9, 2] = DV.Table.Rows[Vs]["SEASON"].ToString();
                hoja_trabajo.Cells[R + Row1 + 8, 5] = "NO. OF WEEK";
                hoja_trabajo.Cells[R + Row1 + 8, 6] = DV.Table.Rows[Vs]["WEEKNO"].ToString();
                /*-------PURCHASE TERMS---------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 10, 1] = "PURCHASE TERMS";
                Microsoft.Office.Interop.Excel.Range rango8 = aplicacion.Range["A" + (Row1 + 11) + "", "A" + (Row1 + 11) + ""]; ;
                rango8.Font.Bold = true; rango8.Font.Size = 11; rango8.Interior.Color = Color.Gold;
                hoja_trabajo.Cells[R + Row1 + 11, 1] = "MEMBERSHIP";
                hoja_trabajo.Cells[R + Row1 + 11, 2] = DV.Table.Rows[Vs]["PRICE"].ToString();
                hoja_trabajo.Cells[R + Row1 + 12, 1] = "ADMINISTRATION FEE";
                hoja_trabajo.Cells[R + Row1 + 12, 2] = DV.Table.Rows[Vs]["CLOSINGCOST"].ToString();
                hoja_trabajo.Cells[R + Row1 + 11, 3] = "TAX";
                hoja_trabajo.Cells[R + Row1 + 11, 4] = DV.Table.Rows[Vs]["TAX"].ToString();
                hoja_trabajo.Cells[R + Row1 + 12, 3] = "TOTAL";
                hoja_trabajo.Cells[R + Row1 + 12, 4] = DV.Table.Rows[Vs]["TOTAL"].ToString();
                hoja_trabajo.Cells[R + Row1 + 11, 5] = "LOAN INTEREST";
                hoja_trabajo.Cells[R + Row1 + 11, 6] = DV.Table.Rows[Vs]["INTEREST"].ToString();
                hoja_trabajo.Cells[R + Row1 + 12, 5] = "GRAND TOTAL";
                hoja_trabajo.Cells[R + Row1 + 12, 6] = DV.Table.Rows[Vs]["GRANDTOTAL"].ToString();
                /*-------TOTAL PAYMENT RECEIVED----------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 13, 1] = "DEPOSIT RECEIVED";
                hoja_trabajo.Cells[R + Row1 + 13, 2] = DV.Table.Rows[Vs]["TOTALPAID"].ToString();
                /*-------FUTURE PAYMENT ----------------------------------*/
                 hoja_trabajo.Cells[R + Row1 + 13, 3] = "FUTURE DEPOSIT";
                hoja_trabajo.Cells[R + Row1 + 13, 4] = DV.Table.Rows[Vs]["FuturePayment"].ToString();
                /*-------FINANCING PAYMENT ----------------------------------*/
                hoja_trabajo.Cells[R + Row1 + 14, 1] = "FINANCING";
                hoja_trabajo.Cells[R + Row1 + 14, 2] = DV.Table.Rows[Vs]["Financing"].ToString();
                /*--------------------Colores por Rango--------------------------*/
                Microsoft.Office.Interop.Excel.Range rangoA1 = aplicacion.Range["A" + (Row1 + 2) + ""]; rangoA1.Interior.Color = Color.LightCyan; rangoA1.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoA2 = aplicacion.Range["A" + (Row1 + 5) + "","A"+(Row1 + 7) +""]; rangoA2.Interior.Color = Color.LightCyan; rangoA2.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoA3 = aplicacion.Range["A" + (Row1 + 9) + "", "A" + (Row1 + 10) + ""]; rangoA3.Interior.Color = Color.LightCyan; rangoA3.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoA4 = aplicacion.Range["A" + (Row1 + 12) + "", "A" + (Row1 + 15) + ""]; rangoA4.Interior.Color = Color.LightCyan; rangoA4.Borders.LineStyle = BorderStyle.FixedSingle;
                /*------------------------*/
                Microsoft.Office.Interop.Excel.Range rangoC1 = aplicacion.Range["C" + (Row1 + 2) + "","C"+(Row1+3)+""]; rangoC1.Interior.Color = Color.LightCyan; rangoC1.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoC2 = aplicacion.Range["C" + (Row1 + 5) + "", "C" + (Row1 + 7) + ""]; rangoC2.Interior.Color = Color.LightCyan; rangoC2.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoC3 = aplicacion.Range["C" + (Row1 + 9) + "", "C" + (Row1 + 10) + ""]; rangoC3.Interior.Color = Color.LightCyan; rangoC3.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoC4 = aplicacion.Range["C" + (Row1 + 12) + "", "C" + (Row1 + 14) + ""]; rangoC4.Interior.Color = Color.LightCyan; rangoC4.Borders.LineStyle = BorderStyle.FixedSingle;
                /*------------------------*/
                Microsoft.Office.Interop.Excel.Range rangoE1 = aplicacion.Range["E" + (Row1 + 2) + "", "E" + (Row1 + 3) + ""]; rangoE1.Interior.Color = Color.LightCyan; rangoE1.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoE2 = aplicacion.Range["E" + (Row1 + 5) + "", "E" + (Row1 + 7) + ""]; rangoE2.Interior.Color = Color.LightCyan; rangoE2.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoE3 = aplicacion.Range["E" + (Row1 + 9) + "", "E" + (Row1 + 9) + ""]; rangoE3.Interior.Color = Color.LightCyan; rangoE3.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoE4 = aplicacion.Range["E" + (Row1 + 12) + "", "E" + (Row1 + 13) + ""]; rangoE4.Interior.Color = Color.LightCyan; rangoE4.Borders.LineStyle = BorderStyle.FixedSingle;
                /*------------------------*/
                Microsoft.Office.Interop.Excel.Range rangoG1 = aplicacion.Range["G" + (Row1 + 2) + "", "G" + (Row1 + 2) + ""]; rangoG1.Interior.Color = Color.LightCyan; rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoG2 = aplicacion.Range["G" + (Row1 + 5) + "", "G" + (Row1 + 7) + ""]; rangoG2.Interior.Color = Color.LightCyan; rangoG2.Borders.LineStyle = BorderStyle.FixedSingle;
                /*---------------------------BORDER EN FILA-------------------------------------------------*/
                Microsoft.Office.Interop.Excel.Range rangoB1 = aplicacion.Range["B" + (Row1 + 2) + "", "B" + (Row1 + 15) + ""];  rangoB1.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoD2 = aplicacion.Range["D" + (Row1 + 2) + "", "D" + (Row1 + 15) + ""];  rangoD2.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoF3 = aplicacion.Range["F" + (Row1 + 2) + "", "F" + (Row1 + 15) + ""];  rangoF3.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoH4 = aplicacion.Range["H" + (Row1 + 2) + "", "H" + (Row1 + 15) + ""];  rangoH4.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoG4 = aplicacion.Range["G" + (Row1 + 14) + "", "G" + (Row1 + 15) + ""]; rangoG4.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoE44 = aplicacion.Range["E" + (Row1 + 14) + "", "E" + (Row1 + 15) + ""]; rangoE44.Borders.LineStyle = BorderStyle.FixedSingle;
                Microsoft.Office.Interop.Excel.Range rangoC44 = aplicacion.Range["C" + (Row1 + 15) + "", "C" + (Row1 + 15) + ""]; rangoC44.Borders.LineStyle = BorderStyle.FixedSingle;
                /*------------------------*/
                Row1 = R + Row1 + 16;
            }
            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Name = "Verification Sheet";
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*==========================================================================================================================================*/
    }
}
