namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsCatalogsDetail 
	/// </summary>
	[Serializable]
	public partial class CatalogsDetail : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="CatalogsDetail"/> class..
		/// </summary>
		public CatalogsDetail() : base()
		{
			Table = "CatalogsDetail";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="CatalogsDetail"/> class..
		/// </summary>
		/// <param name="BaseSystem">base system</param>
		public CatalogsDetail(IBaseSystem BaseSystem) : base(BaseSystem)
		{
			Table = "CatalogsDetail";
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
		[ColumnName("Status")]
		public bool Status
		{
			get => GetPropertyValue<bool>("Status");
			set => SetPropertyValue<bool>("Status", value);
		}
		[ColumnName("CatalogId")]
		public long CatalogId
		{
			get => GetPropertyValue<long>("CatalogId");
			set => SetPropertyValue<long>("CatalogId", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsCatalogsDetail.		/// </summary>
		/// <param name="poId">Id</param>
		/// <param name="poCatalogId">CatalogId</param>
		public void Load(long id, long catalogid)
		{
			base.Load(id, catalogid);
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

			AddKeyField("Id", null);
			AddKeyField("CatalogId", null);
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
			AddProperty<string>("Name", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Name",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Description", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 300,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 2,
				Description = "No description Description",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<bool>("Status", new PropertyValue<bool>
			{
				Value = true,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(bool)
			});
			AddProperty<long>("CatalogId", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description CatalogId",
				IsIdentity = false,
				DataType = typeof(long)
			});
		}
		#endregion

	}
}
