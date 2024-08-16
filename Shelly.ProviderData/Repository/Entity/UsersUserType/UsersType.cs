
namespace Shelly.ProviderData.Repository.Entity 
{
	/// <summary>
	/// Class UserType 
	/// </summary>
	public partial class UsersType : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersType"/> class..
		/// </summary>
		public UsersType() : base()
		{
			Table = "UserType";
			Owner = "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersType"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersType(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "UserType";
			Owner = "Users";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("ID")]
		public int ID
		{
			get => GetPropertyValue<int>("ID");
			set => SetPropertyValue<int>("ID", value);
		}
		[ColumnName("Type")]
		public string Type
		{
			get => GetPropertyValue<string>("Type");
			set => SetPropertyValue<string>("Type", value);
		}
		[ColumnName("Active")]
		public bool Active
		{
			get => GetPropertyValue<bool>("Active");
			set => SetPropertyValue<bool>("Active", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the UserType.		/// </summary>
		/// <param name="poID">ID</param>
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
			Properties = new Dictionary<string, Property>(3);

			AddKeyField("ID", null);
			AddProperty<int>("ID", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 0,
				Description = "No description ID",
				IsIdentity = true,
				DataType = typeof(int)
			});
			AddProperty<string>("Type", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 70,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Type",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<bool>("Active", new PropertyValue<bool>
			{
				Value = true,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = false,
				FieldId = 2,
				Description = "No description Active",
				IsIdentity = false,
				DataType = typeof(bool)
			});
		}
		#endregion

	}
}
