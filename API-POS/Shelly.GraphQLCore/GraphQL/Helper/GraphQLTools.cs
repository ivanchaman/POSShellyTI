namespace Shelly.GraphQLCore.GraphQL.Helper
{
     internal static class GraphQlTools
     {
          public static bool GetInfoQuery(out GraphQLQuery query, HttpRequest request)
          {
               query = new GraphQLQuery();
               try
               {
                    string infoHash = GetInfoHash(request);
                    if (string.IsNullOrEmpty(infoHash))
                         return false;
                    StringBuilder contentexec = new StringBuilder();
                    foreach (string header in infoHash.Split('|'))
                    {
                         if (string.IsNullOrEmpty(header))
                              continue;
                         string infoHeader = request.GetHeaderValue(header);
                         if (string.IsNullOrEmpty(infoHeader))
                              return false;
                         contentexec.Append(Cipher.DecryptPEMNetWork(infoHeader));
                    }
                    if (contentexec.Length == 0)
                         return false;
                    string dataquery = Encoding.UTF8.GetString(Convert.FromBase64String(contentexec.ToString()));
                    if (string.IsNullOrEmpty(dataquery))
                         return false;
                    query = dataquery.ConvertJsonToObject<GraphQLQuery>();
                    if (query == null)
                         return false;
                    return true;
               }
               catch
               {
                    return false;
               }
          }
          private static string GetInfoHash(HttpRequest request)
          {
               var execHash = request.Headers.Where(x => x.Key.StartsWith("exec-hash")).OrderBy(x=>x.Key);
               if (execHash == null || !execHash.Any ())
                    return "";
               string infoHash = "";
               foreach (var exec in execHash)
               {
                    infoHash += Cipher.DecryptPEMNetWork(exec.Value.ToString ());
               }
               return infoHash;
          }
          public static string GetHeaderValue(this HttpRequest request, string name)
          {
               if (!request.Headers.TryGetValue(name, out StringValues value))
                    return "";
               return value.ToString();
          }


     }
}
