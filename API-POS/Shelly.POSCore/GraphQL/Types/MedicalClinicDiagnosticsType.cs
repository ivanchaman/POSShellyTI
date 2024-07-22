
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicDiagnosticsType : ObjectGraphType<Diagnostics>	{

	public MedicalClinicDiagnosticsType()
	{

		Name = "MedicalClinicDiagnosticsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.LETRA);
			Field(f => f.CATALOG_KEY);
			Field(f => f.NOMBRE);
			Field(f => f.CODIGOX);
			Field(f => f.LSEX);
			Field(f => f.LINF);
			Field(f => f.LSUP);
			Field(f => f.TRIVIAL);
			Field(f => f.ERRADICADO);
			Field(f => f.N_INTER);
			Field(f => f.NIN);
			Field(f => f.NINMTOBS);
			Field(f => f.COD_SIT_LESION);
			Field(f => f.NO_CBD);
			Field(f => f.CBD);
			Field(f => f.NO_APH);
			Field(f => f.AF_PRIN);
			Field(f => f.DIA_SIS);
			Field(f => f.CLAVE_PROGRAMA_SIS);
			Field(f => f.COD_COMPLEMEN_MORBI);
			Field(f => f.DIA_FETAL);
			Field(f => f.DEF_FETAL_CM);
			Field(f => f.DEF_FETAL_CBD);
			Field(f => f.CLAVE_CAPITULO);
			Field(f => f.CAPITULO);
			Field(f => f.LISTA1);
			Field(f => f.GRUPO1);
			Field(f => f.LISTA5);
			Field(f => f.RUBRICA_TYPE);
			Field(f => f.YEAR_MODIFI);
			Field(f => f.YEAR_APLICACION);
			Field(f => f.VALID);
			Field(f => f.PRINMORTA);
			Field(f => f.PRINMORBI);
			Field(f => f.LM_MORBI);
			Field(f => f.LM_MORTA);
			Field(f => f.LGBD165);
			Field(f => f.LOMSBECK);
			Field(f => f.LGBD190);
			Field(f => f.NOTDIARIA);
			Field(f => f.NOTSEMANAL);
			Field(f => f.SISTEMA_ESPECIAL);
			Field(f => f.BIRMM);
			Field(f => f.CVE_CAUSA_TYPE);
			Field(f => f.CAUSA_TYPE);
			Field(f => f.EPI_MORTA);
			Field(f => f.EDAS_E_IRAS_EN_M5);
			Field(f => f.CVE_MATERNAS_SEED_EPID);
			Field(f => f.EPI_MORTA_M5);
			Field(f => f.EPI_MORBI);
			Field(f => f.DEF_MATERNAS);
			Field(f => f.ES_CAUSES);
			Field(f => f.NUM_CAUSES);
			Field(f => f.ES_SUIVE_MORTA);
			Field(f => f.ES_SUIVE_MORB);
			Field(f => f.EPI_CLAVE);
			Field(f => f.EPI_CLAVE_DESC);
			Field(f => f.ES_SUIVE_NOTIN);
			Field(f => f.ES_SUIVE_EST_EPI);
			Field(f => f.ES_SUIVE_EST_BROTE);
			Field(f => f.SINAC);
			Field(f => f.PRIN_SINAC);
			Field(f => f.PRIN_SINAC_GRUPO);
			Field(f => f.DESCRIPCION_SINAC_GRUPO);
			Field(f => f.PRIN_SINAC_SUBGRUPO);
			Field(f => f.DESCRIPCION_SINAC_SUBGRUPO);
			Field(f => f.DAGA);
			Field(f => f.ASTERISCO);
			Field(f => f.PRIN_MM);
			Field(f => f.PRIN_MM_GRUPO);
			Field(f => f.DESCRIPCION_MM_GRUPO);
			Field(f => f.PRIN_MM_SUBGRUPO);
			Field(f => f.DESCRIPCION_MM_SUBGRUPO);
			Field(f => f.COD_ADI_MORT);
		#endregion

	}
	}
}
