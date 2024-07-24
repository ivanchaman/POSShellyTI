namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class xsRequestLogsType : ObjectGraphType<RequestLogs>
	{

		public xsRequestLogsType()
		{

			Name = "xsRequestLogsType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.DateLog);
			Field(f => f.Product);
			Field(f => f.IpAddress);
			Field(f => f.Request);
			Field(f => f.UserAgent);
			Field(f => f.QueryGraphql);
			Field(f => f.VariablesGraphql);
			Field(f => f.Stack);
			Field(f => f.ValueToken);
			Field(f => f.ContentHash);
			Field(f => f.DiffTimeHash);
			#endregion

		}
	}
}
