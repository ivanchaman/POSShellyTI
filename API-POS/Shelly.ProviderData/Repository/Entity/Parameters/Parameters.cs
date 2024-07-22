using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class xsParameters 
    /// </summary>
    [Serializable]
	public partial class xsParameters:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="xsParameters"/> class..
		/// </summary>
		public xsParameters():base()
		{
			Table = "Parameters";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="xsParameters"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public xsParameters(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Parameters";
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
		[ColumnName("Parameter")]
		public string Parameter
		{
			get => GetPropertyValue<string>("Parameter");
			set => SetPropertyValue<string>("Parameter", value);
		}
		[ColumnName("Value")]
		public string Value
		{
			get => GetPropertyValue<string>("Value");
			set => SetPropertyValue<string>("Value", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsParameters.		/// </summary>
		/// <param name="poCompany">Company</param>
		/// <param name="psParameter">Parameter</param>
		public void Load(int company,string parameter)
		{
			base.Load(company,parameter);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(2);
			Properties = new Dictionary<string, Property>(4);

			 AddKeyField("Company",null);
			 AddKeyField("Parameter",null);
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
			 AddProperty<string>("Parameter", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = true,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Parameter",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Value", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description Value",
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
			}
			#endregion

		}
	}
