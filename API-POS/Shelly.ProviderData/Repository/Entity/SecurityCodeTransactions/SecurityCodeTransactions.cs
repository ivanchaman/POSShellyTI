using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsSecurityCodeTransactions 
	/// </summary>
	[Serializable]
	public partial class SecurityCodeTransactions : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="SecurityCodeTransactions"/> class..
		/// </summary>
		public SecurityCodeTransactions() : base()
		{
			Table = "SecurityCodeTransactions";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="SecurityCodeTransactions"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public SecurityCodeTransactions(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "SecurityCodeTransactions";
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
		[ColumnName("Uuid")]
		public string Uuid
		{
			get => GetPropertyValue<string>("Uuid");
			set => SetPropertyValue<string>("Uuid", value);
		}
		[ColumnName("UserNumber")]
		public long UserNumber
		{
			get => GetPropertyValue<long>("UserNumber");
			set => SetPropertyValue<long>("UserNumber", value);
		}
		[ColumnName("Code")]
		public string Code
		{
			get => GetPropertyValue<string>("Code");
			set => SetPropertyValue<string>("Code", value);
		}
		[ColumnName("Timeout")]
		public int Timeout
		{
			get => GetPropertyValue<int>("Timeout");
			set => SetPropertyValue<int>("Timeout", value);
		}
		[ColumnName("Processed")]
		public bool Processed
		{
			get => GetPropertyValue<bool>("Processed");
			set => SetPropertyValue<bool>("Processed", value);
		}
		[ColumnName("CreateAt")]
		public DateTime CreateAt
		{
			get => GetPropertyValue<DateTime>("CreateAt");
			set => SetPropertyValue<DateTime>("CreateAt", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsSecurityCodeTransactions.		/// </summary>
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
			Properties = new Dictionary<string, Property>(7);

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
			AddProperty<string>("Uuid", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Uuid",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<long>("UserNumber", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description UserNumber",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<string>("Code", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 10,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Code",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<int>("Timeout", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description Timeout",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<bool>("Processed", new PropertyValue<bool>
			{
				Value = false,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description Processed",
				IsIdentity = false,
				DataType = typeof(bool)
			});
			AddProperty<DateTime>("CreateAt", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description CreateAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
		}
		#endregion

	}
}
