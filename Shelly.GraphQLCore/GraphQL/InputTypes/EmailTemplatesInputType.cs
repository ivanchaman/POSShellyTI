
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  EmailTemplatesInputType : InputObjectGraphType<EmailTemplates>	{

	public EmailTemplatesInputType()
	{

		Name = "EmailTemplatesInputType";
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
