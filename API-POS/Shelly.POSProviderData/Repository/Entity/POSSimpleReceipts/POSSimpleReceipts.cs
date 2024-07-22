
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class SimpleReceipts 
	/// </summary>
	[Serializable]
	public partial class SimpleReceipts:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="SimpleReceipts"/> class..
		/// </summary>
		public SimpleReceipts():base()
		{
			Table = "SimpleReceipts";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="SimpleReceipts"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public SimpleReceipts(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "SimpleReceipts";
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
		[ColumnName("ReceiptNumber")]
		public string ReceiptNumber
		{
			get => GetPropertyValue<string>("ReceiptNumber");
			set => SetPropertyValue<string>("ReceiptNumber", value);
		}
		[ColumnName("IssueDate")]
		public DateTime IssueDate
		{
			get => GetPropertyValue<DateTime>("IssueDate");
			set => SetPropertyValue<DateTime>("IssueDate", value);
		}
		[ColumnName("TotalAmount")]
		public double TotalAmount
		{
			get => GetPropertyValue<double>("TotalAmount");
			set => SetPropertyValue<double>("TotalAmount", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		[ColumnName("SatFolio")]
		public string SatFolio
		{
			get => GetPropertyValue<string>("SatFolio");
			set => SetPropertyValue<string>("SatFolio", value);
		}
		[ColumnName("SatUuid")]
		public string SatUuid
		{
			get => GetPropertyValue<string>("SatUuid");
			set => SetPropertyValue<string>("SatUuid", value);
		}
		[ColumnName("SatStatus")]
		public string SatStatus
		{
			get => GetPropertyValue<string>("SatStatus");
			set => SetPropertyValue<string>("SatStatus", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the SimpleReceipts.		/// </summary>
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
			 AddProperty<string>("ReceiptNumber", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description ReceiptNumber",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<DateTime>("IssueDate", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description IssueDate",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<double>("TotalAmount", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description TotalAmount",
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
			 FieldId = 5,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<string>("SatFolio", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description SatFolio",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SatUuid", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 36,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description SatUuid",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SatStatus", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 8,
			 Description = "No description SatStatus",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
