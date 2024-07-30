
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsWeightLoss 
	/// </summary>
	public partial class PatientsWeightLoss:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsWeightLoss"/> class..
		/// </summary>
		public PatientsWeightLoss():base()
		{
			Table = "PatientsWeightLoss";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsWeightLoss"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsWeightLoss(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsWeightLoss";
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
		[ColumnName("Weight")]
		public double Weight
		{
			get => GetPropertyValue<double>("Weight");
			set => SetPropertyValue<double>("Weight", value);
		}
		[ColumnName("BMI")]
		public double BMI
		{
			get => GetPropertyValue<double>("BMI");
			set => SetPropertyValue<double>("BMI", value);
		}
		[ColumnName("FatPercentage")]
		public double FatPercentage
		{
			get => GetPropertyValue<double>("FatPercentage");
			set => SetPropertyValue<double>("FatPercentage", value);
		}
		[ColumnName("ViceralFatPercentage")]
		public double ViceralFatPercentage
		{
			get => GetPropertyValue<double>("ViceralFatPercentage");
			set => SetPropertyValue<double>("ViceralFatPercentage", value);
		}
		[ColumnName("MusclePercentage")]
		public double MusclePercentage
		{
			get => GetPropertyValue<double>("MusclePercentage");
			set => SetPropertyValue<double>("MusclePercentage", value);
		}
		[ColumnName("WaterPercentage")]
		public double WaterPercentage
		{
			get => GetPropertyValue<double>("WaterPercentage");
			set => SetPropertyValue<double>("WaterPercentage", value);
		}
		[ColumnName("BonePercentage")]
		public double BonePercentage
		{
			get => GetPropertyValue<double>("BonePercentage");
			set => SetPropertyValue<double>("BonePercentage", value);
		}
		[ColumnName("ProteinPercentage")]
		public double ProteinPercentage
		{
			get => GetPropertyValue<double>("ProteinPercentage");
			set => SetPropertyValue<double>("ProteinPercentage", value);
		}
		[ColumnName("Metabolism")]
		public double Metabolism
		{
			get => GetPropertyValue<double>("Metabolism");
			set => SetPropertyValue<double>("Metabolism", value);
		}
		[ColumnName("PhysicalAge")]
		public double PhysicalAge
		{
			get => GetPropertyValue<double>("PhysicalAge");
			set => SetPropertyValue<double>("PhysicalAge", value);
		}
		[ColumnName("BiologicalAge")]
		public double BiologicalAge
		{
			get => GetPropertyValue<double>("BiologicalAge");
			set => SetPropertyValue<double>("BiologicalAge", value);
		}
		[ColumnName("CreatedAt")]
		public string CreatedAt
		{
			get => GetPropertyValue<string>("CreatedAt");
			set => SetPropertyValue<string>("CreatedAt", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the PatientsWeightLoss.		/// </summary>
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
			Properties = new Dictionary<string, Property>(16);

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
			 AddProperty<double>("Waist", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
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
			 FieldId = 3,
			 Description = "No description Hip",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Weight", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description Weight",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("BMI", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description BMI",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("FatPercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
			 Description = "No description FatPercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("ViceralFatPercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 7,
			 Description = "No description ViceralFatPercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("MusclePercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 8,
			 Description = "No description MusclePercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("WaterPercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 9,
			 Description = "No description WaterPercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("BonePercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 10,
			 Description = "No description BonePercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("ProteinPercentage", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 11,
			 Description = "No description ProteinPercentage",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("Metabolism", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 12,
			 Description = "No description Metabolism",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("PhysicalAge", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 13,
			 Description = "No description PhysicalAge",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<double>("BiologicalAge", new PropertyValue<double> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 53,
			 IsRequiredInDataBase = true,
			 FieldId = 14,
			 Description = "No description BiologicalAge",
			 IsIdentity = false,
			 DataType = typeof(double)
			});
			 AddProperty<string>("CreatedAt", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 3,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 15,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
