using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class xsCountries 
	/// </summary>
	[Serializable]
	public partial class Countries : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Countries"/> class..
		/// </summary>
		public Countries() : base()
		{
			Table = "Countries";
			Owner = "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Countries"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Countries(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Countries";
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
		[ColumnName("Nombre")]
		public string Nombre
		{
			get => GetPropertyValue<string>("Nombre");
			set => SetPropertyValue<string>("Nombre", value);
		}
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
		}
		[ColumnName("Nom")]
		public string Nom
		{
			get => GetPropertyValue<string>("Nom");
			set => SetPropertyValue<string>("Nom", value);
		}
		[ColumnName("Iso2")]
		public string Iso2
		{
			get => GetPropertyValue<string>("Iso2");
			set => SetPropertyValue<string>("Iso2", value);
		}
		[ColumnName("Iso3")]
		public string Iso3
		{
			get => GetPropertyValue<string>("Iso3");
			set => SetPropertyValue<string>("Iso3", value);
		}
		[ColumnName("Iso4217")]
		public string Iso4217
		{
			get => GetPropertyValue<string>("Iso4217");
			set => SetPropertyValue<string>("Iso4217", value);
		}
		[ColumnName("AbvMoneda")]
		public string AbvMoneda
		{
			get => GetPropertyValue<string>("AbvMoneda");
			set => SetPropertyValue<string>("AbvMoneda", value);
		}
		[ColumnName("PhoneCode")]
		public string PhoneCode
		{
			get => GetPropertyValue<string>("PhoneCode");
			set => SetPropertyValue<string>("PhoneCode", value);
		}
		[ColumnName("Status")]
		public bool Status
		{
			get => GetPropertyValue<bool>("Status");
			set => SetPropertyValue<bool>("Status", value);
		}
		[ColumnName("Emoji")]
		public string Emoji
		{
			get => GetPropertyValue<string>("Emoji");
			set => SetPropertyValue<string>("Emoji", value);
		}
		[ColumnName("Icon")]
		public string Icon
		{
			get => GetPropertyValue<string>("Icon");
			set => SetPropertyValue<string>("Icon", value);
		}
		[ColumnName("Capital")]
		public string Capital
		{
			get => GetPropertyValue<string>("Capital");
			set => SetPropertyValue<string>("Capital", value);
		}
		[ColumnName("States")]
		public string States
		{
			get => GetPropertyValue<string>("States");
			set => SetPropertyValue<string>("States", value);
		}
		[ColumnName("Region")]
		public string Region
		{
			get => GetPropertyValue<string>("Region");
			set => SetPropertyValue<string>("Region", value);
		}
		[ColumnName("IsEnabled")]
		public bool IsEnabled
		{
			get => GetPropertyValue<bool>("IsEnabled");
			set => SetPropertyValue<bool>("IsEnabled", value);
		}
          [ColumnName("Needs2Ids")]
          public bool Needs2Ids
          {
               get => GetPropertyValue<bool>("Needs2Ids");
               set => SetPropertyValue<bool>("Needs2Ids", value);
          }
          #endregion
          #region Funciones
          /// <summary>
          /// Load row of the xsCountries.		/// </summary>
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
			Properties = new Dictionary<string, Property>(16);

			AddKeyField("Id", null);
			AddProperty<int>("Id", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = true,
				Length = 2,
				Precision = 5,
				IsRequiredInDataBase = true,
				FieldId = 0,
				Description = "No description Id",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<string>("Nombre", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description Nombre",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Name", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description Name",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Nom", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description Nom",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Iso2", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 2,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 4,
				Description = "No description Iso2",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Iso3", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 3,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description Iso3",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Iso4217", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description Iso4217",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("AbvMoneda", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 5,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 7,
				Description = "No description AbvMoneda",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("PhoneCode", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 10,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 8,
				Description = "No description PhoneCode",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<bool>("Status", new PropertyValue<bool>
			{
				Value = false,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 9,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(bool)
			});
			AddProperty<string>("Emoji", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 10,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 10,
				Description = "No description Emoji",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Icon", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 10,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 11,
				Description = "No description Icon",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Capital", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 50,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 12,
				Description = "No description Capital",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("States", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 13,
				Description = "No description States",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Region", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 14,
				Description = "No description Region",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<bool>("IsEnabled", new PropertyValue<bool>
			{
				Value = true,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 15,
				Description = "No description IsEnabled",
				IsIdentity = false,
				DataType = typeof(bool)
			});
               AddProperty<bool>("Needs2Ids", new PropertyValue<bool>
               {
                    Value = true,
                    IsPrimaryKey = false,
                    Length = 1,
                    Precision = 1,
                    IsRequiredInDataBase = true,
                    FieldId = 15,
                    Description = "No description Needs2Ids",
                    IsIdentity = false,
                    DataType = typeof(bool)
               });
          }
		#endregion

	}
}
