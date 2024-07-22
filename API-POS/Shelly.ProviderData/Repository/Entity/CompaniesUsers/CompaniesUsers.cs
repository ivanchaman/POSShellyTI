using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class CompaniesUsers 
    /// </summary>
    [Serializable]
	public partial class CompaniesUsers:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesUsers"/> class..
		/// </summary>
		public CompaniesUsers():base()
		{
			Table = "Users";
			Owner= "Company";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesUsers"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public CompaniesUsers(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Users";
			Owner= "Company";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public long Id
		{
			get => GetPropertyValue<long>("Id");
			set => SetPropertyValue<long>("Id", value);
		}
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("CurrencyCode")]
		public string CurrencyCode
		{
			get => GetPropertyValue<string>("CurrencyCode");
			set => SetPropertyValue<string>("CurrencyCode", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the CompaniesUsers.		/// </summary>
		/// <param name="poId">Id</param>
		public void Load(long id)
		{
			base.Load(id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(4);

			 AddKeyField("Id",null);
			 AddProperty<long>("Id", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Id",
			 IsIdentity = true,
			 DataType = typeof(long)
			});
			 AddProperty<long>("Company", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Company",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("UserNumber", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description UserNumber",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("CurrencyCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 10,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description CurrencyCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
