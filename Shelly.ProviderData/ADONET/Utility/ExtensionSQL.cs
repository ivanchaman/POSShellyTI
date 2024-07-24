using System.ComponentModel;

namespace Shelly.ProviderData.ADONET.Utility
{
     public static class ExtensionSQL
     {
          private static Type[] _oDataTypes = new[]
         {
               typeof(byte),
               typeof(sbyte),
               typeof(short),
               typeof(ushort),
               typeof(int),
               typeof(uint),
               typeof(long),
               typeof(ulong),
               typeof(float),
               typeof(double),
               typeof(decimal),
               typeof(bool),
               typeof(char),
               typeof(Guid),
               typeof(DateTime),
               typeof(DateTimeOffset),
               typeof(byte[]),
               typeof(string)
          };
          public static string DateSql(this DateTime date, bool isHHmmss, DataBaseType engines)
          {
               string caracter;
               StringBuilder str;
               switch (engines)
               {
                    case DataBaseType.SqlServer:
                         caracter = "";
                         break;

                    default:
                         caracter = "";
                         break;
               }

               str = new StringBuilder();
               str.AppendFormat("'{0}{3}{1}{3}{2}", (date.Year).ToString().PadLeft(4, '0'), (date.Month).ToString().PadLeft(2, '0'), date.Day.ToString().PadLeft(2, '0'), caracter);
               if (isHHmmss)
               {
                    str.AppendFormat(" {0}:{1}:{2}'", date.Hour.ToString().PadLeft(2, '0'), date.Minute.ToString().PadLeft(2, '0'), date.Second.ToString().PadLeft(2, '0'));
               }
               else
               {
                    str.AppendFormat("'");
               }
               return str.ToString();
          }

          /// <summary>
          /// Fechas the SQL.
          /// </summary>
          /// <param name="date">The pd fecha.</param>
          /// <returns></returns>
          public static string DateSql(this DateTimeOffset date)
          {
               return DateSql(date, false, "'");
          }

          /// <summary>
          /// Fechas the SQL.
          /// </summary>
          /// <param name="date">The pd fecha.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [pb incluye h HMMSS].</param>
          /// <returns></returns>
          public static string DateSql(this DateTimeOffset date, bool isHHmmss)
          {
               return DateSql(date, isHHmmss, "'");
          }

          /// <summary>
          /// Dates the SQL.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [is h HMMSS].</param>
          /// <param name="caracter">The ps caracter separado.</param>
          /// <returns></returns>
          public static string DateSql(this DateTimeOffset date, bool isHHmmss, string caracter)
          {
               StringBuilder str;
               str = new StringBuilder();
               str.AppendFormat("'{0}{3}{1}{3}{2}", date.Year, (date.Month).ToString().PadLeft(2, '0'), date.Day.ToString().PadLeft(2, '0'), caracter);
               if (isHHmmss)
               {
                    str.AppendFormat(" {0}:{1}:{2}'", date.Hour.ToString().PadLeft(2, '0'), date.Minute.ToString().PadLeft(2, '0'), date.Second.ToString().PadLeft(2, '0'));
               }
               else
               {
                    str.AppendFormat("'");
               }
               return str.ToString();
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTime date)
          {
               return DateSqlParameters(date, false, "");
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [is h HMMSS].</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTime date, bool isHHmmss)
          {
               return DateSqlParameters(date, isHHmmss, "");
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [is h HMMSS].</param>
          /// <param name="caracter">The caracter.</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTime date, bool isHHmmss, string caracter)
          {
               return DateSql(date, isHHmmss, caracter).Replace("'", "");
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTimeOffset date)
          {
               return DateSqlParameters(date, false, "");
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [is h HMMSS].</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTimeOffset date, bool isHHmmss)
          {
               return DateSqlParameters(date, isHHmmss, "");
          }

          /// <summary>
          /// Dates the SQL parameters.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="isHHmmss">if set to <c>true</c> [is h HMMSS].</param>
          /// <param name="caracter">The caracter.</param>
          /// <returns></returns>
          public static string DateSqlParameters(this DateTimeOffset date, bool isHHmmss, string caracter)
          {
               return DateSql(date, isHHmmss, caracter).Replace("'", "");
          }

          /// <summary>
          /// Converts the date time fecha SQL.
          /// </summary>
          /// <param name="date">The ps fecha.</param>
          /// <returns></returns>
          public static DateTime ConvertDateTimeToDateSql(string date)
          {
               try
               {
                    return new DateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(7, 2)));
               }
               catch
               {
                    return DateTime.Now;
               }
          }
          public static T GetDefaultValue<T>()
          {
               if (typeof(T) == typeof(DateTime))
                    return (T)(object)(new DateTime(1900, 1, 1));
               if (typeof(T) == typeof(String))
                    return (T)(object)String.Empty;
               return default;
          }
          public static T GetValue<T>(this DataRow row, string columnName)
          {
               Object value;
               Type type = typeof(T);
               Type nullableType = Nullable.GetUnderlyingType(type);
               if (!row.Table.Columns.Contains(columnName))
               {
                    return GetDefaultValue<T>();
               }
               value = row[columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T>();
               }
               if (nullableType != null)
               {
                    return (T)Convert.ChangeType(value, nullableType);
               }
               else
               {

                    if (value.GetType() == typeof(System.Guid))
                    {
                         return (T)Convert.ChangeType(Convert.ToString(value), typeof(T));
                    }
                    else if (value.GetType() == typeof(System.String) && type == typeof(System.Boolean))
                    {
                         return (T)Convert.ChangeType(Convert.ToString(value).ToBoolean(), typeof(T));
                    }
                    else if (value.GetType() == typeof(System.Int32) && !Convert.ToString(value).IsNumeric())
                    {
                         return GetDefaultValue<T>();
                    }
                    else if (value.GetType() == typeof(System.DateTimeOffset))
                    {
                         DateTimeOffset sourceTime = DateTimeOffset.Parse(Convert.ToString(value));
                         return (T)Convert.ChangeType(sourceTime.DateTime, typeof(T));
                    }
                    else
                    {
                         return (T)Convert.ChangeType(value, typeof(T));
                    }
               }
          }
          public static IEnumerable<PropertyInfo> GetColumnNames<T>(this IDataReader dataReader)
          {
               IEnumerable<string> columnNames;
               IEnumerable<PropertyInfo> infoProperties;
               const System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;
               columnNames = dataReader.GetSchemaTable()
                                                 .Rows
                                                 .Cast<DataRow>()
                                                 .Select(r => Convert.ToString(r["ColumnName"]).ToLower());
               infoProperties = typeof(T).GetProperties(bindingFlags);
               return infoProperties.Where(properties => columnNames.Contains(properties.Name.ToLower()));
          }
          private static bool IsBasicType(Type poType)
          {
               poType = Nullable.GetUnderlyingType(poType) ?? poType;
               return poType.IsEnum || _oDataTypes.Contains(poType);
          }
          public static object? GetValue<T>(this T data, string name)
          {
               IEnumerable<PropertyDescriptor> loProperties = from loProperty in TypeDescriptor.GetProperties(typeof(T)).Cast<PropertyDescriptor>()
                                                              where IsBasicType(loProperty.PropertyType) 
                                                              select loProperty;
               var property = loProperties.Where(properties => properties.Name == name).FirstOrDefault();
               if (property == null)
                    return default;
               return property.GetValue(data);

          }
          public static T GetValue<T>(this DataTable dataTable, string columnName)
          {
               Object value;
               if (dataTable.Rows.Count == 0)
               {
                    return GetDefaultValue<T>();
               }
               if (!dataTable.Columns.Contains(columnName))
               {
                    return GetDefaultValue<T>();
               }
               value = dataTable.Rows[0][columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T>();
               }
               return (T)Convert.ChangeType(value, typeof(T));
          }
          public static T1 GetValue<T1,T2>(this List<T2>? data, string columnName) where T2 : class, new()
          {
               if (data == null || data.Count == 0)
               {
                    return GetDefaultValue<T1>();
               }
               Object?  value = data[0].GetValue(columnName);
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T1>();
               }
               return (T1?)Convert.ChangeType(value, typeof(T1));
          }
          /// <summary>
          /// Regresas the valor fila.
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="dataTable">The po tabla.</param>
          /// <param name="numberRow">The pi fila.</param>
          /// <param name="columnName">The ps columna.</param>
          /// <returns></returns>
          public static T GetValue<T>(this DataTable dataTable, int numberRow, string columnName)
          {
               Object value;
               if (dataTable.Rows.Count == 0)
               {
                    return GetDefaultValue<T>();
               }
               if (numberRow >= dataTable.Rows.Count)
               {
                    return GetDefaultValue<T>();
               }
               if (!dataTable.Columns.Contains(columnName))
               {
                    return GetDefaultValue<T>();
               }
               value = dataTable.Rows[numberRow][columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T>();
               }
               return (T)Convert.ChangeType(value, typeof(T));
          }
          public static bool IsNumeric(this string value)
          {
               float output;
               return float.TryParse(value, out output);
          }
          public static bool ToBoolean(this string inputString)
          {
               if (String.IsNullOrEmpty(inputString))
                    inputString = "";
               switch (inputString.ToLower())
               {
                    case "true":
                    case "t":
                    case "1":
                    case "si":
                    case "yes":
                    case "y":
                    case "s":
                         return true;

                    case "0":
                    case "false":
                    case "f":
                    case "":
                    case "no":
                    case "n":
                         return false;

                    default:
                         return false;
               }
          }
          public static T GetValue<T>(this IDataReader row, string columnName)
          {
               Object value;
               Type type = typeof(T);
               Type nullableType = Nullable.GetUnderlyingType(type);
               if (row.GetOrdinal(columnName) < 0)
               {
                    return GetDefaultValue<T>();
               }
               value = row[columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T>();
               }
               if (nullableType != null)
                    return (T)Convert.ChangeType(value, nullableType);
               else
               {
                    if (value.GetType() == typeof(System.Guid))
                         return (T)Convert.ChangeType(Convert.ToString(value), typeof(T));
                    else
                         return (T)Convert.ChangeType(value, typeof(T));
               }
          }

          /// <summary>
          /// Gets the value.
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="row">The row.</param>
          /// <param name="columnName">Name of the column.</param>
          /// <returns></returns>
          public static T GetValue<T>(this DataRowView row, string columnName)
          {
               Object value;
               Type type = typeof(T);
               Type nullableType = Nullable.GetUnderlyingType(type);
               if (!row.Row.Table.Columns.Contains(columnName))
               {
                    return GetDefaultValue<T>();
               }
               value = row[columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
               {
                    return GetDefaultValue<T>();
               }
               if (nullableType != null)
                    return (T)Convert.ChangeType(value, nullableType);
               else
               {
                    if (value.GetType() == typeof(System.Guid))
                         return (T)Convert.ChangeType(Convert.ToString(value), typeof(T));
                    else
                         return (T)Convert.ChangeType(value, typeof(T));
               }
          }
          public static T GetValue<T>(this DataView row, string columnName)
          {
               Object value;
               Type type = typeof(T);
               Type nullableType = Nullable.GetUnderlyingType(type);
               if (row.Count == 0)
                    return GetDefaultValue<T>();
               if (!row[0].Row.Table.Columns.Contains(columnName))
                    return GetDefaultValue<T>();
               value = row[0][columnName];
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
                    return GetDefaultValue<T>();
               if (nullableType != null)
               {
                    return (T)Convert.ChangeType(value, nullableType);
               }
               else
               {
                    if (value.GetType() == typeof(System.Guid))
                         return (T)Convert.ChangeType(Convert.ToString(value), typeof(T));
                    else
                         return (T)Convert.ChangeType(value, typeof(T));
               }
          }
     }
}
