namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsLogsType : ObjectGraphType<Logs>
	{

		public xsLogsType()
		{

			Name = "xsLogsType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Type);
			Field(f => f.DateLog);
			Field(f => f.Message);
			Field(f => f.Stack);
			Field(f => f.Query);
			Field(f => f.Reporter);
			#endregion

		}
	}

    public class Logs
    {
        public string Id { set; get; }
        public string Type { set; get; }
        public string DateLog { set; get; }
        public string Message { set; get; }
        public string Stack { set; get; }
        public string Query { set; get; }
        public string Reporter { set; get; }
    }
}
