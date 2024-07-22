using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Helper;

namespace Shelly.ProviderData.Repository.Entity
{
    /// <summary>
    /// Class xsErrorSystem 
    /// </summary>
    [Serializable]
	public partial class ErrorSystem:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="ErrorSystem"/> class..
		/// </summary>
		public ErrorSystem():base()
		{
			Table = "ErrorSystem";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="ErrorSystem"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public ErrorSystem(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "ErrorSystem";
			Owner= "dbo";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public string Id
		{
			get => GetPropertyValue<string>("Id");
			set => SetPropertyValue<string>("Id", value);
		}
		[ColumnName("Type")]
		public int Type
		{
			get => GetPropertyValue<int>("Type");
			set => SetPropertyValue<int>("Type", value);
		}
		[ColumnName("HeaderDefinition")]
		public string HeaderDefinition
		{
			get => GetPropertyValue<string>("HeaderDefinition");
			set => SetPropertyValue<string>("HeaderDefinition", value);
		}
		[ColumnName("FootherDefinition")]
		public string FootherDefinition
		{
			get => GetPropertyValue<string>("FootherDefinition");
			set => SetPropertyValue<string>("FootherDefinition", value);
		}
		[ColumnName("TranslationKey")]
		public string TranslationKey
		{
			get => GetPropertyValue<string>("TranslationKey");
			set => SetPropertyValue<string>("TranslationKey", value);
		}
		[ColumnName("DefaultMessage")]
		public string DefaultMessage
		{
			get => GetPropertyValue<string>("DefaultMessage");
			set => SetPropertyValue<string>("DefaultMessage", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the xsErrorSystem.		/// </summary>
		/// <param name="psId">Id</param>
		public void Load(string id)
		{
			base.Load(id);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(6);

			 AddKeyField("Id",null);
			 AddProperty<string>("Id", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = true,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Id",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Type", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Type",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("HeaderDefinition", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description HeaderDefinition",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("FootherDefinition", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description FootherDefinition",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("TranslationKey", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description TranslationKey",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DefaultMessage", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description DefaultMessage",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
