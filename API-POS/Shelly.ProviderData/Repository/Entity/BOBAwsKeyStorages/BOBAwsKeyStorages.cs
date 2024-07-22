
namespace Shelly.POSProviderData.Repository
{
	/// <summary>
	/// Class AwsKeyStorages 
	/// </summary>
	[Serializable]
	public partial class AwsKeyStorages:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="AwsKeyStorages"/> class..
		/// </summary>
		public AwsKeyStorages():base()
		{
			Table = "AwsKeyStorages";
			Owner= "BOB";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="AwsKeyStorages"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public AwsKeyStorages(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "AwsKeyStorages";
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
		[ColumnName("Usr")]
		public string Usr
		{
			get => GetPropertyValue<string>("Usr");
			set => SetPropertyValue<string>("Usr", value);
		}
		[ColumnName("Pwd")]
		public string Pwd
		{
			get => GetPropertyValue<string>("Pwd");
			set => SetPropertyValue<string>("Pwd", value);
		}
		[ColumnName("Region")]
		public string Region
		{
			get => GetPropertyValue<string>("Region");
			set => SetPropertyValue<string>("Region", value);
		}
		[ColumnName("Bucket")]
		public string Bucket
		{
			get => GetPropertyValue<string>("Bucket");
			set => SetPropertyValue<string>("Bucket", value);
		}
		[ColumnName("Acl")]
		public string Acl
		{
			get => GetPropertyValue<string>("Acl");
			set => SetPropertyValue<string>("Acl", value);
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
		/// Load row of the AwsKeyStorages.		/// </summary>
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
			Properties = new Dictionary<string, Property>(8);

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
			 AddProperty<string>("Usr", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description Usr",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Pwd", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description Pwd",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Region", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Region",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Bucket", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Bucket",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Acl", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 50,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description Acl",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<bool>("Status", new PropertyValue<bool> {
			 Value = true,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 1,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(bool)
			});
			}
			#endregion

		}
	}
