
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Batches 
	/// </summary>
	public partial class Batches:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Batches"/> class..
		/// </summary>
		public Batches():base()
		{
			Table = "Batches";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Batches"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Batches(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Batches";
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
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
		}
		[ColumnName("SupplierId")]
		public long SupplierId
		{
			get => GetPropertyValue<long>("SupplierId");
			set => SetPropertyValue<long>("SupplierId", value);
		}
		[ColumnName("BatchNumber")]
		public string BatchNumber
		{
			get => GetPropertyValue<string>("BatchNumber");
			set => SetPropertyValue<string>("BatchNumber", value);
		}
		[ColumnName("ExpirationDate")]
		public string ExpirationDate
		{
			get => GetPropertyValue<string>("ExpirationDate");
			set => SetPropertyValue<string>("ExpirationDate", value);
		}
		[ColumnName("CostPrice")]
		public double CostPrice
		{
			get => GetPropertyValue<double>("CostPrice");
			set => SetPropertyValue<double>("CostPrice", value);
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
		/// Load row of the Batches.		/// </summary>
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
			Properties = new Dictionary<string, Property>(7);

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
			 AddProperty<long>("ProductId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description ProductId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("SupplierId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description SupplierId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("BatchNumber", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description BatchNumber",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ExpirationDate", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 3,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description ExpirationDate",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<double>("CostPrice", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description CostPrice",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
