
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsLaboratories 
	/// </summary>
	public partial class PatientsLaboratories:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsLaboratories"/> class..
		/// </summary>
		public PatientsLaboratories():base()
		{
			Table = "PatientsLaboratories";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsLaboratories"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsLaboratories(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsLaboratories";
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
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		[ColumnName("ImageId")]
		public long ImageId
		{
			get => GetPropertyValue<long>("ImageId");
			set => SetPropertyValue<long>("ImageId", value);
		}
		[ColumnName("LaboratoryId")]
		public long LaboratoryId
		{
			get => GetPropertyValue<long>("LaboratoryId");
			set => SetPropertyValue<long>("LaboratoryId", value);
		}
		[ColumnName("TypeLaboratoryId")]
		public long TypeLaboratoryId
		{
			get => GetPropertyValue<long>("TypeLaboratoryId");
			set => SetPropertyValue<long>("TypeLaboratoryId", value);
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
		/// Load row of the PatientsLaboratories.		/// </summary>
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
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<long>("ImageId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description ImageId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("LaboratoryId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description LaboratoryId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("TypeLaboratoryId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description TypeLaboratoryId",
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
			 FieldId = 7,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
