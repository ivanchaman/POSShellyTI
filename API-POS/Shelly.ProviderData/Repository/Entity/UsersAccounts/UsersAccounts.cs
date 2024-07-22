using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class UsersAccounts 
	/// </summary>
	[Serializable]
	public partial class UsersAccounts : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAccounts"/> class..
		/// </summary>
		public UsersAccounts() : base()
		{
			Table = "Accounts";
			Owner = "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAccounts"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersAccounts(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Accounts";
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
		[ColumnName("FirstName")]
		public string FirstName
		{
			get => GetPropertyValue<string>("FirstName");
			set => SetPropertyValue<string>("FirstName", value);
		}
		[ColumnName("MiddleName")]
		public string MiddleName
		{
			get => GetPropertyValue<string>("MiddleName");
			set => SetPropertyValue<string>("MiddleName", value);
		}
		[ColumnName("LastName")]
		public string LastName
		{
			get => GetPropertyValue<string>("LastName");
			set => SetPropertyValue<string>("LastName", value);
		}
		[ColumnName("SecondLastName")]
		public string SecondLastName
		{
			get => GetPropertyValue<string>("SecondLastName");
			set => SetPropertyValue<string>("SecondLastName", value);
		}
		[ColumnName("AvatarImageId")]
		public long AvatarImageId
		{
			get => GetPropertyValue<long>("AvatarImageId");
			set => SetPropertyValue<long>("AvatarImageId", value);
		}
		[ColumnName("SSNNationalId")]
		public string SSNNationalId
		{
			get => GetPropertyValue<string>("SSNNationalId");
			set => SetPropertyValue<string>("SSNNationalId", value);
		}
		[ColumnName("Birthday")]
		public DateTime Birthday
		{
			get => GetPropertyValue<DateTime>("Birthday");
			set => SetPropertyValue<DateTime>("Birthday", value);
		}
		[ColumnName("Gender")]
		public int Gender
		{
			get => GetPropertyValue<int>("Gender");
			set => SetPropertyValue<int>("Gender", value);
		}
		[ColumnName("Nationality")]
		public int Nationality
		{
			get => GetPropertyValue<int>("Nationality");
			set => SetPropertyValue<int>("Nationality", value);
		}
		[ColumnName("PlaceOfBirth")]
		public int PlaceOfBirth
		{
			get => GetPropertyValue<int>("PlaceOfBirth");
			set => SetPropertyValue<int>("PlaceOfBirth", value);
		}
		[ColumnName("IsComplete")]
		public bool IsComplete
		{
			get => GetPropertyValue<bool>("IsComplete");
			set => SetPropertyValue<bool>("IsComplete", value);
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
          [ColumnName("useBillingToShipping")]
          public bool UseBillingToShipping
          {
               get => GetPropertyValue<bool>("useBillingToShipping");
               set => SetPropertyValue<bool>("useBillingToShipping", value);
          }
          
          #endregion
          #region Funciones
          /// <summary>
          /// Load row of the UsersAccounts.		/// </summary>
          /// <param name="poUserNumber">UserNumber</param>
          public void Load(long usernumber)
		{
			base.Load(usernumber);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields, null) && !Object.Equals(Properties, null))
				return;

			KeyFields = new Dictionary<string, object>(1);
			Properties = new Dictionary<string, Property>(14);

			AddKeyField("UserNumber", null);
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
			AddProperty<string>("FirstName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 1,
				Description = "No description FirstName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("MiddleName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 2,
				Description = "No description MiddleName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("LastName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 3,
				Description = "No description LastName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("SecondLastName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 4,
				Description = "No description SecondLastName",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<long>("AvatarImageId", new PropertyValue<long>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 1000,
				Precision = 0,
				IsRequiredInDataBase = false,
				FieldId = 5,
				Description = "No description AvatarImageId",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("SSNNationalId", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = -1,
				Precision = 0,
				IsRequiredInDataBase = false,
                    IsEncrypted = true,
                    FieldId = 6,
				Description = "No description SSNNationalId",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<DateTime>("Birthday", new PropertyValue<DateTime>
			{
				Value = DefaultDateTime,
				IsPrimaryKey = false,
				Length = 3,
				Precision = 10,
				IsRequiredInDataBase = false,
				FieldId = 7,
				Description = "No description Birthday",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
			AddProperty<int>("Gender", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = false,
				FieldId = 8,
				Description = "No description Gender",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<int>("Nationality", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = false,
				FieldId = 9,
				Description = "No description Nationality",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<int>("PlaceOfBirth", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 4,
				Precision = 10,
				IsRequiredInDataBase = true,
				FieldId = 10,
				Description = "No description PlaceOfBirth",
				IsIdentity = false,
				DataType = typeof(int)
			});
			AddProperty<bool>("IsComplete", new PropertyValue<bool>
			{
				Value = false,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 1,
				IsRequiredInDataBase = true,
				FieldId = 11,
				Description = "No description IsComplete",
				IsIdentity = false,
				DataType = typeof(bool)
			});
			AddProperty<int>("Status", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 3,
				IsRequiredInDataBase = true,
				FieldId = 12,
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
				FieldId = 13,
				Description = "No description CreatedAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
               AddProperty<bool>("useBillingToShipping", new PropertyValue<bool>
               {
                    Value = default,
                    IsPrimaryKey = false,
                    Length = 1,
                    Precision = 3,
                    IsRequiredInDataBase = true,
                    FieldId = 12,
                    Description = "No description useBillingToShipping",
                    IsIdentity = false,
                    DataType = typeof(bool)
               });
          }
		#endregion

	}
}
