namespace Shelly.ProviderData.Repository.Entity
{
     /// <summary>
     /// Class UsersSecurity 
     /// </summary>
     [Serializable]
	public partial class UsersSecurity : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersSecurity"/> class..
		/// </summary>
		public UsersSecurity() : base()
		{
			Table = "Security";
			Owner = "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersSecurity"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersSecurity(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Security";
			Owner = "Users";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("Id")]
		public int Id
		{
			get => GetPropertyValue<int>("Id");
			set => SetPropertyValue<int>("Id", value);
		}
		[ColumnName("KeyValue")]
		public string KeyValue
		{
			get => GetPropertyValue<string>("KeyValue");
			set => SetPropertyValue<string>("KeyValue", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
          [ColumnName("Code")]
          public string Code
          {
               get => GetPropertyValue<string>("Code");
               set => SetPropertyValue<string>("Code", value);
          }
          #endregion
          #region Funciones
          /// <summary>
          /// Load row of the UsersSecurity.		/// </summary>
          /// <param name="poUserNumber">UserNumber</param>
          /// <param name="poId">Id</param>
          public void Load(long usernumber, int id)
		{
			base.Load(usernumber, id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields, null) && !Object.Equals(Properties, null))
				return;

			KeyFields = new Dictionary<string, object>(2);
			Properties = new Dictionary<string, Property>(5);

			AddKeyField("UserNumber", null);
			AddKeyField("Id", null);
			AddProperty<long>("UserNumber", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 0,
				Description = "No description UserNumber",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<int>("Id", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Id",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<string>("KeyValue", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description KeyValue",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<int>("Status", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime>
			{
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
               AddProperty<string>("Code", new PropertyValue<string>
               {
                    Value = String.Empty,
                    IsPrimaryKey = false,
                    Length = 100,
                    Precision = 0,
                    IsRequiredInDataBase = false,
                    FieldId = 2,
                    Description = "No description Code",
                    IsIdentity = false,
                    DataType = typeof(string)
               });
          }
		#endregion

	}
}
