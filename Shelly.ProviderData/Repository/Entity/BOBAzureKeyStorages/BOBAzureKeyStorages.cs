
namespace Shelly.POSProviderData.Repository
{
	/// <summary>
	/// Class AzureKeyStorages 
	/// </summary>
	[Serializable]
	public partial class AzureKeyStorages:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="AzureKeyStorages"/> class..
		/// </summary>
		public AzureKeyStorages():base()
		{
			Table = "AzureKeyStorages";
			Owner= "BOB";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="AzureKeyStorages"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public AzureKeyStorages(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "AzureKeyStorages";
			Owner= "BOB";
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
		[ColumnName("Environment")]
		public int Environment
		{
			get => GetPropertyValue<int>("Environment");
			set => SetPropertyValue<int>("Environment", value);
		}
		[ColumnName("ContainerName")]
		public string ContainerName
		{
			get => GetPropertyValue<string>("ContainerName");
			set => SetPropertyValue<string>("ContainerName", value);
		}
		[ColumnName("AccountName")]
		public string AccountName
		{
			get => GetPropertyValue<string>("AccountName");
			set => SetPropertyValue<string>("AccountName", value);
		}
		[ColumnName("AccountKey")]
		public string AccountKey
		{
			get => GetPropertyValue<string>("AccountKey");
			set => SetPropertyValue<string>("AccountKey", value);
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
		/// Load row of the AzureKeyStorages.		/// </summary>
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
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(6);

			 AddKeyField("Id",null);
			 AddProperty<long>("Id", new PropertyValue<long> {
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
			 AddProperty<int>("Environment", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 2,
			 Precision = 5,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Environment",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("ContainerName", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description ContainerName",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("AccountName", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description AccountName",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("AccountKey", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 500,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description AccountKey",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("Status", new PropertyValue<bool> {
			 Value = true,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			}
			#endregion

		}
	}
