namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsEmailTemplatesType : ObjectGraphType<EmailTemplates>
	{

		public xsEmailTemplatesType()
		{

			Name = "xsEmailTemplatesType";
			#region Fields

			Field(f => f.Company);
			Field(f => f.Language);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.HtmlPart);
			Field(f => f.SubjectPart);
			Field(f => f.TextPart);
			Field(f => f.Parameters);
			#endregion

		}
	}
}
