﻿using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;

namespace Shelly.ProviderData.Repository.Entity
{
	public partial class TransactionsQueueCollection:StaticEntityCollection<TransactionsQueue>
	{
		#region variables
		#endregion
		#region Propiedades
		#endregion
		#region Contructor
		/// <summary>
		/// Initializes a new instance of the xsTransactionsQueueCollection.
		/// </summary>
		/// <param name="IBaseSystem">base system</param>
		public TransactionsQueueCollection(IBaseSystem IBaseSystem):base(IBaseSystem)
		{
		}
		#endregion
		#region Metodos Funciones
		#endregion

		}
	}
