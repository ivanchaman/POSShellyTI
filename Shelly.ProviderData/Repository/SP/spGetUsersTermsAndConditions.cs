using Shelly.ProviderData.GenericRepository.SP;

namespace Shelly.ProviderData.Repository.SP
{
     public class spGetUsersTermsAndConditions : BaseRepository
     {
          #region Init Constructor
          public spGetUsersTermsAndConditions() : base()
          {
               StoreProcedureName = "spGetUsersTermsAndConditions";
               Owner = "dbo";
          }

          public spGetUsersTermsAndConditions(IDataAccess connection) : base((DataAccess)connection)
          {
               StoreProcedureName = "spGetUsersTermsAndConditions";
               Owner = "dbo";
          }
          #endregion
          #region Parameters Procedure        
          public long Company
          {
               get => GetPropertyValue<long>("Company");
               set => SetPropertyValue<long>("Company", value);
          }
          public long UserNumber
          {
               get => GetPropertyValue<long>("UserNumber");
               set => SetPropertyValue<long>("UserNumber", value);
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
