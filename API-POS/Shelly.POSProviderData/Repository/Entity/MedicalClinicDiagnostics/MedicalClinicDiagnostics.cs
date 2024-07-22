
namespace Shelly.POSProviderData.Repository.Entity
{
	/// <summary>
	/// Class Diagnostics 
	/// </summary>
	[Serializable]
	public partial class Diagnostics:StaticEntity
	{
		#region Contructor
		/// <summary>
		///  Initializes a new instance of the <see cref="Diagnostics"/> class..
		/// </summary>
		public Diagnostics():base()
		{
			Table = "Diagnostics";
			Owner= "MedicalClinic";
			LoadColumnProperties();

		}
		/// <summary>
		///  Initializes a new instance of the <see cref="Diagnostics"/> class..
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public Diagnostics(IBaseSystem IBaseSystem):base (IBaseSystem)
		{
			Table = "Diagnostics";
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
		[ColumnName("LETRA")]
		public string LETRA
		{
			get => GetPropertyValue<string>("LETRA");
			set => SetPropertyValue<string>("LETRA", value);
		}
		[ColumnName("CATALOG_KEY")]
		public string CATALOG_KEY
		{
			get => GetPropertyValue<string>("CATALOG_KEY");
			set => SetPropertyValue<string>("CATALOG_KEY", value);
		}
		[ColumnName("NOMBRE")]
		public string NOMBRE
		{
			get => GetPropertyValue<string>("NOMBRE");
			set => SetPropertyValue<string>("NOMBRE", value);
		}
		[ColumnName("CODIGOX")]
		public string CODIGOX
		{
			get => GetPropertyValue<string>("CODIGOX");
			set => SetPropertyValue<string>("CODIGOX", value);
		}
		[ColumnName("LSEX")]
		public string LSEX
		{
			get => GetPropertyValue<string>("LSEX");
			set => SetPropertyValue<string>("LSEX", value);
		}
		[ColumnName("LINF")]
		public string LINF
		{
			get => GetPropertyValue<string>("LINF");
			set => SetPropertyValue<string>("LINF", value);
		}
		[ColumnName("LSUP")]
		public string LSUP
		{
			get => GetPropertyValue<string>("LSUP");
			set => SetPropertyValue<string>("LSUP", value);
		}
		[ColumnName("TRIVIAL")]
		public string TRIVIAL
		{
			get => GetPropertyValue<string>("TRIVIAL");
			set => SetPropertyValue<string>("TRIVIAL", value);
		}
		[ColumnName("ERRADICADO")]
		public string ERRADICADO
		{
			get => GetPropertyValue<string>("ERRADICADO");
			set => SetPropertyValue<string>("ERRADICADO", value);
		}
		[ColumnName("N_INTER")]
		public string N_INTER
		{
			get => GetPropertyValue<string>("N_INTER");
			set => SetPropertyValue<string>("N_INTER", value);
		}
		[ColumnName("NIN")]
		public string NIN
		{
			get => GetPropertyValue<string>("NIN");
			set => SetPropertyValue<string>("NIN", value);
		}
		[ColumnName("NINMTOBS")]
		public string NINMTOBS
		{
			get => GetPropertyValue<string>("NINMTOBS");
			set => SetPropertyValue<string>("NINMTOBS", value);
		}
		[ColumnName("COD_SIT_LESION")]
		public string COD_SIT_LESION
		{
			get => GetPropertyValue<string>("COD_SIT_LESION");
			set => SetPropertyValue<string>("COD_SIT_LESION", value);
		}
		[ColumnName("NO_CBD")]
		public string NO_CBD
		{
			get => GetPropertyValue<string>("NO_CBD");
			set => SetPropertyValue<string>("NO_CBD", value);
		}
		[ColumnName("CBD")]
		public string CBD
		{
			get => GetPropertyValue<string>("CBD");
			set => SetPropertyValue<string>("CBD", value);
		}
		[ColumnName("NO_APH")]
		public string NO_APH
		{
			get => GetPropertyValue<string>("NO_APH");
			set => SetPropertyValue<string>("NO_APH", value);
		}
		[ColumnName("AF_PRIN")]
		public string AF_PRIN
		{
			get => GetPropertyValue<string>("AF_PRIN");
			set => SetPropertyValue<string>("AF_PRIN", value);
		}
		[ColumnName("DIA_SIS")]
		public string DIA_SIS
		{
			get => GetPropertyValue<string>("DIA_SIS");
			set => SetPropertyValue<string>("DIA_SIS", value);
		}
		[ColumnName("CLAVE_PROGRAMA_SIS")]
		public string CLAVE_PROGRAMA_SIS
		{
			get => GetPropertyValue<string>("CLAVE_PROGRAMA_SIS");
			set => SetPropertyValue<string>("CLAVE_PROGRAMA_SIS", value);
		}
		[ColumnName("COD_COMPLEMEN_MORBI")]
		public string COD_COMPLEMEN_MORBI
		{
			get => GetPropertyValue<string>("COD_COMPLEMEN_MORBI");
			set => SetPropertyValue<string>("COD_COMPLEMEN_MORBI", value);
		}
		[ColumnName("DIA_FETAL")]
		public string DIA_FETAL
		{
			get => GetPropertyValue<string>("DIA_FETAL");
			set => SetPropertyValue<string>("DIA_FETAL", value);
		}
		[ColumnName("DEF_FETAL_CM")]
		public string DEF_FETAL_CM
		{
			get => GetPropertyValue<string>("DEF_FETAL_CM");
			set => SetPropertyValue<string>("DEF_FETAL_CM", value);
		}
		[ColumnName("DEF_FETAL_CBD")]
		public string DEF_FETAL_CBD
		{
			get => GetPropertyValue<string>("DEF_FETAL_CBD");
			set => SetPropertyValue<string>("DEF_FETAL_CBD", value);
		}
		[ColumnName("CLAVE_CAPITULO")]
		public string CLAVE_CAPITULO
		{
			get => GetPropertyValue<string>("CLAVE_CAPITULO");
			set => SetPropertyValue<string>("CLAVE_CAPITULO", value);
		}
		[ColumnName("CAPITULO")]
		public string CAPITULO
		{
			get => GetPropertyValue<string>("CAPITULO");
			set => SetPropertyValue<string>("CAPITULO", value);
		}
		[ColumnName("LISTA1")]
		public string LISTA1
		{
			get => GetPropertyValue<string>("LISTA1");
			set => SetPropertyValue<string>("LISTA1", value);
		}
		[ColumnName("GRUPO1")]
		public string GRUPO1
		{
			get => GetPropertyValue<string>("GRUPO1");
			set => SetPropertyValue<string>("GRUPO1", value);
		}
		[ColumnName("LISTA5")]
		public string LISTA5
		{
			get => GetPropertyValue<string>("LISTA5");
			set => SetPropertyValue<string>("LISTA5", value);
		}
		[ColumnName("RUBRICA_TYPE")]
		public string RUBRICA_TYPE
		{
			get => GetPropertyValue<string>("RUBRICA_TYPE");
			set => SetPropertyValue<string>("RUBRICA_TYPE", value);
		}
		[ColumnName("YEAR_MODIFI")]
		public string YEAR_MODIFI
		{
			get => GetPropertyValue<string>("YEAR_MODIFI");
			set => SetPropertyValue<string>("YEAR_MODIFI", value);
		}
		[ColumnName("YEAR_APLICACION")]
		public string YEAR_APLICACION
		{
			get => GetPropertyValue<string>("YEAR_APLICACION");
			set => SetPropertyValue<string>("YEAR_APLICACION", value);
		}
		[ColumnName("VALID")]
		public string VALID
		{
			get => GetPropertyValue<string>("VALID");
			set => SetPropertyValue<string>("VALID", value);
		}
		[ColumnName("PRINMORTA")]
		public string PRINMORTA
		{
			get => GetPropertyValue<string>("PRINMORTA");
			set => SetPropertyValue<string>("PRINMORTA", value);
		}
		[ColumnName("PRINMORBI")]
		public string PRINMORBI
		{
			get => GetPropertyValue<string>("PRINMORBI");
			set => SetPropertyValue<string>("PRINMORBI", value);
		}
		[ColumnName("LM_MORBI")]
		public string LM_MORBI
		{
			get => GetPropertyValue<string>("LM_MORBI");
			set => SetPropertyValue<string>("LM_MORBI", value);
		}
		[ColumnName("LM_MORTA")]
		public string LM_MORTA
		{
			get => GetPropertyValue<string>("LM_MORTA");
			set => SetPropertyValue<string>("LM_MORTA", value);
		}
		[ColumnName("LGBD165")]
		public string LGBD165
		{
			get => GetPropertyValue<string>("LGBD165");
			set => SetPropertyValue<string>("LGBD165", value);
		}
		[ColumnName("LOMSBECK")]
		public string LOMSBECK
		{
			get => GetPropertyValue<string>("LOMSBECK");
			set => SetPropertyValue<string>("LOMSBECK", value);
		}
		[ColumnName("LGBD190")]
		public string LGBD190
		{
			get => GetPropertyValue<string>("LGBD190");
			set => SetPropertyValue<string>("LGBD190", value);
		}
		[ColumnName("NOTDIARIA")]
		public string NOTDIARIA
		{
			get => GetPropertyValue<string>("NOTDIARIA");
			set => SetPropertyValue<string>("NOTDIARIA", value);
		}
		[ColumnName("NOTSEMANAL")]
		public string NOTSEMANAL
		{
			get => GetPropertyValue<string>("NOTSEMANAL");
			set => SetPropertyValue<string>("NOTSEMANAL", value);
		}
		[ColumnName("SISTEMA_ESPECIAL")]
		public string SISTEMA_ESPECIAL
		{
			get => GetPropertyValue<string>("SISTEMA_ESPECIAL");
			set => SetPropertyValue<string>("SISTEMA_ESPECIAL", value);
		}
		[ColumnName("BIRMM")]
		public string BIRMM
		{
			get => GetPropertyValue<string>("BIRMM");
			set => SetPropertyValue<string>("BIRMM", value);
		}
		[ColumnName("CVE_CAUSA_TYPE")]
		public string CVE_CAUSA_TYPE
		{
			get => GetPropertyValue<string>("CVE_CAUSA_TYPE");
			set => SetPropertyValue<string>("CVE_CAUSA_TYPE", value);
		}
		[ColumnName("CAUSA_TYPE")]
		public string CAUSA_TYPE
		{
			get => GetPropertyValue<string>("CAUSA_TYPE");
			set => SetPropertyValue<string>("CAUSA_TYPE", value);
		}
		[ColumnName("EPI_MORTA")]
		public string EPI_MORTA
		{
			get => GetPropertyValue<string>("EPI_MORTA");
			set => SetPropertyValue<string>("EPI_MORTA", value);
		}
		[ColumnName("EDAS_E_IRAS_EN_M5")]
		public string EDAS_E_IRAS_EN_M5
		{
			get => GetPropertyValue<string>("EDAS_E_IRAS_EN_M5");
			set => SetPropertyValue<string>("EDAS_E_IRAS_EN_M5", value);
		}
		[ColumnName("CVE_MATERNAS-SEED-EPID")]
		public string CVE_MATERNAS_SEED_EPID
		{
			get => GetPropertyValue<string>("CVE_MATERNAS-SEED-EPID");
			set => SetPropertyValue<string>("CVE_MATERNAS-SEED-EPID", value);
		}
		[ColumnName("EPI_MORTA_M5")]
		public string EPI_MORTA_M5
		{
			get => GetPropertyValue<string>("EPI_MORTA_M5");
			set => SetPropertyValue<string>("EPI_MORTA_M5", value);
		}
		[ColumnName("EPI_MORBI")]
		public string EPI_MORBI
		{
			get => GetPropertyValue<string>("EPI_MORBI");
			set => SetPropertyValue<string>("EPI_MORBI", value);
		}
		[ColumnName("DEF_MATERNAS")]
		public string DEF_MATERNAS
		{
			get => GetPropertyValue<string>("DEF_MATERNAS");
			set => SetPropertyValue<string>("DEF_MATERNAS", value);
		}
		[ColumnName("ES_CAUSES")]
		public string ES_CAUSES
		{
			get => GetPropertyValue<string>("ES_CAUSES");
			set => SetPropertyValue<string>("ES_CAUSES", value);
		}
		[ColumnName("NUM_CAUSES")]
		public string NUM_CAUSES
		{
			get => GetPropertyValue<string>("NUM_CAUSES");
			set => SetPropertyValue<string>("NUM_CAUSES", value);
		}
		[ColumnName("ES_SUIVE_MORTA")]
		public string ES_SUIVE_MORTA
		{
			get => GetPropertyValue<string>("ES_SUIVE_MORTA");
			set => SetPropertyValue<string>("ES_SUIVE_MORTA", value);
		}
		[ColumnName("ES_SUIVE_MORB")]
		public string ES_SUIVE_MORB
		{
			get => GetPropertyValue<string>("ES_SUIVE_MORB");
			set => SetPropertyValue<string>("ES_SUIVE_MORB", value);
		}
		[ColumnName("EPI_CLAVE")]
		public string EPI_CLAVE
		{
			get => GetPropertyValue<string>("EPI_CLAVE");
			set => SetPropertyValue<string>("EPI_CLAVE", value);
		}
		[ColumnName("EPI_CLAVE_DESC")]
		public string EPI_CLAVE_DESC
		{
			get => GetPropertyValue<string>("EPI_CLAVE_DESC");
			set => SetPropertyValue<string>("EPI_CLAVE_DESC", value);
		}
		[ColumnName("ES_SUIVE_NOTIN")]
		public string ES_SUIVE_NOTIN
		{
			get => GetPropertyValue<string>("ES_SUIVE_NOTIN");
			set => SetPropertyValue<string>("ES_SUIVE_NOTIN", value);
		}
		[ColumnName("ES_SUIVE_EST_EPI")]
		public string ES_SUIVE_EST_EPI
		{
			get => GetPropertyValue<string>("ES_SUIVE_EST_EPI");
			set => SetPropertyValue<string>("ES_SUIVE_EST_EPI", value);
		}
		[ColumnName("ES_SUIVE_EST_BROTE")]
		public string ES_SUIVE_EST_BROTE
		{
			get => GetPropertyValue<string>("ES_SUIVE_EST_BROTE");
			set => SetPropertyValue<string>("ES_SUIVE_EST_BROTE", value);
		}
		[ColumnName("SINAC")]
		public string SINAC
		{
			get => GetPropertyValue<string>("SINAC");
			set => SetPropertyValue<string>("SINAC", value);
		}
		[ColumnName("PRIN_SINAC")]
		public string PRIN_SINAC
		{
			get => GetPropertyValue<string>("PRIN_SINAC");
			set => SetPropertyValue<string>("PRIN_SINAC", value);
		}
		[ColumnName("PRIN_SINAC_GRUPO")]
		public string PRIN_SINAC_GRUPO
		{
			get => GetPropertyValue<string>("PRIN_SINAC_GRUPO");
			set => SetPropertyValue<string>("PRIN_SINAC_GRUPO", value);
		}
		[ColumnName("DESCRIPCION_SINAC_GRUPO")]
		public string DESCRIPCION_SINAC_GRUPO
		{
			get => GetPropertyValue<string>("DESCRIPCION_SINAC_GRUPO");
			set => SetPropertyValue<string>("DESCRIPCION_SINAC_GRUPO", value);
		}
		[ColumnName("PRIN_SINAC_SUBGRUPO")]
		public string PRIN_SINAC_SUBGRUPO
		{
			get => GetPropertyValue<string>("PRIN_SINAC_SUBGRUPO");
			set => SetPropertyValue<string>("PRIN_SINAC_SUBGRUPO", value);
		}
		[ColumnName("DESCRIPCION_SINAC_SUBGRUPO")]
		public string DESCRIPCION_SINAC_SUBGRUPO
		{
			get => GetPropertyValue<string>("DESCRIPCION_SINAC_SUBGRUPO");
			set => SetPropertyValue<string>("DESCRIPCION_SINAC_SUBGRUPO", value);
		}
		[ColumnName("DAGA")]
		public string DAGA
		{
			get => GetPropertyValue<string>("DAGA");
			set => SetPropertyValue<string>("DAGA", value);
		}
		[ColumnName("ASTERISCO")]
		public string ASTERISCO
		{
			get => GetPropertyValue<string>("ASTERISCO");
			set => SetPropertyValue<string>("ASTERISCO", value);
		}
		[ColumnName("PRIN_MM")]
		public string PRIN_MM
		{
			get => GetPropertyValue<string>("PRIN_MM");
			set => SetPropertyValue<string>("PRIN_MM", value);
		}
		[ColumnName("PRIN_MM_GRUPO")]
		public string PRIN_MM_GRUPO
		{
			get => GetPropertyValue<string>("PRIN_MM_GRUPO");
			set => SetPropertyValue<string>("PRIN_MM_GRUPO", value);
		}
		[ColumnName("DESCRIPCION_MM_GRUPO")]
		public string DESCRIPCION_MM_GRUPO
		{
			get => GetPropertyValue<string>("DESCRIPCION_MM_GRUPO");
			set => SetPropertyValue<string>("DESCRIPCION_MM_GRUPO", value);
		}
		[ColumnName("PRIN_MM_SUBGRUPO")]
		public string PRIN_MM_SUBGRUPO
		{
			get => GetPropertyValue<string>("PRIN_MM_SUBGRUPO");
			set => SetPropertyValue<string>("PRIN_MM_SUBGRUPO", value);
		}
		[ColumnName("DESCRIPCION_MM_SUBGRUPO")]
		public string DESCRIPCION_MM_SUBGRUPO
		{
			get => GetPropertyValue<string>("DESCRIPCION_MM_SUBGRUPO");
			set => SetPropertyValue<string>("DESCRIPCION_MM_SUBGRUPO", value);
		}
		[ColumnName("COD_ADI_MORT")]
		public string COD_ADI_MORT
		{
			get => GetPropertyValue<string>("COD_ADI_MORT");
			set => SetPropertyValue<string>("COD_ADI_MORT", value);
		}
		#endregion
		#region Funciones
		/// <summary>
		/// Load row of the Diagnostics.		/// </summary>
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
			Properties = new Dictionary<string, Property>(75);

			 AddKeyField("Id",null);
			 AddProperty<long>("Id", new PropertyValue<long> {
			 Value = default,
			 IsPrimaryKey = true,
			 Length = 8,
			 Precision = 19,
			 IsRequiredInDataBase = true,
			 FieldId = 0,
			 Description = "No description Id",
			 IsIdentity = false,
			 DataType = typeof(long)
			});
			 AddProperty<string>("LETRA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 1,
			 Description = "No description LETRA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CATALOG_KEY", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 2,
			 Description = "No description CATALOG_KEY",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NOMBRE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 3,
			 Description = "No description NOMBRE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CODIGOX", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 4,
			 Description = "No description CODIGOX",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LSEX", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 5,
			 Description = "No description LSEX",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LINF", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 6,
			 Description = "No description LINF",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LSUP", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 7,
			 Description = "No description LSUP",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("TRIVIAL", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 8,
			 Description = "No description TRIVIAL",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ERRADICADO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 9,
			 Description = "No description ERRADICADO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("N_INTER", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 10,
			 Description = "No description N_INTER",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NIN", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 11,
			 Description = "No description NIN",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NINMTOBS", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 12,
			 Description = "No description NINMTOBS",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("COD_SIT_LESION", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 13,
			 Description = "No description COD_SIT_LESION",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NO_CBD", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 14,
			 Description = "No description NO_CBD",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CBD", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 15,
			 Description = "No description CBD",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NO_APH", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 16,
			 Description = "No description NO_APH",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("AF_PRIN", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 17,
			 Description = "No description AF_PRIN",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DIA_SIS", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 18,
			 Description = "No description DIA_SIS",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CLAVE_PROGRAMA_SIS", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 19,
			 Description = "No description CLAVE_PROGRAMA_SIS",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("COD_COMPLEMEN_MORBI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 20,
			 Description = "No description COD_COMPLEMEN_MORBI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DIA_FETAL", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 21,
			 Description = "No description DIA_FETAL",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DEF_FETAL_CM", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 22,
			 Description = "No description DEF_FETAL_CM",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DEF_FETAL_CBD", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 23,
			 Description = "No description DEF_FETAL_CBD",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CLAVE_CAPITULO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 24,
			 Description = "No description CLAVE_CAPITULO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CAPITULO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 25,
			 Description = "No description CAPITULO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LISTA1", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 26,
			 Description = "No description LISTA1",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("GRUPO1", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 27,
			 Description = "No description GRUPO1",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LISTA5", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 28,
			 Description = "No description LISTA5",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("RUBRICA_TYPE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 29,
			 Description = "No description RUBRICA_TYPE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("YEAR_MODIFI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 30,
			 Description = "No description YEAR_MODIFI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("YEAR_APLICACION", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 31,
			 Description = "No description YEAR_APLICACION",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("VALID", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 32,
			 Description = "No description VALID",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRINMORTA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 33,
			 Description = "No description PRINMORTA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRINMORBI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 34,
			 Description = "No description PRINMORBI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LM_MORBI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 35,
			 Description = "No description LM_MORBI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LM_MORTA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 36,
			 Description = "No description LM_MORTA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LGBD165", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 37,
			 Description = "No description LGBD165",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LOMSBECK", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 38,
			 Description = "No description LOMSBECK",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("LGBD190", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 39,
			 Description = "No description LGBD190",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NOTDIARIA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 40,
			 Description = "No description NOTDIARIA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NOTSEMANAL", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 41,
			 Description = "No description NOTSEMANAL",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SISTEMA_ESPECIAL", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 42,
			 Description = "No description SISTEMA_ESPECIAL",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("BIRMM", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 43,
			 Description = "No description BIRMM",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CVE_CAUSA_TYPE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 44,
			 Description = "No description CVE_CAUSA_TYPE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CAUSA_TYPE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 45,
			 Description = "No description CAUSA_TYPE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EPI_MORTA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 46,
			 Description = "No description EPI_MORTA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EDAS_E_IRAS_EN_M5", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 47,
			 Description = "No description EDAS_E_IRAS_EN_M5",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("CVE_MATERNAS-SEED-EPID", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 48,
			 Description = "No description CVE_MATERNAS-SEED-EPID",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EPI_MORTA_M5", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 49,
			 Description = "No description EPI_MORTA_M5",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EPI_MORBI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 50,
			 Description = "No description EPI_MORBI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DEF_MATERNAS", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 51,
			 Description = "No description DEF_MATERNAS",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_CAUSES", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 52,
			 Description = "No description ES_CAUSES",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("NUM_CAUSES", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 53,
			 Description = "No description NUM_CAUSES",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_SUIVE_MORTA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 54,
			 Description = "No description ES_SUIVE_MORTA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_SUIVE_MORB", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 55,
			 Description = "No description ES_SUIVE_MORB",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EPI_CLAVE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 56,
			 Description = "No description EPI_CLAVE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("EPI_CLAVE_DESC", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 57,
			 Description = "No description EPI_CLAVE_DESC",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_SUIVE_NOTIN", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 58,
			 Description = "No description ES_SUIVE_NOTIN",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_SUIVE_EST_EPI", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 59,
			 Description = "No description ES_SUIVE_EST_EPI",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ES_SUIVE_EST_BROTE", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 60,
			 Description = "No description ES_SUIVE_EST_BROTE",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("SINAC", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 61,
			 Description = "No description SINAC",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_SINAC", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 62,
			 Description = "No description PRIN_SINAC",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_SINAC_GRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 63,
			 Description = "No description PRIN_SINAC_GRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DESCRIPCION_SINAC_GRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 64,
			 Description = "No description DESCRIPCION_SINAC_GRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_SINAC_SUBGRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 65,
			 Description = "No description PRIN_SINAC_SUBGRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DESCRIPCION_SINAC_SUBGRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 66,
			 Description = "No description DESCRIPCION_SINAC_SUBGRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DAGA", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 67,
			 Description = "No description DAGA",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("ASTERISCO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 68,
			 Description = "No description ASTERISCO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_MM", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 69,
			 Description = "No description PRIN_MM",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_MM_GRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 70,
			 Description = "No description PRIN_MM_GRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DESCRIPCION_MM_GRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 71,
			 Description = "No description DESCRIPCION_MM_GRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("PRIN_MM_SUBGRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 72,
			 Description = "No description PRIN_MM_SUBGRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("DESCRIPCION_MM_SUBGRUPO", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 73,
			 Description = "No description DESCRIPCION_MM_SUBGRUPO",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			 AddProperty<string>("COD_ADI_MORT", new PropertyValue<string> {
			 Value = String.Empty,
			 IsPrimaryKey = false,
			 Length = 510,
			 Precision = 0,
			 IsRequiredInDataBase = false,
			 FieldId = 74,
			 Description = "No description COD_ADI_MORT",
			 IsIdentity = false,
			 DataType = typeof(string)
			});
			}
			#endregion

		}
	}
