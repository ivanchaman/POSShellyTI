namespace Shelly.ProviderData.Repository.Entity
{
     /// <summary>
     /// Class xsCatalogsDetail 
     /// </summary>
     public partial class CatalogsDetail
	{
		#region Variables
		#endregion
		#region Properties
		#endregion
		#region Builders
		#endregion
		#region Virtual Methods
		#region Prewrite validations
		/// <summary>
		/// Funcion para personal la validacion para un nuevo registro
		/// </summary>
		protected override void CustomValidationForNewRegister()
		{
		
		}
		/// <summary>
		/// Funcion pra personalizar el grabar en una los registros
		/// </summary>
		protected override void CustomValidationForNewPreWriteRegister()
		{
		       Valildations();
		}
		/// <summary>
		/// Funcion para personalr para grabar los cambios en los registros
		/// </summary>
		protected override void CustomValidationForPreWriteChanges()
		{
		       Valildations();
		}
		/// <summary>
		/// Funcion que valida los campos antes de eleimnar n registro
		/// </summary>
		protected override void CustomValidationForDeletePreWrite()
		{
		       ValildationsDelete();
		}
		/// <summary>
		/// Loads the new custom values.
		/// </summary>
		protected override void LoadNewCustomValues()
		{
		
		}
		#endregion Prewrite validations
		#region Postwrite
		/// <summary>
		/// Funcion pra personalizar el grabar en una los registros
		/// </summary>
		protected override void CustomValidationForPostWrite()
		{
		
		}
		/// <summary>
		/// Funcion para personalr para grabar los cambios en los registros
		/// </summary>
		protected override void CustomValidationForPosWriteChanges()
		{
		
		}
		/// <summary>
		/// Funcion que valida los campos antes de eleimnar n registro
		/// </summary>
		protected override void CustomValidationForDeletePostWrite()
		{
		
		}
		#endregion Post write
		#endregion
		#region Functions

		public void Valildations()		{
		}

		public void ValildationsDelete()		{
		}

		#endregion

		}
	}
