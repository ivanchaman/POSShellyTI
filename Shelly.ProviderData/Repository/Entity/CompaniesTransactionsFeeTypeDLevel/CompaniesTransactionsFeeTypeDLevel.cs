namespace Shelly.Abstractions.Repository.Entity
{
     /// <summary>
     /// Class CompaniesTransactionsFeeTypeDLevel 
     /// </summary>
     [Serializable]
	public partial class CompaniesTransactionsFeeTypeDLevel: StaticEntity
     {
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeDLevel"/> class..
		/// </summary>
		public CompaniesTransactionsFeeTypeDLevel():base()
		{
			Table = "CompaniesTransactionsFeeTypeDLevel";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeDLevel"/> class..
		/// </summary>
		/// <param name="BaseSystem">base system</param>
		public CompaniesTransactionsFeeTypeDLevel(IBaseSystem BaseSystem):base (BaseSystem)
		{
			Table = "CompaniesTransactionsFeeTypeDLevel";
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
		[ColumnName("Level")]
		public int Level
		{
			get => GetPropertyValue<int>("Level");
			set => SetPropertyValue<int>("Level", value);
		}
		[ColumnName("Id")]
		public long Id
		{
			get => GetPropertyValue<long>("Id");
			set => SetPropertyValue<long>("Id", value);
		}
		[ColumnName("AmountFormula")]
		public string AmountFormula
		{
			get => GetPropertyValue<string>("AmountFormula");
			set => SetPropertyValue<string>("AmountFormula", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the CompaniesTransactionsFeeTypeDLevel.		/// </summary>
		/// <param name="poCompany">Company</param>
		/// <param name="poFeeId">FeeId</param>
		/// <param name="poLevel">Level</param>
		/// <param name="poId">Id</param>
		public void Load(long company,long feeid,int level,long id)
		{
			base.Load(company,feeid,level,id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(4);
			Properties = new Dictionary<string, Property>(5);

			 AddKeyField("Company",null);
			 AddKeyField("FeeId",null);
			 AddKeyField("Level",null);
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
			 AddProperty<int>("Level", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Level",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<long>("Id", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Id",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("AmountFormula", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description AmountFormula",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
