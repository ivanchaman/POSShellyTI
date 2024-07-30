
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Sales 
	/// </summary>
	public partial class Sales:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Sales"/> class..
		/// </summary>
		public Sales():base()
		{
			Table = "Sales";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Sales"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Sales(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Sales";
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
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("CustomerNumber")]
		public long CustomerNumber
		{
			get => GetPropertyValue<long>("CustomerNumber");
			set => SetPropertyValue<long>("CustomerNumber", value);
		}
		[ColumnName("Folio")]
		public string Folio
		{
			get => GetPropertyValue<string>("Folio");
			set => SetPropertyValue<string>("Folio", value);
		}
		[ColumnName("TotalAmount")]
		public double TotalAmount
		{
			get => GetPropertyValue<double>("TotalAmount");
			set => SetPropertyValue<double>("TotalAmount", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
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
		/// Load row of the Sales.		/// </summary>
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
			Properties = new Dictionary<string, Property>(8);

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
			 AddProperty<long>("CustomerNumber", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description CustomerNumber",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Folio", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 16,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description Folio",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<double>("TotalAmount", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description TotalAmount",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
