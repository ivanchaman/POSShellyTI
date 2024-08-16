namespace Shelly.POSCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations : Shelly.GraphQLCore.GraphQL.Mutation.Dashboard.Mutations
     {
          public Mutations(DashBoardSystem system) : base(system)
          {
               FieldsCommon();
               FieldsPOS();
               FieldsClinical();
          }
     }
}
