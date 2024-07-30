
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsExploration 
	/// </summary>
	public partial class PatientsExploration:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsExploration"/> class..
		/// </summary>
		public PatientsExploration():base()
		{
			Table = "PatientsExploration";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsExploration"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsExploration(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsExploration";
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
		[ColumnName("MedicalServicesId")]
		public long MedicalServicesId
		{
			get => GetPropertyValue<long>("MedicalServicesId");
			set => SetPropertyValue<long>("MedicalServicesId", value);
		}
		[ColumnName("Type")]
		public int Type
		{
			get => GetPropertyValue<int>("Type");
			set => SetPropertyValue<int>("Type", value);
		}
		[ColumnName("Observations")]
		public string Observations
		{
			get => GetPropertyValue<string>("Observations");
			set => SetPropertyValue<string>("Observations", value);
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
		/// Load row of the PatientsExploration.		/// </summary>
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
			Properties = new Dictionary<string, Property>(5);

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
			 AddProperty<long>("MedicalServicesId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description MedicalServicesId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<int>("Type", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description Type",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<string>("Observations", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description Observations",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
