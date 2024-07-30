
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class ProductsTax 
	/// </summary>
	public partial class ProductsTax:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="ProductsTax"/> class..
		/// </summary>
		public ProductsTax():base()
		{
			Table = "ProductsTax";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="ProductsTax"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public ProductsTax(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "ProductsTax";
			Owner= "POS";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public int Id
		{
			get => GetPropertyValue<int>("Id");
			set => SetPropertyValue<int>("Id", value);
		}
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
		}
		[ColumnName("TaxId")]
		public long TaxId
		{
			get => GetPropertyValue<long>("TaxId");
			set => SetPropertyValue<long>("TaxId", value);
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
		/// Load row of the ProductsTax.		/// </summary>
		/// <param name="poId">Id</param>
		public void Load(int id)
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
			 AddProperty<int>("Id", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Id",
			 IsIdentity = true,
			 DataType = typeof(int)
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
			 AddProperty<long>("TaxId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description TaxId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
