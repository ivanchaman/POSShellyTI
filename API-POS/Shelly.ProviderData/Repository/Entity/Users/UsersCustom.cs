using Shelly.Abstractions.Constants;
using System.Security.AccessControl;

namespace Shelly.ProviderData.Repository.Entity
{
     /// <summary>
     /// Class Users 
     /// </summary>
     public partial class Users
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

		public void Valildations()
		{
		}

		public void ValildationsDelete()
		{
		}

		#endregion
		public bool HasTwoFactor()
		{
			return false;
		}
		public void DeleteRegisterDeleteUsers()
		{
               UsersDeletes usersDeletes = new UsersDeletes(_System);
			usersDeletes.Load(Id);
			if (usersDeletes.EOF)
				return;
			usersDeletes.Delete();
          }
          public void SetUserName(string userName)
          {
               if (String.IsNullOrEmpty(userName))
                    throw new CoreException(Errors.E00000353);  			
               this.Load(x=>x.UserName == userName);
               if (!EOF)
                    throw new CoreException(Errors.E00000353);
               Load(_System.Session.User.Number);
               UserName = userName;
               Save();
          }
          public void SetUpdateTemporaryPassword(string pwd)
          {
               if (String.IsNullOrEmpty(pwd))
                    throw new CoreException(Errors.E00000353);              
               Load(_System.Session.User.Number);
               Password = pwd;
			Status = (int)UserStatusType.ACTIVE;
               Save();
          }
          public void SetUpdatePassword(string pwd)
          {
               if (String.IsNullOrEmpty(pwd))
                    throw new CoreException(Errors.E00000353);
               Load(_System.Session.User.Number);
               Password = pwd;               
               Save();
          }
          public void SetDeleteAccount()
          {
               Load(_System.Session.User.Number);               
               Status = (int)UserStatusType.DELETEPENDING;
               Save();
			UsersDeletes delete = new UsersDeletes(_System);
			delete.Load(_System.Session.User.Number);
			if (delete.EOF)
			{
				delete.New();
				delete.UserNumber = _System.Session.User.Number;				
               }
               delete.CreatedAt = DateTime.Now;
               delete.Save();
          }

		public void Add(NewUser data)
		{
			try
			{
				ConnectionHandler.BeginTransaction();
				New();
				Id = 0;
				Uuid = ExtensionStrings.GetNewIdForMongo();
				UserName = data.UserName;
				Email = data.Email;
				Password = data.Password;
				PhoneCode = $"{data.PhoneCode}";
				PhoneNumber = data.PhoneNumber;
				Status = (int)UserStatusType.ACTIVE;
				UserTypeId = data.Type;
				CreatedAt = DateTime.Now;
				Save();

				UsersAccounts accounts = new UsersAccounts(_System);
				accounts.New();
				accounts.UserNumber = Id;
				accounts.FirstName = data.FirstName;
				accounts.LastName = data.LastName;
				accounts.MiddleName = "";
				accounts.SecondLastName = "";
				accounts.Nationality = 484;
				accounts.Birthday = new DateTime(1900,1,1);
				accounts.CreatedAt = DateTime.Now;
                    accounts.Save();

				CompaniesUsers company = new CompaniesUsers(_System);
				company.New();
				company.UserNumber = Id;
				company.Company = data.Company;
				company.CurrencyCode = $"484";
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
