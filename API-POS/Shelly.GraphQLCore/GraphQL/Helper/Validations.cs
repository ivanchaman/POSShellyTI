using Shelly.GraphQLCore.Configuration;

namespace Shelly.GraphQLCore.GraphQL.Helper
{
     public class Validations
     {
          private HttpRequest _request;
          private DataAccess _dbcontext;
          private ICacheContext _cache;

          public Validations(HttpRequest request, DataAccess dbcontext, ICacheContext cache)
          {
               _request = request;
               _cache = cache;
               _dbcontext = dbcontext;
          }
          public bool IsHeaderValid(out GraphQLQuery query, out LoginInfo? loginInfo, out string error, out string additionalMessage)
          {
               loginInfo = null;
               bool result = IsHeaderValid(out query, out error, out additionalMessage);
               if (!result)
                    return result;
               loginInfo = GetInfoLoggin(GetToken(), out error);
               if (loginInfo == null || !string.IsNullOrEmpty(error))
                    return false;
               return result;
          }
          public bool IsHeaderValid(out LoginInfo? loginInfo, out string error)
          {
               loginInfo = GetInfoLoggin(GetToken(), out error);
               if (loginInfo == null || !string.IsNullOrEmpty(error))
                    return false;
               return true;
          }
          public bool IsHeaderValid(out GraphQLQuery query, out string error, out string additionalMessage)
          {
               error = Errors.E00000000;
               if (!GraphQlTools.GetInfoQuery(out query, _request))
               {
                    additionalMessage = "Q";
                    LogInfoRequest(query, Errors.E00000000, "q", "", 0);
                    return false;
               }
               if (!ValidateHeader(query, out string contentHash, out double diff, out additionalMessage))
                    return false;
               //if (!ValidateUserAgent(query, contentHash, diff, out additionalMessage))
               //     return false;
               error = "";
               LogInfoRequest(query, "", "", contentHash, diff);
               return true;
          }
          public T GetParameter<T>(string parameterName)
          {
               StringBuilder query = new StringBuilder();
               List<ParameterSql> parameter = [new ParameterSql("@Parameter", parameterName)];
               query.AppendFormat("Select top 1 Value From  [dbo].[Parameters]");
               query.AppendFormat(" Where Company = 0");
               query.AppendFormat(" AND Upper(Parameter) = Upper(@Parameter)");
               query.Append(" Order by Company desc");
               return _dbcontext.ExecuteScalar<T>(query, parameter);

          }
          private bool ValidateHeader(GraphQLQuery query, out string contentHash, out double diff, out string error)
          {
               contentHash = Cipher.DecryptPEMNetWork(_request.GetHeaderValue("content-hash"));
               diff = 0;
               error = "";
               if (string.IsNullOrEmpty(_request.GetHeaderValue("hash-id")))
               {
                    error = "A";
                    ReadToken(query, contentHash, 0);
                    return false;
               }
               if (!GetParameter<string>("ContentHash").ToBoolean())
               {
                    return true;
               }                        
               if (string.IsNullOrEmpty(contentHash) || !contentHash.Contains("|"))
               {
                    error = "E";
                    ReadToken(query, contentHash, 0);
                    return false;
               }
               string devices = GetParameter<string>("ContentHashDevices");
               var content = contentHash.Split('|');
               if (content.Length != 2 && !devices.Contains(content[0]))
               {
                    error = "F";
                    ReadToken(query, contentHash, 0);
                    return false;
               }
               string valuedate = content[1];
               var value = long.TryParse(valuedate, out long number);
               double time = GetParameter<double>("ContentHashTime");
               diff = Math.Abs((DateTime.Now.ToUniversalTime() - new DateTime(number)).TotalMilliseconds);
               if (!value || diff > time)
               {
                    error = "G";
                    ReadToken(query, contentHash, diff);
                    return false;
               }
               return true;
          }

          public bool ValidateUserAgent(GraphQLQuery query, string contentHash, double diff, out string error)
          {
               string agents = GetParameter<string>("ContentHashUserAgents");
               string userAgent = _request.GetHeaderValue("User-Agent");
               error = "";
               if (string.IsNullOrEmpty(userAgent))
               {
                    error = "H";
                    LogInfoRequest(query, Errors.E00000000, "agent", contentHash, diff);
                    return false;
               }
               if (userAgent.Contains("okhttp"))
               {
                    error = "I";
                    LogInfoRequest(query, Errors.E00000000, "agent", contentHash, diff);
                    return false;
               }
               foreach (string agent in agents.Split(','))
               {
                    if (string.IsNullOrEmpty(agent))
                         continue;
                    if (userAgent.StartsWith(agent, StringComparison.OrdinalIgnoreCase))
                         return true;
               }
               error = "J";
               LogInfoRequest(query, Errors.E00000000, "agent", contentHash, diff);
               return false;
          }

          private bool GetValidateUrl()
          {
               string url = $"{_request.Scheme}://{_request.Host}{_request.Path}{_request.QueryString.Value}";
               StringBuilder query = new StringBuilder();
               List<ParameterSql> parameters = [new ParameterSql("@valor", url)];
               query.AppendFormat(" SELECT count(*) FROM [dbo].[Parameters] where parameter like '%UrlApiV3%' and value = @valor ");
               return _dbcontext.ExecuteScalar<int>(query, parameters) > 0;
          }
          private bool GetValidateOrigin()
          {
               string origin = _request.GetHeaderValue("origin");
               if (string.IsNullOrEmpty(origin))
                    return false;
               StringBuilder query = new StringBuilder();
               List<ParameterSql> parameters = [new ParameterSql("@valor", origin)];
               query.AppendFormat(" SELECT count(*) FROM [dbo].[Parameters] where parameter like '%prod' and value = @valor ");
               return _dbcontext.ExecuteScalar<int>(query, parameters) > 0;
          }
          private bool GetValidateReferer()
          {
               string referer = _request.GetHeaderValue("referer");
               if (string.IsNullOrEmpty(referer))
                    return false;

               return true;
          }
          public string GetToken()
          {
               if (!_request.Headers.TryGetValue("Authorization", out StringValues value))
               {
                    return "";
               }
               var bearerToken = value.ToString();
               return bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
          }
          private void ReadToken(GraphQLQuery query, string contentHash, double diff)
          {
               string valuetoken = GetInfoToken();
               LogInfoRequest(query, Errors.E00000000, valuetoken, contentHash, diff);
          }
          public void LogInfoRequest(GraphQLQuery query, string error, string valueloggin, string contentHash, double diff)
          {
               StringBuilder querySql = new StringBuilder();
               string variablesGraphql = query.Variables.ConvertObjectToJson();
               string queryGraphql = query.Query;
               string? ipAddress = GetRemoteIPAddress();
               if (string.IsNullOrEmpty(variablesGraphql))
                    variablesGraphql = String.Empty;
               if (string.IsNullOrEmpty(queryGraphql))
                    queryGraphql = String.Empty;
               querySql.AppendFormat("Insert into dbo.RequestLogs (Product,ipAddress,Request,UserAgent,queryGraphql,variablesGraphql,Stack,valueToken,ContentHash,DiffTimeHash)");
               querySql.AppendFormat("values(@Product,@ipAddress,@Request,@UserAgent,@queryGraphql,@variablesGraphql,@Stack,@valueToken,@ContentHash,@DiffTimeHash)");
               List<ParameterSql> sqlParameters =
               [
                    new ParameterSql("@Product", "AuthApiv3"),
                    new ParameterSql("@ipAddress", ipAddress == null ?  String.Empty:ipAddress),
                    new ParameterSql("@Request", GetDetails(_request)),
                    new ParameterSql("@UserAgent", _request.GetHeaderValue("User-Agent")),
                    new ParameterSql("@queryGraphql", queryGraphql),
                    new ParameterSql("@variablesGraphql", variablesGraphql),
                    new ParameterSql("@Stack", error),
                    new ParameterSql("@valueToken", valueloggin),
                    new ParameterSql("@ContentHash", contentHash),
                    new ParameterSql("@DiffTimeHash", diff)
               ];
               _dbcontext.ExecuteCommand(querySql, sqlParameters);
          }

          public string GetDetails(HttpRequest request)
          {
               string baseUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString.Value}";
               StringBuilder sbHeaders = new StringBuilder();
               foreach (var header in request.Headers)
                    sbHeaders.Append($"{header.Key}: {header.Value}\n");

               string body = "no-body";
               if (request.Body.CanSeek)
               {
                    request.Body.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(request.Body))
                         body = sr.ReadToEnd();
               }

               return $"{request.Protocol} {request.Method} {baseUrl}\n\n{sbHeaders}\n{body}";
          }

          private string? GetRemoteIPAddress()
          {
               try
               {
                    string? ipAddress;
                    string? header = _request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? _request.Headers["X-Forwarded-For"].FirstOrDefault();
                    if (System.Net.IPAddress.TryParse(header, out System.Net.IPAddress? ip))
                    {
                         ipAddress = ip?.ToString();
                    }
                    ipAddress = _request.HttpContext.Connection?.RemoteIpAddress?.ToString();
                    if (ipAddress == "::1")
                         return $"{_request.Host.Host}:{_request.Host.Port}";
                    return ipAddress;
               }
               catch
               {
                    return "not_ip_address";
               }
          }

          public LoginInfo? GetInfoLoggin(string token, out string error)
          {
               error = String.Empty;
               if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(token.Trim()))
               {
                    error = Errors.E00000018;
                    return null;
               }
               LoginInfo loggin = _cache.AuthGetData<LoginInfo>(token, out bool isContaintKey);
               if (loggin != null)
               {
                    if (!TokenGenerator.ValidateToken(token, loggin.Uuid, loggin.Email))
                    {
                         error = Errors.E00000018;
                         return null;
                    }
                    loggin.AuthConstant = Authentication.LOGGED;
                    return loggin;
               }
               loggin = _cache.TwoFactorsGetData<LoginInfo>(token, out isContaintKey);
               if (loggin != null)
               {
                    if (!TokenGenerator.ValidateToken(token, loggin.Uuid, loggin.Email))
                    {
                         error = Errors.E00000018;
                         return null;
                    }
                    loggin.AuthConstant = Authentication.LOGGETWOFACTOR;
                    return loggin;
               }
               error = Errors.E00000019;
               return null;
          }
          private string GetInfoToken()
          {
               string token = GetToken();
               string valuetoken = "";
               if (!string.IsNullOrEmpty(token))
               {
                    LoginInfo? loggin = GetInfoLoggin(token, out string error);
                    if (loggin != null)
                         valuetoken = loggin.ConvertObjectToJson();
               }
               return valuetoken;
          }
     }
}
