namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsSendEmailType : ObjectGraphType<SendEmail>
	{

		public xsSendEmailType()
		{

			Name = "xsSendEmailType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.EmailFrom);
			Field(f => f.EmailTo);
			Field(f => f.EmailCC);
			Field(f => f.EmailCCO);
			Field(f => f.MessageId);
			Field(f => f.RequestId);
			Field(f => f.HttpStatusCode);
			Field(f => f.Response);
			Field(f => f.Exception);
			Field(f => f.SendDate);
			Field(f => f.TemplateName);
			Field(f => f.Message);
			#endregion

		}
	}
}
