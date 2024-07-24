
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class SalesDetails 
	/// </summary>
	[Serializable]
	public partial class SalesDetails:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="SalesDetails"/> class..
		/// </summary>
		public SalesDetails():base()
		{
			Table = "SalesDetails";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="SalesDetails"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public SalesDetails(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "SalesDetails";
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
		[ColumnName("SaleId")]
		public long SaleId
		{
			get => GetPropertyValue<long>("SaleId");
			set => SetPropertyValue<long>("SaleId", value);
		}
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
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
		[ColumnName("UnitPrice")]
		public double UnitPrice
		{
			get => GetPropertyValue<double>("UnitPrice");
			set => SetPropertyValue<double>("UnitPrice", value);
		}
		[ColumnName("TotalPrice")]
		public double TotalPrice
		{
			get => GetPropertyValue<double>("TotalPrice");
			set => SetPropertyValue<double>("TotalPrice", value);
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
		/// Load row of the SalesDetails.		/// </summary>
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
			Properties = new Dictionary<string, Property>(9);

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
			 AddProperty<long>("SaleId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description SaleId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("ProductId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description ProductId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("BatchId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
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
			 FieldId = 4,
			 Description = "No description Quantity",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<double>("UnitPrice", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description UnitPrice",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("TotalPrice", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description TotalPrice",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
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
			 FieldId = 8,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
