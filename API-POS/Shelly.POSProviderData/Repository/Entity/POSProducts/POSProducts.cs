
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Products 
	/// </summary>
	[Serializable]
	public partial class Products:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Products"/> class..
		/// </summary>
		public Products():base()
		{
			Table = "Products";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Products"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Products(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Products";
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
		[ColumnName("BarCode")]
		public string BarCode
		{
			get => GetPropertyValue<string>("BarCode");
			set => SetPropertyValue<string>("BarCode", value);
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
		[ColumnName("CategoryId")]
		public long CategoryId
		{
			get => GetPropertyValue<long>("CategoryId");
			set => SetPropertyValue<long>("CategoryId", value);
		}
		[ColumnName("UnitOfMeasureId")]
		public long UnitOfMeasureId
		{
			get => GetPropertyValue<long>("UnitOfMeasureId");
			set => SetPropertyValue<long>("UnitOfMeasureId", value);
		}
		[ColumnName("SATProductCode")]
		public string SATProductCode
		{
			get => GetPropertyValue<string>("SATProductCode");
			set => SetPropertyValue<string>("SATProductCode", value);
		}
		[ColumnName("SATUnitCode")]
		public string SATUnitCode
		{
			get => GetPropertyValue<string>("SATUnitCode");
			set => SetPropertyValue<string>("SATUnitCode", value);
		}
		[ColumnName("ImageId")]
		public long ImageId
		{
			get => GetPropertyValue<long>("ImageId");
			set => SetPropertyValue<long>("ImageId", value);
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
		/// Load row of the Products.		/// </summary>
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
			Properties = new Dictionary<string, Property>(12);

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
			 AddProperty<string>("BarCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description BarCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<long>("CategoryId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description CategoryId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("UnitOfMeasureId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description UnitOfMeasureId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("SATProductCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description SATProductCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SATUnitCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 30,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
			 Description = "No description SATUnitCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<long>("ImageId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 9,
			 Description = "No description ImageId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 10,
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
			 FieldId = 11,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
