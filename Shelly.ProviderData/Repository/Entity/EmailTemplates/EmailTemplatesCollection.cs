using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;

namespace Shelly.ProviderData.Repository.Entity
{
	public partial class EmailTemplatesCollection:StaticEntityCollection<EmailTemplates>
	{
		#region variables
		#endregion
		#region Propiedades
		#endregion
		#region Contructor
		/// <summary>
		/// Initializes a new instance of the xsEmailTemplatesCollection.
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public EmailTemplatesCollection(IBaseSystem IBaseSystem):base(IBaseSystem)
		{
		}
		#endregion
		#region Metodos Funciones
		#endregion

		}
	}
