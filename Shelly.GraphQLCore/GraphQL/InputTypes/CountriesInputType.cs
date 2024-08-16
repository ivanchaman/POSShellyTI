
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  CountriesInputType : InputObjectGraphType<Countries>	{

	public CountriesInputType()
	{

		Name = "CountriesInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Nombre);
			Field(f => f.Name);
			Field(f => f.Nom);
			Field(f => f.Iso2);
			Field(f => f.Iso3);
			Field(f => f.Iso4217);
			Field(f => f.AbvMoneda);
			Field(f => f.PhoneCode);
			Field(f => f.Status);
			Field(f => f.Emoji);
			Field(f => f.Icon);
			Field(f => f.Capital);
			Field(f => f.States);
			Field(f => f.Region);
			Field(f => f.IsEnabled);
			Field(f => f.Needs2Ids);
		#endregion

	}
	}
}
