using Shelly.Abstractions.Enumerations;
using System.Text;
namespace Shelly.Abstractions.Helpers
{
     /// <summary>
     /// Clase para el manejor de fechas
     /// </summary>
     public static class ExtensionDates
     {
          private const int ANIO_BASE = 2013;

          /// <summary>
          /// Retorns the large format date time.
          /// </summary>
          /// <param name="poFecha">The po fecha.</param>
          /// <returns></returns>
          public static string ReturnLargeFormatDateTime(this DateTime poFecha)
          {
               return poFecha.ToString("yyyyMMdd HH:mm:ss.fff").Replace(" ", "").Replace(".", "").Replace(":", "");
          }

          /// <summary>
          /// Gets the name month.
          /// </summary>
          /// <param name="month">The pemn mes.</param>
          /// <returns></returns>
          public static string GetNameMonth(MonthType month)
          {
               switch (month)
               {
                    case MonthType.Opening:
                         return "Apertura";

                    case MonthType.January:
                         return "Enero";

                    case MonthType.February:
                         return "Febrero";

                    case MonthType.March:
                         return "Marzo";

                    case MonthType.April:
                         return "Abril";

                    case MonthType.May:
                         return "Mayo";

                    case MonthType.June:
                         return "Junio";

                    case MonthType.July:
                         return "Julio";

                    case MonthType.August:
                         return "Agosto";

                    case MonthType.September:
                         return "Septiembre";

                    case MonthType.October:
                         return "Octubre";

                    case MonthType.November:
                         return "Noviembre";

                    case MonthType.December:
                         return "Diciembre";

                    case MonthType.Closing:
                         return "Cierre";

                    default:
                         return "Otro";
               }
          }

          /// <summary>
          /// Gets the name month.
          /// </summary>
          /// <param name="month">The pi mes.</param>
          /// <returns></returns>
          public static string GetNameMonth(int month)
          {
               if (month >= 0 && month <= 13)
               {
                    return GetNameMonth((MonthType)month);
               }
               return GetNameMonth(MonthType.Other);
          }

          /// <summary>
          /// Firsts the day in m onth.
          /// </summary>
          /// <param name="date">The PDT date.</param>
          /// <returns></returns>
          public static string FirstDayInMOnth(this DateTime date)
          {
               return new DateTime(date.Year, date.Month, 1).ToString("dd");
          }

          /// <summary>
          /// Lasts the day month.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string LastDayMonth(this DateTime date)
          {
               if (date.Month == 12)
               {
                    return "31";
               }
               return new DateTime(date.Year, date.Month + 1, 1).AddDays(-1).ToString("dd");
          }

          /// <summary>
          /// Eses the fecha.
          /// </summary>
          /// <param name="date">The ps fecha.</param>
          /// <returns></returns>
          public static bool IsDate(this string date)
          {
               try
               {
                    DateTime.TryParse(date, out DateTime ldFecha);
                    if (ldFecha != DateTime.MinValue && ldFecha != DateTime.MaxValue)
                    {
                         return true;
                    }
                    return false;
               }
               catch
               {
                    return false;
               }
          }

          public static bool IsDate(this object date)
          {
               try
               {
                    DateTime.TryParse(date.ToString(), out DateTime ldFecha);
                    if (ldFecha != DateTime.MinValue && ldFecha != DateTime.MaxValue)
                    {
                         return true;
                    }
                    return false;
               }
               catch
               {
                    return false;
               }
          }

          /// <summary>
          /// Determines whether the specified year is date.
          /// </summary>
          /// <param name="year">The year.</param>
          /// <param name="month">The month.</param>
          /// <param name="day">The day.</param>
          /// <returns>
          ///   <c>true</c> if the specified year is date; otherwise, <c>false</c>.
          /// </returns>
          public static bool IsDate(string year, string month, string day)
          {
               try
               {
                    DateTime ldFecha = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    if (ldFecha != DateTime.MinValue && ldFecha != DateTime.MaxValue)
                    {
                         return true;
                    }
                    return false;
               }
               catch
               {
                    return false;
               }
          }

         

          /// <summary>
          /// Dates the time minimum.
          /// </summary>
          /// <param name="date1">The pd fecha1.</param>
          /// <param name="date2">The pd fecha2.</param>
          /// <returns></returns>
          public static DateTime DateTimeMin(DateTime date1, DateTime date2)
          {
               if (date1 < date2)
               {
                    return date1;
               }
               return date2;
          }

          /// <summary>
          /// Dates the time maximum.
          /// </summary>
          /// <param name="date1">The pd fecha1.</param>
          /// <param name="date2">The pd fecha2.</param>
          /// <returns></returns>
          public static DateTime DateTimeMax(DateTime date1, DateTime date2)
          {
               if (date1 > date2)
               {
                    return date1;
               }
               return date2;
          }

          /// <summary>
          /// Esta funcion confierte en formato para base de datos utilizando una cadena con formato dd/MM/yyyy como entrada
          /// </summary>
          /// <param name="date">una cadena con formato dd/MM/yyyy</param>
          /// <returns></returns>
          public static DateTime FechaCortaSQL(this string date)
          {
               string[] lasFecha;
               DateTime ldtFecha;
               try
               {
                    lasFecha = date.Split('/');
                    ldtFecha = new DateTime();
                    if (lasFecha.Length == 3)
                    {
                         ldtFecha = new DateTime(Convert.ToInt32(lasFecha[2]), Convert.ToInt32(lasFecha[1]), Convert.ToInt32(lasFecha[0]));
                    }
                    return ldtFecha;
               }
               catch
               {
                    return DateTime.Now;
               }
          }

          /// <summary>
          /// To the universal format.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string ToUniversalFormat(this DateTime date)
          {
               return GetUniversalFormatValue(date, null);
          }

          /// <summary>
          /// Returns a <see cref="System.String" /> that represents this instance.
          /// </summary>
          /// <param name="value">The value.</param>
          /// <returns>
          /// A <see cref="System.String" /> that represents this instance.
          /// </returns>
          public static string ToString(this DateTime? value)
          {
               return value.ToString(null as IFormatProvider);
          }

          /// <summary>
          /// Returns a <see cref="System.String" /> that represents this instance.
          /// </summary>
          /// <param name="value">The value.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns>
          /// A <see cref="System.String" /> that represents this instance.
          /// </returns>
          public static string ToString(this DateTime? value, IFormatProvider formatProvider)
          {
               if (value.HasValue)
               {
                    return value.Value.ToString(formatProvider);
               }
               else
               {
                    return string.Empty;
               }
          }

          /// <summary>
          /// Returns a <see cref="System.String" /> that represents this instance.
          /// </summary>
          /// <param name="value">The value.</param>
          /// <param name="formatSpecifier">The format specifier.</param>
          /// <returns>
          /// A <see cref="System.String" /> that represents this instance.
          /// </returns>
          public static string ToString(this DateTime? value, string formatSpecifier)
          {
               return value.ToString(formatSpecifier, null);
          }

          /// <summary>
          /// Returns a <see cref="System.String" /> that represents this instance.
          /// </summary>
          /// <param name="value">The value.</param>
          /// <param name="formatSpecifier">The format specifier.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns>
          /// A <see cref="System.String" /> that represents this instance.
          /// </returns>
          public static string ToString(this DateTime? value, string formatSpecifier, IFormatProvider formatProvider)
          {
               if (value.HasValue)
               {
                    return value.Value.ToString(formatSpecifier, formatProvider);
               }
               else
               {
                    return string.Empty;
               }
          }

          /// <summary>
          /// To the universal format.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns></returns>
          public static string ToUniversalFormat(this DateTime date, IFormatProvider formatProvider)
          {
               return GetUniversalFormatValue(date, formatProvider);
          }

          /// <summary>
          /// Gets the universal format value.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns></returns>
          private static string GetUniversalFormatValue(DateTime date, IFormatProvider formatProvider)
          {
               string formatSpecifier = string.Empty;

               if (date.Year == DateTime.Now.Year)
               {
                    formatSpecifier = "{0:dddd, MMM d} at {0:h:mm tt}";
               }
               else
               {
                    formatSpecifier = "{0:dddd, MMM d, yyyy} at {0:h:mm tt}";
               }

               return string.Format(formatProvider, formatSpecifier, date);
          }

          /// <summary>
          /// To the relative date string.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string ToRelativeDateString(this DateTime date)
          {
               return GetRelativeDateValue(date, DateTime.Now, null);
          }

          /// <summary>
          /// To the relative date string.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns></returns>
          public static string ToRelativeDateString(this DateTime date, IFormatProvider formatProvider)
          {
               return GetRelativeDateValue(date, DateTime.Now, formatProvider);
          }

          /// <summary>
          /// To the relative date string UTC.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static string ToRelativeDateStringUtc(this DateTime date)
          {
               return GetRelativeDateValue(date, DateTime.UtcNow, null);
          }

          /// <summary>
          /// To the relative date string UTC.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns></returns>
          public static string ToRelativeDateStringUtc(this DateTime date, IFormatProvider formatProvider)
          {
               return GetRelativeDateValue(date, DateTime.UtcNow, formatProvider);
          }

          /// <summary>
          /// Gets the relative date value.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <param name="comparedTo">The compared to.</param>
          /// <param name="formatProvider">The format provider.</param>
          /// <returns></returns>
          private static string GetRelativeDateValue(DateTime date, DateTime comparedTo, IFormatProvider formatProvider)
          {
               TimeSpan diff = comparedTo.Subtract(date);
               if (diff.TotalDays >= 365)
               {
                    return string.Concat("on ", date.ToString("MMMM d, yyyy", formatProvider));
               }
               if (diff.TotalDays >= 7)
               {
                    return string.Concat("on ", date.ToString("MMMM d", formatProvider));
               }
               else if (diff.TotalDays > 1)
               {
                    return string.Concat(diff.TotalDays.ToInt32().ToStringAsText(), " days ago");
               }
               else if (diff.TotalDays == 1)
               {
                    return "yesterday";
               }
               else if (diff.TotalHours >= 2)
               {
                    return string.Concat(diff.TotalHours.ToInt32().ToStringAsText(), " hours ago");
               }
               else if (diff.TotalMinutes >= 60)
               {
                    return "more than an hour ago";
               }
               else if (diff.TotalMinutes >= 5)
               {
                    return string.Concat(diff.TotalMinutes.ToInt32().ToStringAsText(), " minutes ago");
               }
               if (diff.TotalMinutes >= 1)
               {
                    return "a few minutes ago";
               }
               else
               {
                    return "less than a minute ago";
               }
          }

          /// <summary>
          /// Gets the last day in month.
          /// </summary>
          /// <param name="pdFecha">The pd fecha.</param>
          /// <returns></returns>
          public static System.DateTime GetLastDayInMonth(System.DateTime pdFecha)
          {
               return pdFecha.AddMonths(1).AddDays(-1);
          }

          #region Months

          /// <summary>
          /// Gets the start of month.
          /// </summary>
          /// <param name="penmMes">The penm mes.</param>
          /// <param name="year">The pi anio.</param>
          /// <returns></returns>
          public static DateTime GetStartOfMonth(MonthType penmMes, int year)
          {
               return new DateTime(year, (int)penmMes, 1, 0, 0, 0, 0);
          }

          /// <summary>
          /// Gets the end of month.
          /// </summary>
          /// <param name="penmMes">The penm mes.</param>
          /// <param name="year">The pi anio.</param>
          /// <returns></returns>
          public static DateTime GetEndOfMonth(MonthType penmMes, int year)
          {
               return new DateTime(year, (int)penmMes, DateTime.DaysInMonth(year, (int)penmMes), 23, 59, 59, 999);
          }

          /// <summary>
          /// Gets the start of last month.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetStartOfLastMonth()
          {
               if (DateTime.Now.Month == 1)
               {
                    return GetStartOfMonth((MonthType)12, DateTime.Now.Year - 1);
               }
               else
               {
                    return GetStartOfMonth((MonthType)(DateTime.Now.Month - 1), DateTime.Now.Year);
               }
          }

          /// <summary>
          /// Gets the end of last month.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetEndOfLastMonth()
          {
               if (DateTime.Now.Month == 1)
               {
                    return GetEndOfMonth((MonthType)12, DateTime.Now.Year - 1);
               }
               else
               {
                    return GetEndOfMonth((MonthType)(DateTime.Now.Month - 1), DateTime.Now.Year);
               }
          }

          /// <summary>
          /// Gets the start of current month.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetStartOfCurrentMonth()
          {
               return GetStartOfMonth((MonthType)DateTime.Now.Month, DateTime.Now.Year);
          }

          /// <summary>
          /// Gets the end of current month.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetEndOfCurrentMonth()
          {
               return GetEndOfMonth((MonthType)DateTime.Now.Month, DateTime.Now.Year);
          }

          #endregion Months

          #region Years

          /// <summary>
          /// Gets the start of year.
          /// </summary>
          /// <param name="year">The year.</param>
          /// <returns></returns>
          public static DateTime GetStartOfYear(int year)
          {
               return new DateTime(year, 1, 1, 0, 0, 0, 0);
          }

          /// <summary>
          /// Gets the end of year.
          /// </summary>
          /// <param name="year">The year.</param>
          /// <returns></returns>
          public static DateTime GetEndOfYear(int year)
          {
               return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
          }

          /// <summary>
          /// Gets the start of last year.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetStartOfLastYear()
          {
               return GetStartOfYear(DateTime.Now.Year - 1);
          }

          /// <summary>
          /// Gets the end of last year.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetEndOfLastYear()
          {
               return GetEndOfYear(DateTime.Now.Year - 1);
          }

          /// <summary>
          /// Gets the start of current year.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetStartOfCurrentYear()
          {
               return GetStartOfYear(DateTime.Now.Year);
          }

          /// <summary>
          /// Gets the end of current year.
          /// </summary>
          /// <returns></returns>
          public static DateTime GetEndOfCurrentYear()
          {
               return GetEndOfYear(DateTime.Now.Year);
          }

          #endregion Years

          #region Days

          /// <summary>
          /// Gets the start of day.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static DateTime GetStartOfDay(DateTime date)
          {
               return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
          }

          /// <summary>
          /// Gets the end of day.
          /// </summary>
          /// <param name="date">The date.</param>
          /// <returns></returns>
          public static DateTime GetEndOfDay(DateTime date)
          {
               return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
          }

          #endregion Days
     }
}