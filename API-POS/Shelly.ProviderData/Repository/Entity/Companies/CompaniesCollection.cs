using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;

namespace Shelly.ProviderData.Repository.Entity
{
	public partial class CompaniesCollection:StaticEntityCollection<Companies>
	{
		#region variables
		#endregion
		#region Propiedades
		#endregion
		#region Contructor
		/// <summary>
		/// Initializes a new instance of the CompaniesCollection.
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public CompaniesCollection(IBaseSystem IBaseSystem):base(IBaseSystem)
		{
		}
		#endregion
		#region Metodos Funciones
		#endregion

		}
	}
