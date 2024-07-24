
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsHistory 
	/// </summary>
	[Serializable]
	public partial class PatientsHistory:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsHistory"/> class..
		/// </summary>
		public PatientsHistory():base()
		{
			Table = "PatientsHistory";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsHistory"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsHistory(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsHistory";
			Owner= "MedicalClinic";
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
		[ColumnName("CustomerId")]
		public long CustomerId
		{
			get => GetPropertyValue<long>("CustomerId");
			set => SetPropertyValue<long>("CustomerId", value);
		}
		[ColumnName("Type")]
		public string Type
		{
			get => GetPropertyValue<string>("Type");
			set => SetPropertyValue<string>("Type", value);
		}
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
		}
		[ColumnName("Familiar")]
		public string Familiar
		{
			get => GetPropertyValue<string>("Familiar");
			set => SetPropertyValue<string>("Familiar", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		[ColumnName("Diagnostico")]
		public string Diagnostico
		{
			get => GetPropertyValue<string>("Diagnostico");
			set => SetPropertyValue<string>("Diagnostico", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the PatientsHistory.		/// </summary>
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
			Properties = new Dictionary<string, Property>(7);

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
			 AddProperty<long>("CustomerId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description CustomerId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Type", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Type",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Familiar", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description Familiar",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("Diagnostico", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 1000,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description Diagnostico",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
