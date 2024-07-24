namespace Shelly.Abstractions.Repository.Entity
{
     /// <summary>
     /// Class CompaniesTransactionsFeeTypeE 
     /// </summary>
     [Serializable]
	public partial class CompaniesTransactionsFeeTypeE: StaticEntity
     {
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeE"/> class..
		/// </summary>
		public CompaniesTransactionsFeeTypeE():base()
		{
			Table = "CompaniesTransactionsFeeTypeE";
			Owner= "dbo";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="CompaniesTransactionsFeeTypeE"/> class..
		/// </summary>
		/// <param name="BaseSystem">base system</param>
		public CompaniesTransactionsFeeTypeE(IBaseSystem BaseSystem):base (BaseSystem)
		{
			Table = "CompaniesTransactionsFeeTypeE";
			Owner= "dbo";
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
		[ColumnName("Description")]
		public string Description
		{
			get => GetPropertyValue<string>("Description");
			set => SetPropertyValue<string>("Description", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the CompaniesTransactionsFeeTypeE.		/// </summary>
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
			Properties = new Dictionary<string, Property>(3);

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
			 Length = 100,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 1,
			 Description = "No description Name",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("Description", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 1000,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description Description",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
