using OfficeOpenXml;
using System.IO;

namespace Shelly.ManagementExcel.Helper
{
     public class EvaluateFormula
     {
          #region Variables

          //private readonly SpreadsheetGear.IWorksheet _oWorkSheet;
         // private readonly ExcelWorksheet _oWorkSheet;

          #endregion Variables

          #region Constructores

          public EvaluateFormula()
          {
               //  _oWorkSheet = SpreadsheetGear.Factory.GetWorkbook().Worksheets[0];
              
              
          }

          #endregion Constructores

          #region Funciones

         private object EvaluateValue(string psFormula)
          {
               ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
               using var excelPackage = new ExcelPackage();
               var oWorkSheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
               oWorkSheet.Cells["A1"].Formula = psFormula;
               oWorkSheet.Cells["A1"].Calculate();
               return oWorkSheet.Cells["A1"].Value;
          }
          public object Evaluate(string psFormula)
          {
               // Evaluate the input formula.
               //object result = _oWorkSheet.EvaluateValue(psFormula);
               object result = EvaluateValue(psFormula);             
               // Display the result to the user.
               if (result == null)
               {
                    return 0;
               }
               else if (result is SpreadsheetGear.ValueError)
               {
                    return 0;
               }
               else
               {
                    return result;
               }
          }

          #endregion Funciones
     }
}
