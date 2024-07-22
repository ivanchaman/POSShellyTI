namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class xsTransactionsQueueType : ObjectGraphType<TransactionsQueue>
	{

		public xsTransactionsQueueType()
		{

			Name = "xsTransactionsQueueType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Status);
			Field(f => f.Company);
			Field(f => f.UserNumber);
			Field(f => f.StartDate);
			Field(f => f.EndDate);
			Field(f => f.Module);
			Field(f => f.Process);
			Field(f => f.KeyValue);
			Field(f => f.Inputs);
			Field(f => f.Outputs);
			Field(f => f.Description);
			Field(f => f.Processed);
			#endregion

		}
	}
}
