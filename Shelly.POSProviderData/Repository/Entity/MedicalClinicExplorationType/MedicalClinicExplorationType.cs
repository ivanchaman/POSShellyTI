
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class ExplorationType 
	/// </summary>
	public partial class ExplorationType:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="ExplorationType"/> class..
		/// </summary>
		public ExplorationType():base()
		{
			Table = "ExplorationType";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="ExplorationType"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public ExplorationType(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "ExplorationType";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		#endregion
		#region Propiedades
		[ColumnName("Id")]
		public int Id
		{
			get => GetPropertyValue<int>("Id");
			set => SetPropertyValue<int>("Id", value);
		}
		[ColumnName("Name")]
		public string Name
		{
			get => GetPropertyValue<string>("Name");
			set => SetPropertyValue<string>("Name", value);
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
		/// Load row of the ExplorationType.		/// </summary>
		/// <param name="poId">Id</param>
		public void Load(int id)
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
			 AddProperty<int>("Id", new PropertyValue<int> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 4,
			 Precision = 10,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Id",
			 IsIdentity = true,
			 DataType = typeof(int)
			});
			 AddProperty<string>("Name", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = true,
			 FieldId = 1,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
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
