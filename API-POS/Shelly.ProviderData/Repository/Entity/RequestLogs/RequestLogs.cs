using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsRequestLogs 
	/// </summary>
	[Serializable]
	public partial class RequestLogs : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="RequestLogs"/> class..
		/// </summary>
		public RequestLogs() : base()
		{
			Table = "RequestLogs";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="RequestLogs"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public RequestLogs(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "RequestLogs";
			Owner = "dbo";
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
		[ColumnName("DateLog")]
		public DateTime DateLog
		{
			get => GetPropertyValue<DateTime>("DateLog");
			set => SetPropertyValue<DateTime>("DateLog", value);
		}
		[ColumnName("Product")]
		public string Product
		{
			get => GetPropertyValue<string>("Product");
			set => SetPropertyValue<string>("Product", value);
		}
		[ColumnName("IpAddress")]
		public string IpAddress
		{
			get => GetPropertyValue<string>("IpAddress");
			set => SetPropertyValue<string>("IpAddress", value);
		}
		[ColumnName("Request")]
		public string Request
		{
			get => GetPropertyValue<string>("Request");
			set => SetPropertyValue<string>("Request", value);
		}
		[ColumnName("UserAgent")]
		public string UserAgent
		{
			get => GetPropertyValue<string>("UserAgent");
			set => SetPropertyValue<string>("UserAgent", value);
		}
		[ColumnName("QueryGraphql")]
		public string QueryGraphql
		{
			get => GetPropertyValue<string>("QueryGraphql");
			set => SetPropertyValue<string>("QueryGraphql", value);
		}
		[ColumnName("VariablesGraphql")]
		public string VariablesGraphql
		{
			get => GetPropertyValue<string>("VariablesGraphql");
			set => SetPropertyValue<string>("VariablesGraphql", value);
		}
		[ColumnName("Stack")]
		public string Stack
		{
			get => GetPropertyValue<string>("Stack");
			set => SetPropertyValue<string>("Stack", value);
		}
		[ColumnName("ValueToken")]
		public string ValueToken
		{
			get => GetPropertyValue<string>("ValueToken");
			set => SetPropertyValue<string>("ValueToken", value);
		}
		[ColumnName("ContentHash")]
		public string ContentHash
		{
			get => GetPropertyValue<string>("ContentHash");
			set => SetPropertyValue<string>("ContentHash", value);
		}
		[ColumnName("DiffTimeHash")]
		public double DiffTimeHash
		{
			get => GetPropertyValue<double>("DiffTimeHash");
			set => SetPropertyValue<double>("DiffTimeHash", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsRequestLogs.		/// </summary>
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
			if (!Object.Equals(KeyFields, null) && !Object.Equals(Properties, null))
				return;

			KeyFields = new Dictionary<string, object>(1);
			Properties = new Dictionary<string, Property>(12);

			AddKeyField("Id", null);
			AddProperty<long>("Id", new PropertyValue<long>
			{
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
			AddProperty<DateTime>("DateLog", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description DateLog",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
			AddProperty<string>("Product", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description Product",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("IpAddress", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description IpAddress",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Request", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description Request",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("UserAgent", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 5,
				Description = "No description UserAgent",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("QueryGraphql", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description QueryGraphql",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("VariablesGraphql", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 7,
				Description = "No description VariablesGraphql",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Stack", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 8,
				Description = "No description Stack",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("ValueToken", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 9,
				Description = "No description ValueToken",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("ContentHash", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 250,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 10,
				Description = "No description ContentHash",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<double>("DiffTimeHash", new PropertyValue<double>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 24,
				IsRequiredInDataBase = true,
				FieldId = 11,
				Description = "No description DiffTimeHash",
				IsIdentity = false,
				DataType = typeof(double)
			});
		}
		#endregion

	}
}
