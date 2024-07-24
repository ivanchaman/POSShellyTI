using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class UsersBlackList 
    /// </summary>
    [Serializable]
	public partial class UsersBlackList:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersBlackList"/> class..
		/// </summary>
		public UsersBlackList():base()
		{
			Table = "BlackList";
			Owner= "Users";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="UsersBlackList"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersBlackList(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "BlackList";
			Owner= "Users";
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
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the UsersBlackList.		/// </summary>
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
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(2);

			 AddKeyField("UserNumber",null);
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
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
