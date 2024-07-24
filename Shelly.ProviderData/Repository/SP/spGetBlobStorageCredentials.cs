using Shelly.ProviderData.GenericRepository.SP;

namespace Shelly.ProviderData.Repository.SP
{
     public class spGetBlobStorageCredentials : BaseRepository
     {
          #region Init Constructor
          public spGetBlobStorageCredentials() : base()
          {
               StoreProcedureName = "spGetBlobStorageCredentials";
               Owner = "BOB";
          }

          public spGetBlobStorageCredentials(IDataAccess connection) : base((DataAccess)connection)
          {
               StoreProcedureName = "spGetBlobStorageCredentials";
               Owner = "BOB";
          }
          #endregion
          #region Parameters Procedure        
          public int ProductsType
          {
               get => GetPropertyValue<int>("ProductsType");
               set => SetPropertyValue<int>("ProductsType", value);
          }
          public int Environment
          {
               get => GetPropertyValue<int>("Environment");
               set => SetPropertyValue<int>("Environment", value);
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
