
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class RewardsPoints 
	/// </summary>
	[Serializable]
	public partial class RewardsPoints:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="RewardsPoints"/> class..
		/// </summary>
		public RewardsPoints():base()
		{
			Table = "RewardsPoints";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="RewardsPoints"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public RewardsPoints(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "RewardsPoints";
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
		[ColumnName("WalletId")]
		public long WalletId
		{
			get => GetPropertyValue<long>("WalletId");
			set => SetPropertyValue<long>("WalletId", value);
		}
		[ColumnName("TransactionType")]
		public int TransactionType
		{
			get => GetPropertyValue<int>("TransactionType");
			set => SetPropertyValue<int>("TransactionType", value);
		}
		[ColumnName("Amount")]
		public double Amount
		{
			get => GetPropertyValue<double>("Amount");
			set => SetPropertyValue<double>("Amount", value);
		}
		[ColumnName("SourceTrxId")]
		public long SourceTrxId
		{
			get => GetPropertyValue<long>("SourceTrxId");
			set => SetPropertyValue<long>("SourceTrxId", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		[ColumnName("Pool")]
		public int Pool
		{
			get => GetPropertyValue<int>("Pool");
			set => SetPropertyValue<int>("Pool", value);
		}
		[ColumnName("MetaData")]
		public string MetaData
		{
			get => GetPropertyValue<string>("MetaData");
			set => SetPropertyValue<string>("MetaData", value);
		}
		[ColumnName("FeeId")]
		public int FeeId
		{
			get => GetPropertyValue<int>("FeeId");
			set => SetPropertyValue<int>("FeeId", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		[ColumnName("HashId")]
		public string HashId
		{
			get => GetPropertyValue<string>("HashId");
			set => SetPropertyValue<string>("HashId", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the RewardsPoints.		/// </summary>
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
			Properties = new Dictionary<string, Property>(11);

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
			 AddProperty<long>("WalletId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description WalletId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<int>("TransactionType", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description TransactionType",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<double>("Amount", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Amount",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<long>("SourceTrxId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description SourceTrxId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 1000,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Pool", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description Pool",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("MetaData", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description MetaData",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("FeeId", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
			 Description = "No description FeeId",
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
			 AddProperty<string>("HashId", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 10,
			 Description = "No description HashId",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
