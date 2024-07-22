namespace Shelly.ProviderData.Repository.Entity
{
     /// <summary>
     /// Class Companies 
     /// </summary>
     public partial class Companies
	{
		#region Variables
		#endregion
		#region Properties
		public List<DictionaryValue>? DataVersion { get; set; }
		public double Version { get; set; }
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

		public void Valildations()
		{
		}

		public void ValildationsDelete()
		{
		}

		#endregion
		public void Add(NewCompany data)
		{
			try
			{
				ConnectionHandler.BeginTransaction();
				Shelly.Abstractions.Helpers.Password random = new Shelly.Abstractions.Helpers.Password(false, true, true, false, 10);
				New();
				Id = 0;
				ExternalId = random.Next();
				DisplayName = data.Name;
				Email = data.Email;
                    AvatarImageId = 0;
				PhoneCode = $"{data.PhoneCode}";
				PhoneNumber = data.PhoneNumber;
				Status = (int)UserStatusType.ACTIVE;
				CreatedAt = DateTime.Now;
				CountryCode = 484;
				Save();

				CompaniesUsers company = new CompaniesUsers(_System);
				company.New();
				company.UserNumber = 0;
				company.Company = Id;
				company.CurrencyCode = "484";
				company.Save();
				ConnectionHandler.CommitTransaction();
			}
			catch
			{
				ConnectionHandler.RollbackTransaction();
				throw;
			}
		}
	}
}
