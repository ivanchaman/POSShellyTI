using Shelly.ProviderData.GenericRepository;
using Shelly.Abstractions.Settings;
using System.Text.RegularExpressions;
using Shelly.Abstractions.Constants;

namespace Shelly.ProviderData.Repository.Entity
{
	/// <summary>
	/// Class UsersAccounts 
	/// </summary>
	public partial class UsersAccounts
	{
		#region Variables
		#endregion
		#region Properties
		public Users User { get; set; }
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
			CreatedAt = DateTime.Now;
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

		public void Valildations()
		{
               if (Birthday == default)
                    Birthday = DefaultDateTime;
               if (Gender == 0)
                    Gender = (int)GenderType.Unknown;
               if (string.IsNullOrEmpty(FirstName))
                    throw new CoreException(Errors.E00000031);
               if (string.IsNullOrEmpty(LastName))
                    throw new CoreException(Errors.E00000032);
               string allowedCharacters = _System.GetParameter<string>("AllowedCharacters");
               if (!string.IsNullOrEmpty(allowedCharacters))
               {
                    string regExPatron = $"[^{allowedCharacters.Trim()}]+";
                    FirstName = FirstName.Trim();
                    LastName = LastName.Trim();
                    if (Regex.IsMatch(FirstName, regExPatron))
                         throw new CoreException(Errors.E00000290);
                    if (Regex.IsMatch(LastName, regExPatron))
                         throw new CoreException(Errors.E00000291);
               }               
               double totalDays = (DateTime.Now - Birthday).TotalDays;
               if (totalDays < _System.GetParameter<int>("AdultAge"))
               {
                    throw new CoreException(Errors.E00000317);
               }              
          }

		public void ValildationsDelete()
		{
		}

		#endregion

	}
}
