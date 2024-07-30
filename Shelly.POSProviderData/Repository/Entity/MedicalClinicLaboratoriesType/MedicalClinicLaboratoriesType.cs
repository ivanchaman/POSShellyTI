
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class LaboratoriesType 
	/// </summary>
	public partial class LaboratoriesType:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="LaboratoriesType"/> class..
		/// </summary>
		public LaboratoriesType():base()
		{
			Table = "LaboratoriesType";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="LaboratoriesType"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public LaboratoriesType(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "LaboratoriesType";
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
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
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
		/// Load row of the LaboratoriesType.		/// </summary>
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
			Properties = new Dictionary<string, Property>(4);

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
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = -1,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 1,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<int>("Status", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = false,
			 Length = 1,
			 Precision = 3,
			 IsRequiredInDataBase = true,
			 FieldId = 2,
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
			 FieldId = 3,
			 Description = "No description CreatedAt",
			 IsIdentity = false,
			 DataType = typeof(DateTime)
			});
			}
			#endregion

		}
	}
