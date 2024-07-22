using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;

namespace Shelly.ProviderData.Repository.Entity
{
	public partial class UsersAccessCollection:StaticEntityCollection<UsersAccess>
	{
		#region variables
		#endregion
		#region Propiedades
		#endregion
		#region Contructor
		/// <summary>
		/// Initializes a new instance of the UsersAccessCollection.
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public UsersAccessCollection(IBaseSystem IBaseSystem):base(IBaseSystem)
		{
		}
		#endregion
		#region Metodos Funciones
		#endregion

		}
	}
