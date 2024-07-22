
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Inventory 
	/// </summary>
	[Serializable]
	public partial class Inventory:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Inventory"/> class..
		/// </summary>
		public Inventory():base()
		{
			Table = "Inventory";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Inventory"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Inventory(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Inventory";
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
		[ColumnName("BatchId")]
		public long BatchId
		{
			get => GetPropertyValue<long>("BatchId");
			set => SetPropertyValue<long>("BatchId", value);
		}
		[ColumnName("Quantity")]
		public int Quantity
		{
			get => GetPropertyValue<int>("Quantity");
			set => SetPropertyValue<int>("Quantity", value);
		}
		[ColumnName("SaleProfitPercentage")]
		public double SaleProfitPercentage
		{
			get => GetPropertyValue<double>("SaleProfitPercentage");
			set => SetPropertyValue<double>("SaleProfitPercentage", value);
		}
		[ColumnName("SalePrice")]
		public double SalePrice
		{
			get => GetPropertyValue<double>("SalePrice");
			set => SetPropertyValue<double>("SalePrice", value);
		}
		[ColumnName("WholeSalePrice")]
		public double WholeSalePrice
		{
			get => GetPropertyValue<double>("WholeSalePrice");
			set => SetPropertyValue<double>("WholeSalePrice", value);
		}
		[ColumnName("Maximun")]
		public int Maximun
		{
			get => GetPropertyValue<int>("Maximun");
			set => SetPropertyValue<int>("Maximun", value);
		}
		[ColumnName("Minimun")]
		public int Minimun
		{
			get => GetPropertyValue<int>("Minimun");
			set => SetPropertyValue<int>("Minimun", value);
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
		/// Load row of the Inventory.		/// </summary>
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
			Properties = new Dictionary<string, Property>(10);

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
			 AddProperty<long>("BatchId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description BatchId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<int>("Quantity", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Quantity",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<double>("SaleProfitPercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description SaleProfitPercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("SalePrice", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description SalePrice",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("WholeSalePrice", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description WholeSalePrice",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<int>("Maximun", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description Maximun",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<int>("Minimun", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description Minimun",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
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
			 FieldId = 9,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
