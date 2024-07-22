using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class UsersAccess 
	/// </summary>
	[Serializable]
	public partial class UsersAccess : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAccess"/> class..
		/// </summary>
		public UsersAccess() : base()
		{
			Table = "Access";
			Owner = "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAccess"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersAccess(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Access";
			Owner = "Users";
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
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("Product")]
		public int Product
		{
			get => GetPropertyValue<int>("Product");
			set => SetPropertyValue<int>("Product", value);
		}
		[ColumnName("DateAccess")]
		public DateTime DateAccess
		{
			get => GetPropertyValue<DateTime>("DateAccess");
			set => SetPropertyValue<DateTime>("DateAccess", value);
		}
		[ColumnName("Status")]
		public bool Status
		{
			get => GetPropertyValue<bool>("Status");
			set => SetPropertyValue<bool>("Status", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the UsersAccess.		/// </summary>
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
				IsIdentity = true,
				DataType = typeof(long)
			});
			AddProperty<long>("UserNumber", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description UserNumber",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<int>("Product", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description Product",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<DateTime>("DateAccess", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description DateAccess",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
			AddProperty<bool>("Status", new PropertyValue<bool>
			{
				Value = true,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(bool)
			});
		}
		#endregion

	}
}
