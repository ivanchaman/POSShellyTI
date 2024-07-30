
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientdPrescriptions 
	/// </summary>
	public partial class PatientdPrescriptions:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientdPrescriptions"/> class..
		/// </summary>
		public PatientdPrescriptions():base()
		{
			Table = "PatientdPrescriptions";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientdPrescriptions"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientdPrescriptions(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientdPrescriptions";
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
		[ColumnName("Quantity")]
		public double Quantity
		{
			get => GetPropertyValue<double>("Quantity");
			set => SetPropertyValue<double>("Quantity", value);
		}
		[ColumnName("Drug")]
		public string Drug
		{
			get => GetPropertyValue<string>("Drug");
			set => SetPropertyValue<string>("Drug", value);
		}
		[ColumnName("Dosage")]
		public string Dosage
		{
			get => GetPropertyValue<string>("Dosage");
			set => SetPropertyValue<string>("Dosage", value);
		}
		[ColumnName("Frequency")]
		public string Frequency
		{
			get => GetPropertyValue<string>("Frequency");
			set => SetPropertyValue<string>("Frequency", value);
		}
		[ColumnName("Duration")]
		public string Duration
		{
			get => GetPropertyValue<string>("Duration");
			set => SetPropertyValue<string>("Duration", value);
		}
		[ColumnName("Substance")]
		public string Substance
		{
			get => GetPropertyValue<string>("Substance");
			set => SetPropertyValue<string>("Substance", value);
		}
		[ColumnName("Via")]
		public int Via
		{
			get => GetPropertyValue<int>("Via");
			set => SetPropertyValue<int>("Via", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
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
		/// Load row of the PatientdPrescriptions.		/// </summary>
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
			Properties = new Dictionary<string, Property>(11);

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
			 AddProperty<double>("Quantity", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 9,
			 Precision = 18,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description Quantity",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<string>("Drug", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description Drug",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Dosage", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Dosage",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Frequency", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Frequency",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Duration", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description Duration",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Substance", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description Substance",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Via", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = false,
			 FieldId = 8,
			 Description = "No description Via",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 9,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<DateTime>("CreatedAt", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 23,
			 IsRequiredInDataBase = true,
			 FieldId = 10,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
