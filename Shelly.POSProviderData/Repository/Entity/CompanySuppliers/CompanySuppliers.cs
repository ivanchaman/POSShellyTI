﻿
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Suppliers 
	/// </summary>
	public partial class Suppliers : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Suppliers"/> class..
		/// </summary>
		public Suppliers() : base()
		{
			Table = "Suppliers";
			Owner = "Company";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Suppliers"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Suppliers(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Suppliers";
			Owner = "Company";
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
		[ColumnName("ExternalId")]
		public string ExternalId
		{
			get => GetPropertyValue<string>("ExternalId");
			set => SetPropertyValue<string>("ExternalId", value);
		}
		[ColumnName("DisplayName")]
		public string DisplayName
		{
			get => GetPropertyValue<string>("DisplayName");
			set => SetPropertyValue<string>("DisplayName", value);
		}
		[ColumnName("AvatarImageId")]
		public long AvatarImageId
		{
			get => GetPropertyValue<long>("AvatarImageId");
			set => SetPropertyValue<long>("AvatarImageId", value);
		}
		[ColumnName("PhoneCode")]
		public string PhoneCode
		{
			get => GetPropertyValue<string>("PhoneCode");
			set => SetPropertyValue<string>("PhoneCode", value);
		}
		[ColumnName("PhoneNumber")]
		public string PhoneNumber
		{
			get => GetPropertyValue<string>("PhoneNumber");
			set => SetPropertyValue<string>("PhoneNumber", value);
		}
		[ColumnName("Email")]
		public string Email
		{
			get => GetPropertyValue<string>("Email");
			set => SetPropertyValue<string>("Email", value);
		}
		[ColumnName("CountryCode")]
		public int CountryCode
		{
			get => GetPropertyValue<int>("CountryCode");
			set => SetPropertyValue<int>("CountryCode", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		[ColumnName("Rfc")]
		public string Rfc
		{
			get => GetPropertyValue<string>("Rfc");
			set => SetPropertyValue<string>("Rfc", value);
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
		/// Load row of the Suppliers.		/// </summary>
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
			Properties = new Dictionary<string, Property>(12);

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
			AddProperty<string>("ExternalId", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 10,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description ExternalId",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("DisplayName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description DisplayName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<long>("AvatarImageId", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 19,
				IsRequiredInDataBase = false,
				FieldId = 4,
				Description = "No description AvatarImageId",
				IsIdentity = false,
				DataType = typeof(long)
			});
			AddProperty<string>("PhoneCode", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 5,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 5,
				Description = "No description PhoneCode",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("PhoneNumber", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 6,
				Description = "No description PhoneNumber",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Email", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 7,
				Description = "No description Email",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<int>("CountryCode", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 8,
				Description = "No description CountryCode",
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
				FieldId = 9,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<string>("Rfc", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 26,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 10,
				Description = "No description Rfc",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsIncludeHours = true,
				IsPrimaryKey = false,
				Length = 8,
				Precision = 23,
				IsRequiredInDataBase = true,
				FieldId = 14,
				Description = "No description CreatedAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
		}
		#endregion

	}
}