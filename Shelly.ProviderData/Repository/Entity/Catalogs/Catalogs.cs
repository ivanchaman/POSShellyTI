namespace Shelly.ProviderData.Repository.Entity
{
     /// <summary>
     /// Class xsCatalogs 
     /// </summary>
     [Serializable]
	public partial class Catalogs : StaticEntity
     {
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Catalogs"/> class..
		/// </summary>
		public Catalogs() : base()
		{
			Table = "Catalogs";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Catalogs"/> class..
		/// </summary>
		/// <param name="BaseSystem">base system</param>
		public Catalogs(IBaseSystem BaseSystem) : base(BaseSystem)
		{
			Table = "Catalogs";
			Owner = "dbo";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public int Id
		{
			get => GetPropertyValue<int>("Id");
			set => SetPropertyValue<int>("Id", value);
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
		[ColumnName("Version")]
		public double Version
		{
			get => GetPropertyValue<double>("Version");
			set => SetPropertyValue<double>("Version", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsCatalogs.		/// </summary>
		/// <param name="poId">Id</param>
		public void Load(int id)
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
			Properties = new Dictionary<string, Property>(4);

			AddKeyField("Id", null);
			AddProperty<int>("Id", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 0,
				Description = "No description Id",
				IsIdentity = true,
				DataType = typeof(int)
			});
			AddProperty<string>("Name", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
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
			AddProperty<double>("Version", new PropertyValue<double>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 53,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Version",
				IsIdentity = false,
				DataType = typeof(double)
			});
		}
		#endregion

	}
}
