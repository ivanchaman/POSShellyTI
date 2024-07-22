namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsCountriesType : ObjectGraphType<Countries>
	{

		public xsCountriesType()
		{

			Name = "xsCountriesType";
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
			#endregion

		}
	}
}
