using System.Text;

namespace Shelly.Abstractions.Interfaces
{
     public interface IBaseSystem
     {
          public int UtcOffsetMinutes { get; set; }
          public List<TermAndConditionDocument> TermsServices { get; set; }
          public bool HasTermsStatus { get; set; }
          public bool HasTwofactor { get; set; }
          public int PrimaryTwoFactor { get; set; }
          public string Left { get; set; }
          public Local LocalSettings { get; set; }
          public Session Session { get; set; }
          public LoginInfo InfoSessionToken { get; set; }
          public IDataAccess Connection { get; set; }
          public ICacheContext Cache { get; set; }
          public void SetParameter(string parameterName, string value);
          public void SetParameter(string parameterName, string value, string description);
          public void SetParameter(string parameterName, string value, string description, long companyId);
          public T GetParameter<T>(string parameterName);
          public T GetParameter<T>(string parameterName, long companyId);
          public void GetParameter<T>(string parameterName, out T value);
          public void WriteLog(Exception exception);
          public void WriteLog(string exception);
          public void WriteLog(Exception exception, string query);
          public void WriteLog(Exception exception, StringBuilder query);
          public void WriteLog(Exception exception, List<StringBuilder> query);
     }
}
