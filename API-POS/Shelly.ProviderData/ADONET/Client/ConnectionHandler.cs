

namespace Shelly.ProviderData.ADONET.Client
{
     /// <summary>
     /// Clase para el manejo de la conexion a la base de datos
     /// </summary>
     public class ConnectionHandler : IDisposable
     {
          #region Objetos de conexion

          /// <summary>
          /// The o current scope
          /// </summary>
          [ThreadStatic]
          private static ConnectionHandler _oCurrentScope;

          /// <summary>
          /// The current SQL server transaction
          /// </summary>
          [ThreadStatic]
          private static IDbTransaction _CurrentSqlTransaction;

          /// <summary>
          /// The current SQL server connection
          /// </summary>
          [ThreadStatic]
          private static IDbConnection _CurrentSqlConnection;

          /// <summary>
          /// La cadena de conecion no es thread static Cadena de coenxion
          /// </summary>
          [ThreadStatic]
          private static string _StringConnection;

          /// <summary>
          /// Para el motor de la base de datos a la que se conectara
          /// </summary>
          [ThreadStatic]
          private static DataBaseType _DatabaseEngines;

          #endregion Objetos de conexion

          #region Variables

          /// <summary>
          /// _isDisposed
          /// </summary>
          private bool _isDisposed;

          /// <summary>
          /// Esta variable es para determinar quien fue la primera instancia. Ya que esta tendra un false como valor.
          /// Y se encargara de hacer el Dispose de la conexion
          /// </summary>
          private readonly bool _isNested;

          #endregion Variables

          #region Propiedades

          /// <summary>
          /// Gets the current scope.
          /// </summary>
          /// <value>
          /// The current scope.
          /// </value>
          public static ConnectionHandler CurrentScope
          {
               get
               {
                    return _oCurrentScope;
               }
          }

          /// <summary>
          /// Gets the curren SQL server transaction.
          /// </summary>
          /// <value>
          /// The curren SQL server transaction.
          /// </value>
          public static IDbTransaction CurrenSqlTransaction
          {
               get
               {
                    return _CurrentSqlTransaction;
               }
          }

          /// <summary>
          /// Gets the current SQL serve connection.
          /// </summary>
          /// <value>
          /// The current SQL serve connection.
          /// </value>
          public static IDbConnection CurrentSqlConnection
          {
               get
               {
                    return _CurrentSqlConnection;
               }
          }

          #endregion Propiedades

          #region Constructores
          public ConnectionHandler(IDataAccess connection) : this(connection.DataBase.StringConnection, connection.DataBase.Engine)
          {
          }
          /// <summary>
          /// Initializes a new instance of the <see cref="ConnectionHandler"/> class.
          /// </summary>
          /// <param name="connection">The po conexion.</param>
          public ConnectionHandler(DataAccess connection) : this(connection.DataBase.StringConnection, connection.DataBase.Engine)
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="ConnectionHandler"/> class.
          /// </summary>
          public ConnectionHandler() : this(_StringConnection, _DatabaseEngines)
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="ConnectionHandler"/> class.
          /// </summary>
          /// <param name="stringConnection">The ps cadena conexion.</param>
          /// <param name="DataBaseType">The penm motor.</param>
          public ConnectionHandler(string stringConnection, DataBaseType DataBaseType)
          {
               _StringConnection = stringConnection;
               _DatabaseEngines = DataBaseType;
               if (!Equals(_oCurrentScope, null) && !_oCurrentScope._isDisposed)
               {
                    //ConexionActual = _currentScope.ConexionActual;
                    _isNested = true;
                    //_bConexionAbierta = true;
               }
               else
               {
                    StartConnection();
                    Thread.BeginThreadAffinity();
                    _oCurrentScope = this;
               }
          }

          #endregion Constructores

          #region Manejo de conexiones y transacciones

          /// <summary>
          /// Inicia la conexion a la base de datos
          /// </summary>
          private static void StartConnection()
          {
               //Crear la nueba conecion de datos
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         _CurrentSqlConnection = new SqlConnection(_StringConnection);
                         break;
                         //case DataBaseType.MySql:
                         //     _CurrentSqlConnection = new MySqlConnection(_StringConnection);
                         //     break;
                         //case DataBaseType.PostgressSql:
                         //     _CurrentSqlConnection = new NpgsqlConnection(_StringConnection);
                         //     break;
                         //case DataBaseType.Oracle:
                         //     _CurrentSqlConnection = new OracleConnection(_StringConnection);
                         //     break;
                         //case DataBaseType.Odbc:
                         //     _CurrentSqlConnection = new OdbcConnection(_StringConnection);
                         //     break;
                         //case DataBaseType.OleDb:
                         //     _CurrentSqlConnection = new OleDbConnection(_StringConnection);
                         //     break;
               }
               if (_CurrentSqlConnection.State != ConnectionState.Open)
                    _CurrentSqlConnection.Open();
          }

          /// <summary>
          /// Metodo para heredar a la conexion una transaccion
          /// </summary>
          public static void BeginTransaction()
          {
               if (CurrentScope == null)
                    return;

               if (_CurrentSqlTransaction != null)
                    return;
               var connectionsql = CurrentSqlConnection;
               if (connectionsql.State == ConnectionState.Closed)
               {
                    connectionsql.Open();
               }
               _CurrentSqlTransaction = connectionsql.BeginTransaction();
          }

          /// <summary>
          /// Funcion para confirmar la transaccion
          /// </summary>
          public static void CommitTransaction()
          {
               if (_CurrentSqlTransaction == null)
                    return;
               _CurrentSqlTransaction.Commit();
               _CurrentSqlTransaction = null;
          }

          /// <summary>
          /// Fncion a para deshacer la transaccion
          /// </summary>
          public static void RollbackTransaction()
          {
               try
               {
                    if (_CurrentSqlTransaction == null)
                         return;
                    _CurrentSqlTransaction.Rollback();

               }
               catch
               {

               }
               finally
               {
                    _CurrentSqlTransaction = null;
               }
          }

          /// <summary>
          /// Libera lso recursos de la conexion
          /// </summary>
          public void Dispose()
          {
               if (!_isNested && !_isDisposed)
               {
                    switch (_DatabaseEngines)
                    {
                         default:
                              if (_CurrentSqlTransaction != null)
                              {
                                   _CurrentSqlTransaction.Dispose();
                                   _CurrentSqlTransaction = null;
                              }
                              if (_CurrentSqlConnection != null)
                              {
                                   _CurrentSqlConnection.Close();
                                   _CurrentSqlConnection.Dispose();
                                   _CurrentSqlConnection = null;
                              }
                              break;
                    }
                    _oCurrentScope = null;
                    GC.SuppressFinalize(this);
                    Thread.EndThreadAffinity();
                    _isDisposed = true;
               }
          }

          #endregion Manejo de conexiones y transacciones

          #region Dataset

          /// <summary>
          /// Fills the dataset.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="psTabla">The ps tabla.</param>
          /// <returns></returns>
          public static DataSet FillDataset(StringBuilder query, string psTabla)
          {
               DataSet ldtsResultado = new DataSet();
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              SqlServerHelper.FillDataset((SqlConnection)_CurrentSqlConnection, CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         else
                              SqlServerHelper.FillDataset((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         break;

                         //case DataBaseType.MySql:
                         //     if (_CurrentSqlTransaction == null)
                         //          MySqlHelper.FillDataset((MySqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     else
                         //          MySqlHelper.FillDataset((MySqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     break;

                         //case DataBaseType.PostgressSql:
                         //     if (_CurrentSqlTransaction == null)
                         //          PostgresSQLHelper.FillDataset((NpgsqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     else
                         //          PostgresSQLHelper.FillDataset((NpgsqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.Oracle:
                         //     if (_CurrentSqlTransaction == null)
                         //          OracleHelper.FillDataset((OracleConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     else
                         //          OracleHelper.FillDataset((OracleTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.Odbc:
                         //     if (_CurrentSqlTransaction == null)
                         //          OdbcHelper.FillDataset((OdbcConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     else
                         //          OdbcHelper.FillDataset((OdbcTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.OleDb:
                         //     if (_CurrentSqlTransaction == null)
                         //          OleDbHelper.FillDataset((OleDbConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     else
                         //          OleDbHelper.FillDataset((OleDbTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtsResultado, new string[] { psTabla });
                         //     break;
               }
               return ldtsResultado;
          }

          #endregion Dataset

          #region DataReader

          /// <summary>
          /// Fills the data reader.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <returns></returns>
          public static IDataReader FillDataReader(StringBuilder query)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.FillDataReader((SqlConnection)_CurrentSqlConnection, CommandType.Text, query);
                         else
                              return SqlServerHelper.FillDataReader((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query);
                         //case DataBaseType.MySql:
                         //     if (_CurrentSqlTransaction == null)
                         //          return MySqlHelper.FillDataReader((MySqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query);
                         //     else
                         //          return MySqlHelper.FillDataReader((MySqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query);
                         //case DataBaseType.PostgressSql:
                         //     if (_CurrentSqlTransaction == null)
                         //          return PostgresSQLHelper.FillDataReader((NpgsqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query);
                         //     else
                         //          return PostgresSQLHelper.FillDataReader((NpgsqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query);
                         //case DataBaseType.Oracle:
                         //     if (_CurrentSqlTransaction == null)
                         //          return OracleHelper.FillDataReader((OracleConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query);
                         //     else
                         //          return OracleHelper.FillDataReader((OracleTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query);
                         //case DataBaseType.Odbc:
                         //     if (_CurrentSqlTransaction == null)
                         //          OdbcHelper.FillDataReader((OdbcConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query);
                         //     else
                         //          OdbcHelper.FillDataReader((OdbcTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query);
                         //     break;
                         //case DataBaseType.OleDb:
                         //     if (_CurrentSqlTransaction == null)
                         //          OleDbHelper.FillDataReader((OleDbConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query);
                         //     else
                         //          OleDbHelper.FillDataReader((OleDbTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query);
                         //     break;
               }
               return null;
          }

          /// <summary>
          /// Fills the data reader.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <returns></returns>
          public static IDataReader FillDataReader(StringBuilder query, IEnumerable<ParameterSql> parameters)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.FillDataReader((SqlConnection)_CurrentSqlConnection, CommandType.Text, query, parameters);
                         else
                              return SqlServerHelper.FillDataReader((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query, parameters);

               }
               return null;
          }
          public static IDataReader FillDataReader(StringBuilder query, IEnumerable<ParameterSql> parameters, CommandType commandType)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                    default:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.FillDataReader((SqlConnection)_CurrentSqlConnection, commandType, query, parameters);
                         else
                              return SqlServerHelper.FillDataReader((SqlTransaction)_CurrentSqlTransaction, commandType, query, parameters);

               }
          }
          #endregion DataReader

          #region DataTable

          /// <summary>
          /// Fills the data table.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="psTabla">The ps tabla.</param>
          /// <returns></returns>
          public static DataTable FillDataTable(StringBuilder query, string psTabla)
          {
               DataTable ldtResultado = new DataTable();
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              SqlServerHelper.FillDataTable((SqlConnection)_CurrentSqlConnection, CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         else
                              SqlServerHelper.FillDataTable((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         break;

                         //case DataBaseType.MySql:
                         //     if (_CurrentSqlTransaction == null)
                         //          MySqlHelper.FillDataTable((MySqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     else
                         //          MySqlHelper.FillDataTable((MySqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     break;

                         //case DataBaseType.PostgressSql:
                         //     if (_CurrentSqlTransaction == null)
                         //          PostgresSQLHelper.FillDataTable((NpgsqlConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     else
                         //          PostgresSQLHelper.FillDataTable((NpgsqlTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.Oracle:
                         //     if (_CurrentSqlTransaction == null)
                         //          OracleHelper.FillDataTable((OracleConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     else
                         //          OracleHelper.FillDataTable((OracleTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.Odbc:
                         //     if (_CurrentSqlTransaction == null)
                         //          OdbcHelper.FillDataTable((OdbcConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     else
                         //          OdbcHelper.FillDataTable((OdbcTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     break;
                         //case DataBaseType.OleDb:
                         //     if (_CurrentSqlTransaction == null)
                         //          OleDbHelper.FillDataTable((OleDbConnection)_CurrentSqlConnection, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     else
                         //          OleDbHelper.FillDataTable((OleDbTransaction)_CurrentSqlTransaction, System.Data.CommandType.Text, query.ToString(), ldtResultado, new string[] { psTabla });
                         //     break;
               }
               return ldtResultado;
          }

          /// <summary>
          /// Fills the data table.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <returns></returns>
          public static DataTable FillDataTable(StringBuilder query)
          {
               return FillDataTable(query, "Tabla");
          }

          /// <summary>
          /// Fills the data table.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <returns></returns>
          public static DataTable FillDataTable(StringBuilder query, IEnumerable<ParameterSql> parameters)
          {
               DataTable ldtResultado = new DataTable();
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              SqlServerHelper.FillDataTable((SqlConnection)_CurrentSqlConnection, CommandType.Text, query, ldtResultado, parameters);
                         else
                              SqlServerHelper.FillDataTable((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query, ldtResultado, parameters);
                         break;

               }
               return ldtResultado;
          }

          #endregion DataTable

          #region Ejecuta comando

          /// <summary>
          /// Executes the non query.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <returns></returns>
          public static int ExecuteNonQuery(StringBuilder query)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.ExecuteNonQuery((SqlConnection)_CurrentSqlConnection, CommandType.Text, query.ToString());
                         else
                              return SqlServerHelper.ExecuteNonQuery((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query.ToString());

               }
               return 0;
          }

          /// <summary>
          /// Ejecutas the comando.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <param name="pbIlimitado">if set to <c>true</c> [pb ilimitado].</param>
          public static int ExecuteNonQuery(StringBuilder query, IEnumerable<ParameterSql> parameters, bool pbIlimitado)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.ExecuteNonQuery((SqlConnection)_CurrentSqlConnection, CommandType.Text, query, parameters, pbIlimitado);
                         else
                              return SqlServerHelper.ExecuteNonQuery((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query, parameters, pbIlimitado);

               }
               return 0;
          }

          /// <summary>
          /// Executes the non query.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <returns></returns>
          public static int ExecuteNonQuery(StringBuilder query, IEnumerable<ParameterSql> parameters)
          {
               return ExecuteNonQuery(query, parameters, true);
          }



          #endregion Ejecuta comando

          #region Ejectua escalar

          /// <summary>
          /// Ejecutas the escalar.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <returns></returns>
          public static object ExecuteScalar(StringBuilder query, IEnumerable<ParameterSql> parameters)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.ExecuteScalar((SqlConnection)_CurrentSqlConnection, CommandType.Text, query, parameters);
                         else
                              return SqlServerHelper.ExecuteScalar((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query, parameters);

               }
               return null;
          }

          /// <summary>
          /// Ejecutas the escalar.
          /// </summary>
          /// <param name="query">The ps query.</param>
          /// <returns></returns>
          public static object ExecuteScalar(StringBuilder query)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.ExecuteScalar((SqlConnection)_CurrentSqlConnection, CommandType.Text, query.ToString());
                         else
                              return SqlServerHelper.ExecuteScalar((SqlTransaction)_CurrentSqlTransaction, CommandType.Text, query.ToString());


               }
               return null;
          }

          #endregion Ejectua escalar

          #region Store procedure

          /// <summary>
          /// Ejecutas the comando procedimiento almacenado.
          /// </summary>
          /// <param name="psNombre">The ps nombre.</param>
          /// <returns></returns>
          public static int StoreProcedureExecuteNonQuery(string psNombre)
          {
               return StoreProcedureExecuteNonQuery(psNombre, null);
          }

          /// <summary>
          /// Ejecutas the sp.
          /// </summary>
          /// <param name="psNombre">The ps nombre.</param>
          /// <param name="parameters">The po parametros.</param>
          public static int StoreProcedureExecuteNonQuery(string psNombre, IEnumerable<ParameterSql> parameters)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.StoreProcedureExecuteNonQuery((SqlConnection)_CurrentSqlConnection, CommandType.StoredProcedure, psNombre, parameters);
                         else
                              return SqlServerHelper.StoreProcedureExecuteNonQuery((SqlTransaction)_CurrentSqlTransaction, CommandType.StoredProcedure, psNombre, parameters);


               }
               return 0;
          }

          /// <summary>
          /// Ejecutas the escalar procedimiento almacenado.
          /// </summary>
          /// <param name="psNombre">The ps nombre.</param>
          /// <returns></returns>
          public static object StoreProcedureExecuteScalar(string psNombre)
          {
               return StoreProcedureExecuteScalar(psNombre, null);
          }

          /// <summary>
          /// Ejecutas the escalar procedimiento almacenado.
          /// </summary>
          /// <param name="psNombre">The ps nombre.</param>
          /// <param name="parameters">The po parametros.</param>
          /// <returns></returns>
          public static object StoreProcedureExecuteScalar(string psNombre, IEnumerable<ParameterSql> parameters)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                         if (_CurrentSqlTransaction == null)
                              return SqlServerHelper.StoreProcedureExecuteScalar((SqlConnection)_CurrentSqlConnection, CommandType.StoredProcedure, psNombre, parameters);
                         else
                              return SqlServerHelper.StoreProcedureExecuteScalar((SqlTransaction)_CurrentSqlTransaction, CommandType.StoredProcedure, psNombre, parameters);


               }
               return null;
          }

          #endregion Store procedure

          #region Bulkcopy

          /// <summary>
          /// Inserts the bulk copy.
          /// </summary>
          /// <param name="pdtTablaOrigen">The PDT tabla origen.</param>
          /// <param name="psTablaDestino">The ps tabla destino.</param>
          public static void InsertBulkCopy(DataTable pdtTablaOrigen, string psTablaDestino)
          {
               switch (_DatabaseEngines)
               {
                    case DataBaseType.SqlServer:
                    case DataBaseType.MySql:
                    case DataBaseType.PostgressSql:
                    case DataBaseType.Oracle:
                    case DataBaseType.Odbc:
                    case DataBaseType.OleDb:
                         InsertBuilkCopyByRows(pdtTablaOrigen, psTablaDestino);
                         break;
               }
          }
          private static void InsertBuilkCopyByRows(DataTable pdtTablaOrigen, string psTablaDestino)
          {
               StringBuilder query = new StringBuilder();
               StringBuilder columns = new StringBuilder();
               StringBuilder rows = new StringBuilder();
               List<ParameterSql> parameters;
               query.AppendFormat("Insert into {0}", psTablaDestino);
               foreach (DataColumn column in pdtTablaOrigen.Columns)
               {
                    columns.AppendFormat("{0},", column.ColumnName);
                    rows.AppendFormat("@{0},", column.ColumnName);
               }
               query.AppendFormat(" ({0}) values({1}) ", columns.Remove(columns.Length - 1, 1), rows.Remove(rows.Length - 1, 1));
               foreach (DataRow row in pdtTablaOrigen.Rows)
               {
                    parameters = new List<ParameterSql>();
                    foreach (DataColumn column in pdtTablaOrigen.Columns)
                    {
                         parameters.Add(new ParameterSql($"@{column.ColumnName}", row[column.ColumnName]));
                    }
                    ExecuteNonQuery(query, parameters);
               }
          }

          private static void OriginalInsertBuilkCopy(DataTable pdtTablaOrigen, string psTablaDestino)
          {
               if (_CurrentSqlTransaction != null)
               {
                    using (SqlBulkCopy loBulkCopy = new SqlBulkCopy((SqlConnection)_CurrentSqlConnection, SqlBulkCopyOptions.Default, (SqlTransaction)_CurrentSqlTransaction))
                    {
                         loBulkCopy.BatchSize = pdtTablaOrigen.Rows.Count;
                         loBulkCopy.DestinationTableName = psTablaDestino;
                         loBulkCopy.BulkCopyTimeout = 0;
                         loBulkCopy.WriteToServer(pdtTablaOrigen);
                    }
               }
               else
               {
                    using (SqlBulkCopy loBulkCopy = new SqlBulkCopy((SqlConnection)_CurrentSqlConnection))
                    {
                         loBulkCopy.NotifyAfter = 1;
                         loBulkCopy.BatchSize = pdtTablaOrigen.Rows.Count;
                         loBulkCopy.DestinationTableName = psTablaDestino;
                         loBulkCopy.BulkCopyTimeout = 0;
                         loBulkCopy.WriteToServer(pdtTablaOrigen);
                    }
               }
          }
          #endregion Bulkcopy
     }
}