using System.Text;

namespace Shelly.Abstractions.Interfaces
{
    public interface IDataAccess
    {         
          public DataBaseConfig DataBase { get; set; }
        
          public List<T> GetGenericListData<T>(StringBuilder query) where T : class, new();
          
          public List<T> GetGenericListData<T>(StringBuilder query, IEnumerable<ParameterSql> IEnumSqlParameters) where T : class, new();

          public HashSet<T> GetGenericFieldBasedCollection<T>(StringBuilder query, string field);

          public HashSet<T> GetGenericFieldBasedCollection<T>(StringBuilder query, string field, IEnumerable<ParameterSql> IEnumSqlParameters);

          public List<T> GetGenericFieldBasedList<T>(StringBuilder query, string field);

          public List<T> GetGenericFieldBasedList<T>(StringBuilder query, string field, IEnumerable<ParameterSql> IEnumSqlParameters);

          public HashSet<T> GetGenericCollectionData<T>(StringBuilder query) where T : class, new();

          public HashSet<T> GetGenericCollectionDataReader<T>(StringBuilder query) where T : class, new();    

          public HashSet<T> GetGenericCollectionData<T>(StringBuilder query, IEnumerable<ParameterSql> IEnumSqlParameters) where T : class, new();


          public int ExecuteCommand(StringBuilder query, IEnumerable<ParameterSql> parameters);

          public int ExecuteCommand(StringBuilder psQuery, IEnumerable<ParameterSql> parameters, bool unlimited);

          public int ExecuteCommand(StringBuilder query);

          public object ExecuteScalar(StringBuilder query, IEnumerable<ParameterSql> IEnmSqlParameters);

          public object ExecuteScalar(StringBuilder query);
          public T ExecuteScalar<T>(StringBuilder query);
          public T ExecuteScalar<T>(StringBuilder query, IEnumerable<ParameterSql> IEnmSqlParameters);

          public object StoreProcedureExecuteScalar(string storeName, IEnumerable<ParameterSql> IEnmSqlParameters);
          public object StoreProcedureExecuteScalar(string storeName);

          public T StoreProcedureExecuteScalar<T>(string storeName, IEnumerable<ParameterSql> IEnmSqlParameters);
          public T StoreProcedureExecuteScalar<T>(string storeName);

          public void InsertBulkCopy<T>(IEnumerable<T> IEnmTargetTable, string targetTableName);

          public string TableName(string tableName, bool containPrefix, bool catalogContainsHistory, bool isHistoryTable);

          public string TableName(string tableName, bool containPrefix, bool catalogContainsHistory);

          public string TableName(string tableName, bool containPrefix);

          public string TableName(string tableName);

          public void RecordLog(Exception exception, String query);

          public void RecordLog(Exception ex, StringBuilder query);

          public void RecordLog(Exception exception);

          public void RecordLog(Exception exception, List<StringBuilder> queryList);
          public void RecordLog(string exception);
     }
}
