namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class TermAndConditionDocumentsType : ObjectGraphType<TermAndConditionDocument>
     {
          public TermAndConditionDocumentsType()
          {
               Name = "TermAndConditionDocumentsType";
               Field(f => f.Id);
               Field(f => f.Name);
               Field(f => f.Description);
               Field(f => f.UrlDocument);               
               Field(f => f.Status);               
          }

     }
}
