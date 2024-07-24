using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class xsLogs 
    /// </summary>
    [Serializable]
	public partial class Logs:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Logs"/> class..
		/// </summary>
		public Logs():base()
		{
			Table = "Logs";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Logs"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Logs(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Logs";
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
		[ColumnName("Type")]
		public string Type
		{
			get => GetPropertyValue<string>("Type");
			set => SetPropertyValue<string>("Type", value);
		}
		[ColumnName("DateLog")]
		public DateTime DateLog
		{
			get => GetPropertyValue<DateTime>("DateLog");
			set => SetPropertyValue<DateTime>("DateLog", value);
		}
		[ColumnName("Message")]
		public string Message
		{
			get => GetPropertyValue<string>("Message");
			set => SetPropertyValue<string>("Message", value);
		}
		[ColumnName("Stack")]
		public string Stack
		{
			get => GetPropertyValue<string>("Stack");
			set => SetPropertyValue<string>("Stack", value);
		}
		[ColumnName("Query")]
		public string Query
		{
			get => GetPropertyValue<string>("Query");
			set => SetPropertyValue<string>("Query", value);
		}
		[ColumnName("Reporter")]
		public bool Reporter
		{
			get => GetPropertyValue<bool>("Reporter");
			set => SetPropertyValue<bool>("Reporter", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsLogs.		/// </summary>
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
			 AddProperty<string>("Type", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Type",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<DateTime>("DateLog", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description DateLog",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<string>("Message", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description Message",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Stack", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Stack",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Query", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Query",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("Reporter", new PropertyValue<bool> {
			 Value = false,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description Reporter",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			}
			#endregion

		}
	}
