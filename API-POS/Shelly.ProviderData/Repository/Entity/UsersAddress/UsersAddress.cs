﻿using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class UsersAddress 
    /// </summary>
    [Serializable]
	public partial class UsersAddress:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAddress"/> class..
		/// </summary>
		public UsersAddress():base()
		{
			Table = "Address";
			Owner= "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersAddress"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersAddress(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Address";
			Owner= "dUsersbo";
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
		[ColumnName("Id")]
		public int Id
		{
			get => GetPropertyValue<int>("Id");
			set => SetPropertyValue<int>("Id", value);
		}
		[ColumnName("City")]
		public string City
		{
			get => GetPropertyValue<string>("City");
			set => SetPropertyValue<string>("City", value);
		}
		[ColumnName("Country")]
		public int Country
		{
			get => GetPropertyValue<int>("Country");
			set => SetPropertyValue<int>("Country", value);
		}
		[ColumnName("State")]
		public string State
		{
			get => GetPropertyValue<string>("State");
			set => SetPropertyValue<string>("State", value);
		}
		[ColumnName("Street")]
		public string Street
		{
			get => GetPropertyValue<string>("Street");
			set => SetPropertyValue<string>("Street", value);
		}
		[ColumnName("ZipCode")]
		public string ZipCode
		{
			get => GetPropertyValue<string>("ZipCode");
			set => SetPropertyValue<string>("ZipCode", value);
		}
		[ColumnName("IsComplete")]
		public bool IsComplete
		{
			get => GetPropertyValue<bool>("IsComplete");
			set => SetPropertyValue<bool>("IsComplete", value);
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
		/// Load row of the UsersAddress.		/// </summary>
		/// <param name="poUserNumber">UserNumber</param>
		/// <param name="poId">Id</param>
		public void Load(long usernumber,int id)
		{
			base.Load(usernumber,id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(2);
			Properties = new Dictionary<string, Property>(9);

			 AddKeyField("UserNumber",null);
			 AddKeyField("Id",null);
			 AddProperty<long>("UserNumber", new PropertyValue<long> {
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
			 AddProperty<int>("Id", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Id",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("City", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 500,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description City",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Country", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Country",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("State", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 500,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description State",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Street", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 1000,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description Street",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ZipCode", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 10,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description ZipCode",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("IsComplete", new PropertyValue<bool> {
			 Value = false,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description IsComplete",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
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
