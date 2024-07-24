
using OfficeOpenXml;

namespace Shelly.ManagementExcel.Helper
{
     internal static class Excel
     {
          public static string ConvertExcelToJSON(ExcelWorksheet worksheet)
          {
               var rowCount = worksheet.Dimension.Rows;
               var colCount = worksheet.Dimension.Columns;
               var objectData = new List<Dictionary<string, string>>();
               for (int row = 2; row <= rowCount; row++)
               {
                    var data = new Dictionary<string, string>();
                    for (int col = 1; col <= colCount; col++)
                    {
                         //! Leemos el nombre de la columna y cambiaremos a mayúscula la letra inicial de cada palabra
                         string colName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((worksheet.Cells[1, col].Value ?? "").ToString());
                         //Limpieza de acentos en los nombres de columnas y eliminación de espacios
                         colName = string.Join("", colName.Normalize(NormalizationForm.FormD)
                                   .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                   .ToArray()).Replace(" ", "").Replace(".", "").Replace("/", "");
                         if (!String.IsNullOrEmpty(colName))
                              //Que no agregue columnas vacias
                              data[colName] = (worksheet.Cells[row, col].Value ?? "").ToString();
                    }
                    if (!string.IsNullOrEmpty(data.First().Value))
                         //que no agregue datos donde el primero elemento sea vacio (VIN)
                         objectData.Add(data);
               }
               return JsonConvert.SerializeObject(objectData, Newtonsoft.Json.Formatting.Indented);
          }

          public static List<T>? GetData<T>(ExcelWorksheet worksheet)
          {
               return JsonConvert.DeserializeObject<List<T>>(ConvertExcelToJSON(worksheet));
          }
          public static int ConvertToInt(this string? value)
          {
               if (string.IsNullOrEmpty(value))
                    return 0;
               bool result = Int32.TryParse(value, out int convert);
               if (!result)
                    return 0;
               return convert;
          }
          public static decimal ConvertToDecimal(this string? value)
          {
               if (string.IsNullOrEmpty(value))
                    return 0;
               bool result = Decimal.TryParse(value, out decimal convert);
               if (!result)
                    return 0;
               return convert;
          }
          public static decimal ConvertToDecimal(this object? value)
          {
               return ConvertToDecimal(Convert.ToString(value));
          }
     }
}
