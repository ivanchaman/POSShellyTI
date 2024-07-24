using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class xsEmailTemplates 
    /// </summary>
    [Serializable]
	public partial class EmailTemplates:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="EmailTemplates"/> class..
		/// </summary>
		public EmailTemplates():base()
		{
			Table = "EmailTemplates";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="EmailTemplates"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public EmailTemplates(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "EmailTemplates";
			Owner= "dbo";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Company")]
		public int Company
		{
			get => GetPropertyValue<int>("Company");
			set => SetPropertyValue<int>("Company", value);
		}
		[ColumnName("Language")]
		public int Language
		{
			get => GetPropertyValue<int>("Language");
			set => SetPropertyValue<int>("Language", value);
		}
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		[ColumnName("HtmlPart")]
		public string HtmlPart
		{
			get => GetPropertyValue<string>("HtmlPart");
			set => SetPropertyValue<string>("HtmlPart", value);
		}
		[ColumnName("SubjectPart")]
		public string SubjectPart
		{
			get => GetPropertyValue<string>("SubjectPart");
			set => SetPropertyValue<string>("SubjectPart", value);
		}
		[ColumnName("TextPart")]
		public string TextPart
		{
			get => GetPropertyValue<string>("TextPart");
			set => SetPropertyValue<string>("TextPart", value);
		}
		[ColumnName("Parameters")]
		public string Parameters
		{
			get => GetPropertyValue<string>("Parameters");
			set => SetPropertyValue<string>("Parameters", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsEmailTemplates.		/// </summary>
		/// <param name="poCompany">Company</param>
		/// <param name="poLanguage">Language</param>
		/// <param name="psName">Name</param>
		public void Load(int company,int language,string name)
		{
			base.Load(company,language,name);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(3);
			Properties = new Dictionary<string, Property>(8);

			 AddKeyField("Company",null);
			 AddKeyField("Language",null);
			 AddKeyField("Name",null);
			 AddProperty<int>("Company", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Company",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<int>("Language", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Language",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = true,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 150,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("HtmlPart", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description HtmlPart",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SubjectPart", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description SubjectPart",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("TextPart", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description TextPart",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Parameters", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description Parameters",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
