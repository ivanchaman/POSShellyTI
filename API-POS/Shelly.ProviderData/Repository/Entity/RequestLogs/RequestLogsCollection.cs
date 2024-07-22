using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;

namespace Shelly.ProviderData.Repository.Entity
{
	public partial class RequestLogsCollection:StaticEntityCollection<RequestLogs>
	{
		#region variables
		#endregion
		#region Propiedades
		#endregion
		#region Contructor
		/// <summary>
		/// Initializes a new instance of the xsRequestLogsCollection.
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public RequestLogsCollection(IBaseSystem IBaseSystem):base(IBaseSystem)
		{
		}
		#endregion
		#region Metodos Funciones
		#endregion

		}
	}
