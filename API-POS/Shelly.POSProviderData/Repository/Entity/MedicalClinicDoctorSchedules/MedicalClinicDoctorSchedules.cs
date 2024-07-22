
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class DoctorSchedules 
	/// </summary>
	[Serializable]
	public partial class DoctorSchedules:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="DoctorSchedules"/> class..
		/// </summary>
		public DoctorSchedules():base()
		{
			Table = "DoctorSchedules";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="DoctorSchedules"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public DoctorSchedules(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "DoctorSchedules";
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
		[ColumnName("Company")]
		public long Company
		{
			get => GetPropertyValue<long>("Company");
			set => SetPropertyValue<long>("Company", value);
		}
		[ColumnName("DoctorId")]
		public long DoctorId
		{
			get => GetPropertyValue<long>("DoctorId");
			set => SetPropertyValue<long>("DoctorId", value);
		}
		[ColumnName("DayOfWeek")]
		public int DayOfWeek
		{
			get => GetPropertyValue<int>("DayOfWeek");
			set => SetPropertyValue<int>("DayOfWeek", value);
		}
		[ColumnName("StartTime")]
		public DateTime StartTime
		{
			get => GetPropertyValue<DateTime>("StartTime");
			set => SetPropertyValue<DateTime>("StartTime", value);
		}
		[ColumnName("EndTime")]
		public DateTime EndTime
		{
			get => GetPropertyValue<DateTime>("EndTime");
			set => SetPropertyValue<DateTime>("EndTime", value);
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
		/// Load row of the DoctorSchedules.		/// </summary>
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
			 AddProperty<long>("Company", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 1,
			 Description = "No description Company",
			 IsIdentity = false,
			 IsCompanyField = true,
			 DataType = typeof(long)
			});
			 AddProperty<long>("DoctorId", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description DoctorId",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<int>("DayOfWeek", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 3,
			 Description = "No description DayOfWeek",
			 IsIdentity = false,
			 DataType = typeof(int)
			});
			 AddProperty<DateTime>("StartTime", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 5,
			 Precision = 16,
			 IsRequiredInDataBase = true,
			 FieldId = 4,
			 Description = "No description StartTime",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<DateTime>("EndTime", new PropertyValue<DateTime> {
			 Value = DefaultDateTime,
			 IsIncludeHours = true,
			 IsPrimaryKey = false,
			 Length = 5,
			 Precision = 16,
			 IsRequiredInDataBase = true,
			 FieldId = 5,
			 Description = "No description EndTime",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 6,
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
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
