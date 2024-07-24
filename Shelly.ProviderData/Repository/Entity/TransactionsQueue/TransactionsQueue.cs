using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class xsTransactionsQueue 
    /// </summary>
    [Serializable]
	public partial class TransactionsQueue:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="TransactionsQueue"/> class..
		/// </summary>
		public TransactionsQueue():base()
		{
			Table = "xsTransactionsQueue";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="TransactionsQueue"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public TransactionsQueue(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "xsTransactionsQueue";
			Owner= "dbo";
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
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("StartDate")]
		public DateTime StartDate
		{
			get => GetPropertyValue<DateTime>("StartDate");
			set => SetPropertyValue<DateTime>("StartDate", value);
		}
		[ColumnName("EndDate")]
		public DateTime EndDate
		{
			get => GetPropertyValue<DateTime>("EndDate");
			set => SetPropertyValue<DateTime>("EndDate", value);
		}
		[ColumnName("Module")]
		public int Module
		{
			get => GetPropertyValue<int>("Module");
			set => SetPropertyValue<int>("Module", value);
		}
		[ColumnName("Process")]
		public int Process
		{
			get => GetPropertyValue<int>("Process");
			set => SetPropertyValue<int>("Process", value);
		}
		[ColumnName("KeyValue")]
		public string KeyValue
		{
			get => GetPropertyValue<string>("KeyValue");
			set => SetPropertyValue<string>("KeyValue", value);
		}
		[ColumnName("Inputs")]
		public string Inputs
		{
			get => GetPropertyValue<string>("Inputs");
			set => SetPropertyValue<string>("Inputs", value);
		}
		[ColumnName("Outputs")]
		public string Outputs
		{
			get => GetPropertyValue<string>("Outputs");
			set => SetPropertyValue<string>("Outputs", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		[ColumnName("Processed")]
		public bool Processed
		{
			get => GetPropertyValue<bool>("Processed");
			set => SetPropertyValue<bool>("Processed", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsTransactionsQueue.		/// </summary>
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
			Properties = new Dictionary<string, Property>(13);

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
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<long>("Company", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Company",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("UserNumber", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description UserNumber",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<DateTime>("StartDate", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description StartDate",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<DateTime>("EndDate", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description EndDate",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<int>("Module", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description Module",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<int>("Process", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description Process",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("KeyValue", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
			 Description = "No description KeyValue",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Inputs", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 9,
			 Description = "No description Inputs",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Outputs", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 10,
			 Description = "No description Outputs",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 500,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 11,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("Processed", new PropertyValue<bool> {
			 Value = false,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 12,
			 Description = "No description Processed",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			}
			#endregion

		}
	}
