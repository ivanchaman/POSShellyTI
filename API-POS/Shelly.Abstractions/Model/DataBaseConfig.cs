using Shelly.Abstractions.Enumerations;
using System.Text;

namespace Shelly.Abstractions.Model
{
     /// <summary>
     /// DataBaseConfig
     /// </summary>
     [Serializable]
     public class DataBaseConfig
     {
          #region Properties

          /// <summary>
          /// Gets or sets the servidor vinculado.
          /// </summary>
          /// <value>
          /// The servidor vinculado.
          /// </value>
          public string LinkedServer { get; set; }

          /// <summary>
          /// Gets or sets the nombre.
          /// </summary>
          /// <value>
          /// The nombre.
          /// </value>
          public string Server { get; set; }

          /// <summary>
          ///
          /// </summary>
          public string Catalog { get; set; }

          /// <summary>
          /// Gets or sets the bitacora.
          /// </summary>
          /// <value>
          /// The bitacora.
          /// </value>
          public string LogData { get; set; }

          /// <summary>
          /// Gets or sets the collation.
          /// </summary>
          /// <value>
          /// The collation.
          /// </value>
          public string Collation { get; set; }

          /// <summary>
          /// Gets or sets the usuario.
          /// </summary>
          /// <value>
          /// The usuario.
          /// </value>
          public string User { get; set; }

          /// <summary>
          /// Gets or sets the contraseña.
          /// </summary>
          /// <value>
          /// The contraseña.
          /// </value>
          public string Password { get; set; }

          /// <summary>
          ///
          /// </summary>
          public bool FilterCompanies { get; set; }

          /// <summary>
          ///
          /// </summary>
          public string EmpoyeeTable { get; set; }

          /// <summary>
          ///
          /// </summary>
          public string AreaBranchOfficeTable { get; set; }

          /// <summary>
          ///
          /// </summary>
          public string Url { get; set; }

          /// <summary>
          ///
          /// </summary>
          public string SqlVersion { get; set; }         

          /// <summary>
          /// Gets or sets the propietario.
          /// </summary>
          /// <value>
          /// The propietario.
          /// </value>
          public string Owner { get; set; }

          /// <summary>
          /// Gets or sets the prefijo.
          /// </summary>
          /// <value>
          /// The prefijo.
          /// </value>
          public string Prefix { get; set; }

          /// <summary>
          /// Gets or sets the posfijo object.
          /// </summary>
          /// <value>
          /// The posfijo object.
          /// </value>
          public string Postfix { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether [seguridad integrada].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [seguridad integrada]; otherwise, <c>false</c>.
          /// </value>
          public bool IntegratedSecurity { get; set; }

          /// <summary>
          /// Gets or sets the nivel compatibilidad.
          /// </summary>
          /// <value>
          /// The nivel compatibilidad.
          /// </value>
          public int CompatibilityLevel { get; set; }

          /// <summary>
          /// Gets or sets the cadena conexion.
          /// </summary>
          /// <value>
          /// The cadena conexion.
          /// </value>
          public string StringConnection { get; set; }

          /// <summary>
          /// Tipo de motor de base de datos (1=Access,2=SQL)
          /// </summary>
          public DataBaseType Engine { get; set; }

          /// <summary>
          /// Prefijo para la las base datos
          /// </summary>
          public string DataBaseObjectPrefixLogData
          {
               get
               {
                    return "xsH";
               }
          }         

          /// <summary>
          /// Gets or sets a value indicating whether [usa parametros SQL].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [usa parametros SQL]; otherwise, <c>false</c>.
          /// </value>
          public bool UseSqlParameters { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether [existe conexion a la bd].
          /// </summary>
          /// <value>
          ///   <c>true</c> if [existe conexion bd]; otherwise, <c>false</c>.
          /// </value>
          public bool ExistsConnection { get; set; }

          #endregion Properties

          /// <summary>
          /// Initializes a new instance of the <see cref="DataBaseConfig"/> class.
          /// </summary>
          public DataBaseConfig()
          {
              
          }

          /// <summary>
          /// TableName
          /// </summary>
          /// <param name="tableName"></param>
          /// <param name="usePrefixObject"></param>
          /// <param name="isHistoryCatalog"></param>
          /// <param name="isHistoryTable"></param>
          /// <returns></returns>
          public string TableName(string tableName, bool usePrefixObject, bool isHistoryCatalog, bool isHistoryTable)
          {
               string catalogName;
               string localTableName;
               StringBuilder stringName;
               if (isHistoryCatalog)
                    catalogName = LogData;
               else
                    catalogName = Catalog;
               if (isHistoryTable)
                    localTableName = string.Format("{0}{1}{2}{3}", usePrefixObject ? Prefix : "", DataBaseObjectPrefixLogData, tableName, Convert.ToString(Postfix));
               else
               {
                    localTableName = string.Format("{0}{1}{2}", usePrefixObject ? Prefix : "", tableName, Convert.ToString(Postfix));
               }
               if (String.IsNullOrEmpty(Owner))
                    Owner = "dbo";
               stringName = new StringBuilder();
               switch (Engine)
               {
                    case DataBaseType.SqlServer:
                         if (!string.IsNullOrEmpty(LinkedServer))
                              stringName.AppendFormat("[{0}].", LinkedServer);
                         stringName.AppendFormat("[{0}].[{1}].[{2}]", catalogName, Owner, localTableName);
                         break;
                    case DataBaseType.MySql:
                         stringName.AppendFormat("`{0}`", localTableName);
                         break;
                    case DataBaseType.PostgressSql:
                         stringName.AppendFormat("{0}.{1}", Owner, localTableName);
                         break;
                    default:
                         stringName.AppendFormat("[{0}].[{1}].[{2}]", catalogName, Owner, localTableName);
                         break;
               }
               return stringName.ToString();
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="tableName">Name of the table.</param>
          /// <param name="usePrefixObject">if set to <c>true</c> [use prefix object].</param>
          /// <param name="isHistoryCatalog">if set to <c>true</c> [is history catalog].</param>
          /// <returns></returns>
          public string TableName(string tableName, bool usePrefixObject, bool isHistoryCatalog)
          {
               return TableName(tableName, usePrefixObject, isHistoryCatalog, false);
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="tableName">Name of the table.</param>
          /// <param name="usePrefixObject">if set to <c>true</c> [use prefix object].</param>
          /// <returns></returns>
          public string TableName(string tableName, bool usePrefixObject)
          {
               return TableName(tableName, usePrefixObject, false, false);
          }

          /// <summary>
          /// Tables the name.
          /// </summary>
          /// <param name="tableName">Name of the table.</param>
          /// <returns></returns>
          public string TableName(string tableName)
          {
               return TableName(tableName, true, false, false);
          }
              
         
     }
}