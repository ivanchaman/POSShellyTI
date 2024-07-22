
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Payments 
	/// </summary>
	[Serializable]
	public partial class Payments:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Payments"/> class..
		/// </summary>
		public Payments():base()
		{
			Table = "Payments";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Payments"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Payments(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Payments";
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
		[ColumnName("Amount")]
		public double Amount
		{
			get => GetPropertyValue<double>("Amount");
			set => SetPropertyValue<double>("Amount", value);
		}
		[ColumnName("PaymentMethodId")]
		public int PaymentMethodId
		{
			get => GetPropertyValue<int>("PaymentMethodId");
			set => SetPropertyValue<int>("PaymentMethodId", value);
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
		/// Load row of the Payments.		/// </summary>
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
			Properties = new Dictionary<string, Property>(5);

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
			 AddProperty<double>("Amount", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Amount",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<int>("PaymentMethodId", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description PaymentMethodId",
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
			 FieldId = 4,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
