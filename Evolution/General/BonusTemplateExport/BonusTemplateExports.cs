using Evolution.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms.BonusTemplateExport
{
   public class BonusTemplateExports
    {
        System.Data.DataTable _BatchAgreements = new System.Data.DataTable();

        public void ExportarGridview(string date1,string date2, System.Data.DataTable batchAgreements, List<BonusCommissionerModel> _BonusCommissionerM,string TemplateStatus,string Code)
        {/*----------------------------------------------------------------------------------------*/
            int CountCollums = _BonusCommissionerM.Count();

            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            //Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();

            var xlSheets = WBook.Sheets as Microsoft.Office.Interop.Excel.Sheets;
           
            hoja_trabajo = WBook.Worksheets.get_Item(1);
   
  
            //-------------------EVALUA SI LA CANTIDAD DE CONTRATOS ES MAS QUE LA CANTIDAD DE BONUCOMMISSIONER-----------------------
            int arrayRows = _BonusCommissionerM.Count > batchAgreements.Rows.Count ? _BonusCommissionerM.Count : batchAgreements.Rows.Count;
            //-----------------------------------------------------------------------------------------------------------------------



            //*****************************FORMATO DE HEADER*************************************************//
            /*-----------------------Parametro--------------------------------------*/
            //hoja_trabajo.Cells[1, 1] = "Report";
            //hoja_trabajo.Cells[2, 1] = "Rango De Fecha";
            //hoja_trabajo.Cells[3, 1] = "BONUS TEMPLATE";

            //hoja_trabajo.Cells[2, 2] = date1;
            //hoja_trabajo.Cells[3, 2] = date2;


            //*******************************</HEADER>*********************************************************//
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            //---------------------------BONUS TEMPLATE TEXT -------------------------
            Range MergeAgreementTittle= aplicacion.Worksheets.get_Item(1).Range["H1:I1"];
            MergeAgreementTittle.Merge();
            MergeAgreementTittle.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            //-------------------------------------------------------------------------------
            //-------------------------------------------HEADER GRID---------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range formatCommissioners = aplicacion.Worksheets.get_Item(1).Range["A1:E2"];
            formatCommissioners.Font.Bold = true;
            formatCommissioners.Font.Size = 11;
            formatCommissioners.Interior.Color = Color.FromArgb(185, 253, 187);
            formatCommissioners.Borders.Value = 1;
            formatCommissioners.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Gray, XlThemeColor.xlThemeColorDark1);

            Microsoft.Office.Interop.Excel.Range formatAgreementsBAth = aplicacion.Worksheets.get_Item(1).Range["G1:J2"];
            formatAgreementsBAth.Font.Bold = true;
            formatAgreementsBAth.Font.Size = 11;
            formatAgreementsBAth.Interior.Color = Color.AliceBlue;
            formatAgreementsBAth.BorderAround2(XlLineStyle.xlContinuous,XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Gray, XlThemeColor.xlThemeColorDark1);
            //---------------------------------------------------------------------------------------------------------------------
      
            Microsoft.Office.Interop.Excel.Range formatcolunD = aplicacion.Worksheets.get_Item(1).Range["D3", $"D{arrayRows + 2}"];
            formatcolunD.NumberFormat = "#,##0.00";
            Microsoft.Office.Interop.Excel.Range formatcolunB = aplicacion.Worksheets.get_Item(1).Range["B3", $"B{arrayRows + 2}"];
            formatcolunB.NumberFormat = "#,##0.00";
            Microsoft.Office.Interop.Excel.Range formatcolunA = aplicacion.Worksheets.get_Item(1).Range["A3", $"A{arrayRows + 2}"];
            formatcolunA.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range formatcolunDate = aplicacion.Worksheets.get_Item(1).Range["B1", $"C1"];
            formatcolunDate.NumberFormat = "MM/dd/yyyy";

            Microsoft.Office.Interop.Excel.Range formatcolumD1E1 = aplicacion.Worksheets.get_Item(1).Range["D1", $"E1"];
            formatcolumD1E1.Font.Color = Color.Red;
            formatcolumD1E1.Interior.Color = Color.AliceBlue;


            object[,] myArray = new object[arrayRows + 3, 10]; // filas Y COL. de la consulta

            //var rowTotales = new List<int>();
            //------------------------------------------DATOS DEL HEADER----------------------------------------------------
            myArray[0, 0] = "Period"; myArray[0, 1] = date1; myArray[0, 2] = date2; myArray[0, 3] = "";
            myArray[1, 0] = "Names"; myArray[1, 1] = "$ Amount"; myArray[1, 2] = "Quantity"; myArray[1, 3] = "Total"; myArray[1, 4] = "Comment";
            myArray[0, 3] = "Status:"; myArray[0, 4] = TemplateStatus;
            myArray[0, 7] = "BONUS COMMISSIONS CONTRACTS";

            myArray[1, 6] = "Date"; myArray[1, 7] = "Agreement #"; myArray[1, 8] = "Member"; myArray[1, 9] = "Source"; 
           //----------------------------------------------------------------------------------------------------------------------
            int rowcoun = 2;

           /* int countx = 0;*/ 
            //int county = 0; 

            foreach (var item in _BonusCommissionerM)
            {
                myArray[rowcoun, 0] = item.FullName ; myArray[rowcoun, 1] = item.Amount; myArray[rowcoun, 2] = item.ContractQuantity; myArray[rowcoun, 3] = (item.Amount * Convert.ToDecimal(item.ContractQuantity)); myArray[rowcoun, 4] =item.Comment ; 
               rowcoun++;
            }
            myArray[rowcoun, 0] = "Total:";
            int RowRangoTotales = rowcoun;
            //****************************************************************BATCH OF AGREEMENT*******************************************
             rowcoun = 2;
            for (int x = 0; x < batchAgreements.Rows.Count; x++)
            {
                myArray[rowcoun, 5] = "  ";
                myArray[rowcoun, 6] = batchAgreements.Rows[x]["ContractDate"];
                myArray[rowcoun, 7] = batchAgreements.Rows[x]["ContractNo"];
                myArray[rowcoun, 8] = batchAgreements.Rows[x]["Member"];
                myArray[rowcoun, 9] = batchAgreements.Rows[x]["Source"];
              
                rowcoun++;
            }

            //****************************************************************B**************************************************************

            Range rng = hoja_trabajo.Cells.get_Resize(arrayRows + 2, 10); //4 columnas y las cantidad de filas de la consulta
            rng.Value2 = myArray; // pone el array en todas las celdas
            hoja_trabajo.Name = "Bonus";

            hoja_trabajo.Cells.EntireColumn.AutoFit();

         
            ///////////////////////////////////////////**TOTALES"**////////////////////////////////////////////////////
                Range TextTotales = aplicacion.Worksheets.get_Item(1).Range[$"A{RowRangoTotales + 1}"];
            TextTotales.Font.Bold = true;

            //----------------------------------FxTotalAmount ----------------------------------------
            Range FxTotalAmount = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 1}"];
            FxTotalAmount.Font.Bold = true;
            FxTotalAmount.Formula = $"=SUM(B3:B{ RowRangoTotales})";
        
            //-------------------------------------------FxTotalNet----------------------
            Range FxTotalNet = aplicacion.Worksheets.get_Item(1).Range[$"D{RowRangoTotales + 1}"];
            FxTotalNet.Font.Bold = true;
            FxTotalNet.Formula = $"=SUM(D3:D{ RowRangoTotales})";
            //--------------------------------------stylo de totales-----------------------------
            Range styleTotal = aplicacion.Worksheets.get_Item(1).Range[$"A{RowRangoTotales + 1}",$"E{RowRangoTotales + 1}"];
            styleTotal.Interior.Color = Color.AliceBlue;
            styleTotal.Borders.Value = 1;

            //////////////////////////////////////////////////////////////////////////////////////////
            Range LinePrepareedby = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 5}", $"C{RowRangoTotales + 5}"];
            LinePrepareedby.Merge();
            LinePrepareedby.Cells.Value = "________________________________";
            Range Prepareedby = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 6}", $"C{RowRangoTotales + 6}"];
            Prepareedby.Merge();
            Prepareedby.Cells.Value = "Prepared By:";
            Prepareedby.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            //---------------------------------------------------------------------------------------------------------------------
            Range LineRevisedBy = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 9}", $"C{RowRangoTotales + 9}"];
            LineRevisedBy.Merge();
            LineRevisedBy.Cells.Value = "________________________________";

            Range RevisedBy = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 10}", $"C{RowRangoTotales + 10}"];
            RevisedBy.Merge();
            RevisedBy.Cells.Value = "Revised By:";
            RevisedBy.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //---------------------------------------------------------------------------------------------------------------------
            Range LineAuthorizedBy = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 13}", $"C{RowRangoTotales + 13}"];
            LineAuthorizedBy.Merge();
            LineAuthorizedBy.Cells.Value = "________________________________";
            Range AuthorizedBy = aplicacion.Worksheets.get_Item(1).Range[$"B{RowRangoTotales + 14}", $"C{RowRangoTotales + 14}"];
            AuthorizedBy.Merge();
            AuthorizedBy.Cells.Value = "Authorized By:";
            AuthorizedBy.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //hoja_trabajo.Cells[RowRangoTotales + 4, 2] = "Prepared By:";

            //--------------------------------------PREPARED BY, REVISED BY, AUTHORIZED BY:


            //FormatCondition condition1 = (FormatCondition)rng.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlEqual, "TOTAL");
            //condition1.Font.Bold = true;

            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }

    }
}
