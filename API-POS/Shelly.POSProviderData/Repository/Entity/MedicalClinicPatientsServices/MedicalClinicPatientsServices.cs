
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class PatientsServices 
	/// </summary>
	[Serializable]
	public partial class PatientsServices:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsServices"/> class..
		/// </summary>
		public PatientsServices():base()
		{
			Table = "PatientsServices";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="PatientsServices"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public PatientsServices(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "PatientsServices";
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
		[ColumnName("DoctorsId")]
		public long DoctorsId
		{
			get => GetPropertyValue<long>("DoctorsId");
			set => SetPropertyValue<long>("DoctorsId", value);
		}
		[ColumnName("CustomerId")]
		public long CustomerId
		{
			get => GetPropertyValue<long>("CustomerId");
			set => SetPropertyValue<long>("CustomerId", value);
		}
		[ColumnName("ServiceId")]
		public long ServiceId
		{
			get => GetPropertyValue<long>("ServiceId");
			set => SetPropertyValue<long>("ServiceId", value);
		}
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
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
		/// Load row of the PatientsServices.		/// </summary>
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
			 AddProperty<long>("DoctorsId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description DoctorsId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("CustomerId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
			 Description = "No description CustomerId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<long>("ServiceId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description ServiceId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 255,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description Description",
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
			 FieldId = 5,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
