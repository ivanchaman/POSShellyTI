namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsSendEmail 
	/// </summary>
	[Serializable]
	public partial class SendEmail : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="SendEmail"/> class..
		/// </summary>
		public SendEmail() : base()
		{
			Table = "SendEmail";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="SendEmail"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public SendEmail(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "SendEmail";
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
		[ColumnName("ProviderID")]
		public int ProviderID
		{
			get => GetPropertyValue<int>("ProviderID");
			set => SetPropertyValue<int>("ProviderID", value);
		}
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("EmailFrom")]
		public string EmailFrom
		{
			get => GetPropertyValue<string>("EmailFrom");
			set => SetPropertyValue<string>("EmailFrom", value);
		}
		[ColumnName("EmailTo")]
		public string EmailTo
		{
			get => GetPropertyValue<string>("EmailTo");
			set => SetPropertyValue<string>("EmailTo", value);
		}
		[ColumnName("EmailCC")]
		public string EmailCC
		{
			get => GetPropertyValue<string>("EmailCC");
			set => SetPropertyValue<string>("EmailCC", value);
		}
		[ColumnName("EmailCCO")]
		public string EmailCCO
		{
			get => GetPropertyValue<string>("EmailCCO");
			set => SetPropertyValue<string>("EmailCCO", value);
		}
		[ColumnName("MessageId")]
		public string MessageId
		{
			get => GetPropertyValue<string>("MessageId");
			set => SetPropertyValue<string>("MessageId", value);
		}
		[ColumnName("RequestId")]
		public string RequestId
		{
			get => GetPropertyValue<string>("RequestId");
			set => SetPropertyValue<string>("RequestId", value);
		}
		[ColumnName("HttpStatusCode")]
		public int HttpStatusCode
		{
			get => GetPropertyValue<int>("HttpStatusCode");
			set => SetPropertyValue<int>("HttpStatusCode", value);
		}
		[ColumnName("Response")]
		public string Response
		{
			get => GetPropertyValue<string>("Response");
			set => SetPropertyValue<string>("Response", value);
		}
		[ColumnName("Exception")]
		public string Exception
		{
			get => GetPropertyValue<string>("Exception");
			set => SetPropertyValue<string>("Exception", value);
		}
		[ColumnName("SendDate")]
		public DateTime SendDate
		{
			get => GetPropertyValue<DateTime>("SendDate");
			set => SetPropertyValue<DateTime>("SendDate", value);
		}
		[ColumnName("TemplateName")]
		public string TemplateName
		{
			get => GetPropertyValue<string>("TemplateName");
			set => SetPropertyValue<string>("TemplateName", value);
		}
		[ColumnName("Message")]
		public string Message
		{
			get => GetPropertyValue<string>("Message");
			set => SetPropertyValue<string>("Message", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsSendEmail.		/// </summary>
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
			Properties = new Dictionary<string, Property>(15);

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
			AddProperty<int>("ProviderID", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description ProviderID",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<long>("Company", new PropertyValue<long>
			{
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
			AddProperty<string>("EmailFrom", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description EmailFrom",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("EmailTo", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description EmailTo",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("EmailCC", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description EmailCC",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("EmailCCO", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description EmailCCO",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("MessageId", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 1000,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 7,
				Description = "No description MessageId",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("RequestId", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 8,
				Description = "No description RequestId",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<int>("HttpStatusCode", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = false,
				FieldId = 9,
				Description = "No description HttpStatusCode",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<string>("Response", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 10,
				Description = "No description Response",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Exception", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 11,
				Description = "No description Exception",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<DateTime>("SendDate", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 12,
				Description = "No description SendDate",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
			AddProperty<string>("TemplateName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 1000,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 13,
				Description = "No description TemplateName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Message", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 14,
				Description = "No description Message",
				IsIdentity = false,
				DataType = typeof(string)
			});
		}
		#endregion

	}
}
