
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Taxes 
	/// </summary>
	public partial class Taxes:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Taxes"/> class..
		/// </summary>
		public Taxes():base()
		{
			Table = "Taxes";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Taxes"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Taxes(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Taxes";
			Owner= "POS";
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
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
		}
		[ColumnName("Rate")]
		public double Rate
		{
			get => GetPropertyValue<double>("Rate");
			set => SetPropertyValue<double>("Rate", value);
		}
		[ColumnName("SATTaxCode")]
		public string SATTaxCode
		{
			get => GetPropertyValue<string>("SATTaxCode");
			set => SetPropertyValue<string>("SATTaxCode", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the Taxes.		/// </summary>
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
			Properties = new Dictionary<string, Property>(6);

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
			 IsCompanyField = true,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<double>("Rate", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 5,
			 Precision = 5,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Rate",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<string>("SATTaxCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 30,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description SATTaxCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
