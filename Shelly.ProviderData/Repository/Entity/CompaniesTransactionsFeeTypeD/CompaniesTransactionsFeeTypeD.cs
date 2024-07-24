namespace Shelly.Abstractions.Repository.Entity
{
     /// <summary>
     /// Class CompaniesTransactionsFeeTypeD 
     /// </summary>
     [Serializable]
	public partial class CompaniesTransactionsFeeTypeD: StaticEntity
     {
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeD"/> class..
		/// </summary>
		public CompaniesTransactionsFeeTypeD():base()
		{
			Table = "CompaniesTransactionsFeeTypeD";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeD"/> class..
		/// </summary>
		/// <param name="BaseSystem">base system</param>
		public CompaniesTransactionsFeeTypeD(IBaseSystem BaseSystem):base (BaseSystem)
		{
			Table = "CompaniesTransactionsFeeTypeD";
			Owner= "dbo";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("FeeId")]
		public long FeeId
		{
			get => GetPropertyValue<long>("FeeId");
			set => SetPropertyValue<long>("FeeId", value);
		}
		[ColumnName("Id")]
		public long Id
		{
			get => GetPropertyValue<long>("Id");
			set => SetPropertyValue<long>("Id", value);
		}
		[ColumnName("CurrencyId")]
		public int CurrencyId
		{
			get => GetPropertyValue<int>("CurrencyId");
			set => SetPropertyValue<int>("CurrencyId", value);
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
		[ColumnName("IsEnabled")]
		public bool IsEnabled
		{
			get => GetPropertyValue<bool>("IsEnabled");
			set => SetPropertyValue<bool>("IsEnabled", value);
		}
		[ColumnName("IsFiat")]
		public bool IsFiat
		{
			get => GetPropertyValue<bool>("IsFiat");
			set => SetPropertyValue<bool>("IsFiat", value);
		}
		[ColumnName("IsLocked")]
		public bool IsLocked
		{
			get => GetPropertyValue<bool>("IsLocked");
			set => SetPropertyValue<bool>("IsLocked", value);
		}
		[ColumnName("AmountType")]
		public int AmountType
		{
			get => GetPropertyValue<int>("AmountType");
			set => SetPropertyValue<int>("AmountType", value);
		}
		[ColumnName("AmountFormula")]
		public string AmountFormula
		{
			get => GetPropertyValue<string>("AmountFormula");
			set => SetPropertyValue<string>("AmountFormula", value);
		}
		[ColumnName("FiatWalletId")]
		public long FiatWalletId
		{
			get => GetPropertyValue<long>("FiatWalletId");
			set => SetPropertyValue<long>("FiatWalletId", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the CompaniesTransactionsFeeTypeD.		/// </summary>
		/// <param name="poCompany">Company</param>
		/// <param name="poFeeId">FeeId</param>
		/// <param name="poId">Id</param>
		public void Load(long company,long feeid,long id)
		{
			base.Load(company,feeid,id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(3);
			Properties = new Dictionary<string, Property>(12);

			 AddKeyField("Company",null);
			 AddKeyField("FeeId",null);
			 AddKeyField("Id",null);
			 AddProperty<long>("Company", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Company",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("FeeId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description FeeId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("Id", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Id",
			 IsIdentity = true,
			 DataType = typeof(long)
			});
			 AddProperty<int>("CurrencyId", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description CurrencyId",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 1000,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("IsEnabled", new PropertyValue<bool> {
			 Value = true,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description IsEnabled",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			 AddProperty<bool>("IsFiat", new PropertyValue<bool> {
			 Value = true,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description IsFiat",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			 AddProperty<bool>("IsLocked", new PropertyValue<bool> {
			 Value = false,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
			 Description = "No description IsLocked",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			 AddProperty<int>("AmountType", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 9,
			 Description = "No description AmountType",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("AmountFormula", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 10,
			 Description = "No description AmountFormula",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<long>("FiatWalletId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 11,
			 Description = "No description FiatWalletId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			}
			#endregion

		}
	}
