namespace Shelly.Abstractions.Model
{
     public class CardSettings
     {
          public int Id { get; set; }

          public int Environment { get; set; }
          public string Endpoint { get; set; }
          public string CardArrayHashId { get; set; }
          public string CardArrayName { get; set; }
          public string ClientUrl { get; set; }
          public string UserName { get; set; }
          public string Password { get; set; }
          public string EncryptedUserName { get; set; }
          public string EncryptedPassword { get; set; }
          public string EncryptedPublicKey { get; set; }
          public string ProgramHashId { get; set; }
          public string ProgramName { get; set; }
          public string CardArrayHashIdVirtual { get; set; }
          public string CardArrayNameVirtual { get; set; }

     }
}
