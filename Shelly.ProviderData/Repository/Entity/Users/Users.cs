using Shelly.Abstractions.Settings;
using Shelly.ProviderData.ExpressionExtensionSQL;
using Shelly.Abstractions.Interfaces;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class Users 
    /// </summary>
    [Serializable]
	public partial class Users : StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Users"/> class..
		/// </summary>
		public Users() : base()
		{
			Table = "Users";
			Owner = "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Users"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Users(IBaseSystem IBaseSystem) : base(IBaseSystem)
		{
			Table = "Users";
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
          [ColumnName("Uuid")]
          public string Uuid
          {
               get => GetPropertyValue<string>("Uuid");
               set => SetPropertyValue<string>("Uuid", value);
          }
          [ColumnName("UserName")]
          public string UserName
          {
               get => GetPropertyValue<string>("UserName");
               set => SetPropertyValue<string>("UserName", value);
          }
          [ColumnName("Email")]
          public string Email
          {
               get => GetPropertyValue<string>("Email");
               set => SetPropertyValue<string>("Email", value);
          }
          [ColumnName("Password")]
          public string Password
          {
               get => GetPropertyValue<string>("Password");
               set => SetPropertyValue<string>("Password", value);
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
          [ColumnName("Status")]
          public int Status
          {
               get => GetPropertyValue<int>("Status");
               set => SetPropertyValue<int>("Status", value);
          }
          [ColumnName("UserTypeId")]
          public int UserTypeId
          {
               get => GetPropertyValue<int>("UserTypeId");
               set => SetPropertyValue<int>("UserTypeId", value);
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
          /// Load row of the Users.		/// </summary>
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
			AddProperty<string>("UserName", new PropertyValue<string>
			{
				Value = String.Empty,
				IsPrimaryKey = false,
				Length = 100,
				Precision = 0,
				IsRequiredInDataBase = true,
				FieldId = 2,
				Description = "No description UserName",
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
				FieldId = 3,
				Description = "No description Email",
				IsIdentity = false,
				DataType = typeof(string)
			});
			AddProperty<string>("Password", new PropertyValue<string>
			{
                    Value = String.Empty,
                    IsPrimaryKey = false,
                    Length = -1,
                    Precision = 0,
                    IsRequiredInDataBase = false,
                    IsPassword = true,
                    FieldId = 4,
                    Description = "No description Password",
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
			AddProperty<int>("Status", new PropertyValue<int>
			{
				Value = default,
				IsPrimaryKey = false,
				Length = 1,
				Precision = 3,
				IsRequiredInDataBase = true,
				FieldId = 7,
				Description = "No description Status",
				IsIdentity = false,
				DataType = typeof(int)
			});
               AddProperty<int>("UserTypeId", new PropertyValue<int>
               {
                    Value = default,
                    IsPrimaryKey = false,
                    Length = 1,
                    Precision = 3,
                    IsRequiredInDataBase = true,
                    FieldId = 7,
                    Description = "No description UserTypeId",
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
				FieldId = 8,
				Description = "No description CreatedAt",
				IsIdentity = false,
				DataType = typeof(DateTime)
			});
		}
		#endregion

	}
}
