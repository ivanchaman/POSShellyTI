
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Services 
	/// </summary>
	[Serializable]
	public partial class Services : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Services"/> class..
		/// </summary>
		public Services() : base()
		{
			Table = "Services";
			Owner = "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Services"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Services(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Services";
			Owner = "MedicalClinic";
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
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
		}
		[ColumnName("Time")]
		public int Time
		{
			get => GetPropertyValue<int>("Time");
			set => SetPropertyValue<int>("Time", value);
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
		/// Load row of the Services.		/// </summary>
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
			Properties = new Dictionary<string, Property>(5);

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
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<long>("Company", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Company",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<long>("ProductId", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description ProductId",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<int>("Time", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Time",
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
		}
		#endregion

	}
}
