
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class MedicationDetails 
	/// </summary>
	[Serializable]
	public partial class MedicationDetails:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="MedicationDetails"/> class..
		/// </summary>
		public MedicationDetails():base()
		{
			Table = "MedicationDetails";
			Owner= "POS";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="MedicationDetails"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public MedicationDetails(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "MedicationDetails";
			Owner= "POS";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("ProductId")]
		public long ProductId
		{
			get => GetPropertyValue<long>("ProductId");
			set => SetPropertyValue<long>("ProductId", value);
		}
		[ColumnName("MedicineName")]
		public string MedicineName
		{
			get => GetPropertyValue<string>("MedicineName");
			set => SetPropertyValue<string>("MedicineName", value);
		}
		[ColumnName("GenericName")]
		public string GenericName
		{
			get => GetPropertyValue<string>("GenericName");
			set => SetPropertyValue<string>("GenericName", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		[ColumnName("ActiveIngredient")]
		public string ActiveIngredient
		{
			get => GetPropertyValue<string>("ActiveIngredient");
			set => SetPropertyValue<string>("ActiveIngredient", value);
		}
		[ColumnName("Concentration")]
		public string Concentration
		{
			get => GetPropertyValue<string>("Concentration");
			set => SetPropertyValue<string>("Concentration", value);
		}
		[ColumnName("DosageForm")]
		public string DosageForm
		{
			get => GetPropertyValue<string>("DosageForm");
			set => SetPropertyValue<string>("DosageForm", value);
		}
		[ColumnName("LaboratoryName")]
		public string LaboratoryName
		{
			get => GetPropertyValue<string>("LaboratoryName");
			set => SetPropertyValue<string>("LaboratoryName", value);
		}
		[ColumnName("Strength")]
		public string Strength
		{
			get => GetPropertyValue<string>("Strength");
			set => SetPropertyValue<string>("Strength", value);
		}
		[ColumnName("UnitOfMeasureId")]
		public long UnitOfMeasureId
		{
			get => GetPropertyValue<long>("UnitOfMeasureId");
			set => SetPropertyValue<long>("UnitOfMeasureId", value);
		}
		[ColumnName("CreatedAt")]
		public DateTime CreatedAt
		{
			get => GetPropertyValue<DateTime>("CreatedAt");
			set => SetPropertyValue<DateTime>("CreatedAt", value);
		}
		[ColumnName("Status")]
		public int Status
		{
			get => GetPropertyValue<int>("Status");
			set => SetPropertyValue<int>("Status", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the MedicationDetails.		/// </summary>
		/// <param name="poProductId">ProductId</param>
		public void Load(long productid)
		{
			base.Load(productid);
		}
		/// <summary>
		/// LoadColumnProperties
		/// </summary>
		protected override void LoadColumnProperties()
		{
			if (!Object.Equals(KeyFields,null) && !Object.Equals(Properties,null)) 
			  return;

			KeyFields= new Dictionary<string,object>(1);
			Properties = new Dictionary<string, Property>(12);

			 AddKeyField("ProductId",null);
			 AddProperty<long>("ProductId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description ProductId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("MedicineName", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description MedicineName",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("GenericName", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description GenericName",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ActiveIngredient", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description ActiveIngredient",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Concentration", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description Concentration",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DosageForm", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description DosageForm",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LaboratoryName", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description LaboratoryName",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Strength", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 8,
			 Description = "No description Strength",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<long>("UnitOfMeasureId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 9,
			 Description = "No description UnitOfMeasureId",
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
			 FieldId = 10,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 11,
			 Description = "No description Status",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			}
			#endregion

		}
	}
