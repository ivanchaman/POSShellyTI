using Shelly.ProviderData.GenericRepository.SP;

namespace Shelly.ProviderData.Repository.SP
{
     public class spGetFeeIdTransactions : BaseRepository
     {
          #region Init Constructor
          public spGetFeeIdTransactions() : base()
          {
               StoreProcedureName = "spGetFeeIdTransactions";
               Owner = "dbo";
          }

          public spGetFeeIdTransactions(IDataAccess connection) : base((DataAccess)connection)
          {
               StoreProcedureName = "spGetFeeIdTransactions";
               Owner = "dbo";
          }
          #endregion
          #region Parameters Procedure        
          public long Company
          {
               get => GetPropertyValue<long>("Company");
               set => SetPropertyValue<long>("Company", value);
          }          
          #endregion
          protected override void CustomValidationForNewPreWriteRegister()
          {
          }

          protected override void CustomValidationForPostWrite()
          {
          }
     }
}
