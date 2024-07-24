namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class DictionaryValueType : ObjectGraphType<DictionaryValue>
     {
          public DictionaryValueType()
          {
               Name = "DictionaryValueType";             

               Field(f => f.Key);
               Field(f => f.Value);
               Field(f => f.Section);
          }
     }
}
