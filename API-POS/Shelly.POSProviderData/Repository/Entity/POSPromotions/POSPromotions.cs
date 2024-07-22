
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Promotions 
	/// </summary>
	[Serializable]
	public partial class Promotions : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Promotions"/> class..
		/// </summary>
		public Promotions() : base()
		{
			Table = "Promotions";
			Owner = "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Promotions"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Promotions(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Promotions";
			Owner = "POS";
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
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
		}
		[ColumnName("StartDate")]
		public string StartDate
		{
			get => GetPropertyValue<string>("StartDate");
			set => SetPropertyValue<string>("StartDate", value);
		}
		[ColumnName("EndDate")]
		public string EndDate
		{
			get => GetPropertyValue<string>("EndDate");
			set => SetPropertyValue<string>("EndDate", value);
		}
		[ColumnName("DiscountPercentage")]
		public double DiscountPercentage
		{
			get => GetPropertyValue<double>("DiscountPercentage");
			set => SetPropertyValue<double>("DiscountPercentage", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		[ColumnName("Type")]
		public int Type
		{
			get => GetPropertyValue<int>("Type");
			set => SetPropertyValue<int>("Type", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the Promotions.		/// </summary>
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
			Properties = new Dictionary<string, Property>(9);

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
				IsCompanyField = true,
				DataType = typeof(long)
			});
			AddProperty<string>("Name", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 510,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description Name",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("StartDate", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 3,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description StartDate",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("EndDate", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 3,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description EndDate",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<double>("DiscountPercentage", new PropertyValue<double>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 5,
				Precision = 5,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description DiscountPercentage",
				IsIdentity = false,
				DataType = typeof(double)
			});
			AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description CreatedAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
			AddProperty<int>("Type", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 3,
				IsRequiredInDataBase = true,
				FieldId = 7,
				Description = "No description Type",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<int>("Status", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 3,
				IsRequiredInDataBase = true,
				FieldId = 8,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(int)
			});
		}
		#endregion

	}
}
