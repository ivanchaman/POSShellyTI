using Shelly.Abstractions.Enumerations;
using Shelly.Abstractions.Interfaces;
using System.Text;

namespace Shelly.Abstractions.Settings
{
     public class BaseSystem: IBaseSystem
     {
          #region Variables                    
          #endregion
          #region System configuration
         
          public Local LocalSettings { get; set; }
          public Session Session { get; set; }          
          public LoginInfo InfoSessionToken { get; set; }
          #endregion System configuration

          #region Connection to the data base          
          public IDataAccess Connection { get; set; }
          public ICacheContext Cache { get; set; }

          #endregion Connection to the data base

          #region System properties
          public int UtcOffsetMinutes { get; set; }
          public List<TermAndConditionDocument> TermsServices { get; set; }
          public bool HasTermsStatus { get; set; }
          public bool HasTwofactor { get; set; }
          public int PrimaryTwoFactor { get; set; }
          public string Left { get; set; }

          #endregion System properties

          #region Builders 
          public BaseSystem(IDataAccess dataAccess)
          {
               InternalBuilder();
               BuilderStringConnection(dataAccess);
          }
          public BaseSystem(IDataAccess dataAccess, ICacheContext cache)
          {
               Cache = cache;
               InternalBuilder();
               BuilderStringConnection(dataAccess);
          }
          
          #endregion Builders

          #region Functions         
          private void InternalBuilder()
          {
               LocalSettings = new Local();
               Session = new Session();
          }

          private void BuilderStringConnection(IDataAccess dataAccess)
          {
               Connection = dataAccess;
          }        

          #region Parameters
                 
          public void SetParameter(string parameterName, string value)
          {
               SetParameter(parameterName, value, "-");
          }
          public void SetParameter(string parameterName, string value, string description)
          {
               SetParameter(parameterName, value, description, Session.Company.Number);
          }

          public void SetParameter(string parameterName, string value, string description, long companyId)
          {
               StringBuilder query = new StringBuilder();               
               try
               {
                    query.AppendFormat("Update {0} set", Connection.TableName("Parameters"));
                    query.AppendFormat(" Value = @Value");                    
                    if (!string.IsNullOrEmpty(description))
                         query.AppendFormat(",Description = @Description");
                    query.AppendFormat(" Where Company = @Company");
                    query.AppendFormat(" And Parameter= @Parameter");
                    List<ParameterSql> parameter =
                    [
                         new ParameterSql("@Value", value),
                         new ParameterSql("@Company", companyId),
                         new ParameterSql("@Parameter", parameterName),
                    ];
                    if (!string.IsNullOrEmpty(description))
                         parameter.Add(new ParameterSql("@Description", description));
                    if (Connection.ExecuteCommand(query, parameter) == 0)
                    {
                         parameter =
                         [
                              new ParameterSql("@Value", value),
                              new ParameterSql("@Company", companyId),
                              new ParameterSql("@Parameter", parameterName),
                              !string.IsNullOrEmpty(description) ? new ParameterSql("@Description", description) : new ParameterSql("@Description", parameterName),
                         ];
                         query = new StringBuilder();
                         query.AppendFormat("Insert into {0} (Company,Parameter,Value,Description) ", Connection.TableName("Parameters"));
                         query.AppendFormat("Values(@Company,@Parameter,@Value,@Description)");
                         Connection.ExecuteCommand(query, parameter);
                    }
               }
               catch
               {
                    throw;
               }
          }

          public T GetParameter<T>(string parameterName)
          {
               return GetParameter<T>(parameterName, Session.Company.Number);
          }                            
          public T GetParameter<T>(string parameterName, long companyId)
          {
               try
               {
                    StringBuilder query = new StringBuilder();
                    List<ParameterSql> parameter = new List<ParameterSql>
                    {
                         new ParameterSql("@Company", companyId),
                         new ParameterSql("@Parameter", parameterName)
                    };
                    query.AppendFormat("Select ");
                    switch (Connection.DataBase.Engine)
                    {
                         case DataBaseType.SqlServer:
                              query.AppendFormat(" top 1 ");
                              break;
                         case DataBaseType.MySql:
                         case DataBaseType.PostgressSql:
                              break;
                    }
                    query.AppendFormat(" Value From {0}", Connection.TableName("Parameters"));
                    query.AppendFormat(" Where Company in (0,@Company)");
                    query.AppendFormat(" AND Upper(Parameter) = Upper(@Parameter)");
                    query.Append(" Order by Parameter desc");
                    switch (Connection.DataBase.Engine)
                    {
                         case DataBaseType.SqlServer:
                              break;
                         case DataBaseType.MySql:
                         case DataBaseType.PostgressSql:
                              query.AppendFormat(" Limit 1 ");
                              break;
                    }
                    return Connection.ExecuteScalar<T>(query, parameter);
               }
               catch
               {
                    throw;
               }
          }
        
          public void GetParameter<T>(string parameterName, out T value)
          {
               value = GetParameter<T>(parameterName, Session.Company.Number);
          }


          #endregion parametros
          #region Log
          /// <summary>
          /// Funcion que graba en algun error en el LOG
          /// </summary>
          /// <param name="exception">Valor del LOG</param>
          public void WriteLog(Exception exception)
          {
               Connection.RecordLog(exception);
          }
          public void WriteLog(string exception)
          {
               Connection.RecordLog(exception);
          }
          /// <summary>
          /// Grabas the log.
          /// </summary>
          /// <param name="exception">The po exception.</param>
          /// <param name="query">The ls query.</param>
          public void WriteLog(Exception exception, string query)
          {
               Connection.RecordLog(exception, query);
          }

          /// <summary>
          /// Grabas the log.
          /// </summary>
          /// <param name="exception">The po exception.</param>
          /// <param name="query">The ls query.</param>
          public void WriteLog(Exception exception, StringBuilder query)
          {
               Connection.RecordLog(exception, query);
          }

          /// <summary>
          /// Grabas the log.
          /// </summary>
          /// <param name="exception">The po exception.</param>
          /// <param name="query">The ls query.</param>
          public void WriteLog(Exception exception, List<StringBuilder> query)
          {
               Connection.RecordLog(exception, query);
          }
          #endregion

          #endregion Functions
     }
}