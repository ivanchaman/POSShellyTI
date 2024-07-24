
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsNotes 
	/// </summary>
	[Serializable]
	public partial class PatientsNotes:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsNotes"/> class..
		/// </summary>
		public PatientsNotes():base()
		{
			Table = "PatientsNotes";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsNotes"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsNotes(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsNotes";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("MedicalServicesId")]
		public long MedicalServicesId
		{
			get => GetPropertyValue<long>("MedicalServicesId");
			set => SetPropertyValue<long>("MedicalServicesId", value);
		}
		[ColumnName("Reasons")]
		public string Reasons
		{
			get => GetPropertyValue<string>("Reasons");
			set => SetPropertyValue<string>("Reasons", value);
		}
		[ColumnName("PEEA")]
		public string PEEA
		{
			get => GetPropertyValue<string>("PEEA");
			set => SetPropertyValue<string>("PEEA", value);
		}
		[ColumnName("LaboratoryResults")]
		public string LaboratoryResults
		{
			get => GetPropertyValue<string>("LaboratoryResults");
			set => SetPropertyValue<string>("LaboratoryResults", value);
		}
		[ColumnName("Diagnostics")]
		public string Diagnostics
		{
			get => GetPropertyValue<string>("Diagnostics");
			set => SetPropertyValue<string>("Diagnostics", value);
		}
		[ColumnName("Remarks")]
		public string Remarks
		{
			get => GetPropertyValue<string>("Remarks");
			set => SetPropertyValue<string>("Remarks", value);
		}
		[ColumnName("Forecasts")]
		public string Forecasts
		{
			get => GetPropertyValue<string>("Forecasts");
			set => SetPropertyValue<string>("Forecasts", value);
		}
		[ColumnName("HeartRate")]
		public string HeartRate
		{
			get => GetPropertyValue<string>("HeartRate");
			set => SetPropertyValue<string>("HeartRate", value);
		}
		[ColumnName("RespiratoryRate")]
		public string RespiratoryRate
		{
			get => GetPropertyValue<string>("RespiratoryRate");
			set => SetPropertyValue<string>("RespiratoryRate", value);
		}
		[ColumnName("Oximetry")]
		public double Oximetry
		{
			get => GetPropertyValue<double>("Oximetry");
			set => SetPropertyValue<double>("Oximetry", value);
		}
		[ColumnName("Temperature")]
		public double Temperature
		{
			get => GetPropertyValue<double>("Temperature");
			set => SetPropertyValue<double>("Temperature", value);
		}
		[ColumnName("ArterialTension")]
		public string ArterialTension
		{
			get => GetPropertyValue<string>("ArterialTension");
			set => SetPropertyValue<string>("ArterialTension", value);
		}
		[ColumnName("Height")]
		public double Height
		{
			get => GetPropertyValue<double>("Height");
			set => SetPropertyValue<double>("Height", value);
		}
		[ColumnName("Weight")]
		public double Weight
		{
			get => GetPropertyValue<double>("Weight");
			set => SetPropertyValue<double>("Weight", value);
		}
		[ColumnName("Waist")]
		public double Waist
		{
			get => GetPropertyValue<double>("Waist");
			set => SetPropertyValue<double>("Waist", value);
		}
		[ColumnName("Hip")]
		public double Hip
		{
			get => GetPropertyValue<double>("Hip");
			set => SetPropertyValue<double>("Hip", value);
		}
		[ColumnName("BMI")]
		public double BMI
		{
			get => GetPropertyValue<double>("BMI");
			set => SetPropertyValue<double>("BMI", value);
		}
		[ColumnName("Recommendations")]
		public string Recommendations
		{
			get => GetPropertyValue<string>("Recommendations");
			set => SetPropertyValue<string>("Recommendations", value);
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
		/// Load row of the PatientsNotes.		/// </summary>
		/// <param name="poMedicalServicesId">MedicalServicesId</param>
		public void Load(long medicalservicesid)
		{
			base.Load(medicalservicesid);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(19);

			 AddKeyField("MedicalServicesId",null);
			 AddProperty<long>("MedicalServicesId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description MedicalServicesId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Reasons", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 1,
			 Description = "No description Reasons",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PEEA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description PEEA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LaboratoryResults", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description LaboratoryResults",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Diagnostics", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Diagnostics",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Remarks", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Remarks",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Forecasts", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description Forecasts",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("HeartRate", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description HeartRate",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("RespiratoryRate", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 8,
			 Description = "No description RespiratoryRate",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<double>("Oximetry", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = false,
			 FieldId = 9,
			 Description = "No description Oximetry",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Temperature", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = false,
			 FieldId = 10,
			 Description = "No description Temperature",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<string>("ArterialTension", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 11,
			 Description = "No description ArterialTension",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<double>("Height", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 12,
			 Description = "No description Height",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Weight", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 13,
			 Description = "No description Weight",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Waist", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 14,
			 Description = "No description Waist",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Hip", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 15,
			 Description = "No description Hip",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("BMI", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 16,
			 Description = "No description BMI",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<string>("Recommendations", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 17,
			 Description = "No description Recommendations",
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
			 FieldId = 18,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
