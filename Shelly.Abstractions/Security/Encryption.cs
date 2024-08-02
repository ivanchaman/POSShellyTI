using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System.Text;

namespace Shelly.Abstractions.Security
{
     public class Encryption
     {        

          private string _PublicKey;
          private string _PrivateKey;

          public Encryption()
          {               
          }
          public Encryption(string publicKey, string privateKey)
          {
               _PublicKey = publicKey;
               _PrivateKey = privateKey;
          }
        
          public string DecodedPEMDataBase(string encrypted)
          {
               return DecodedPEM1024(encrypted, _PrivateKey);
          }
          public string EncryptedPEMDataBase(string encrypted)
          {
               return EncryptedPEM1024(encrypted, _PublicKey);
          }
          private string DecodedPEM1024(string encrypted, string privatekey)
          {
               try
               {
                    if (string.IsNullOrEmpty(encrypted))
                         return "";
                    PemReader pr = new PemReader(new StringReader(privatekey));
                    AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();
                    RsaKeyParameters privateKey = (RsaKeyParameters)keys.Private;
                    var cipher = new Pkcs1Encoding(new RsaEngine());
                    cipher.Init(false, privateKey);
                    byte[] ciphered = Convert.FromBase64String(encrypted);
                    byte[] deciphered = cipher.ProcessBlock(ciphered, 0, ciphered.Length);
                    var pass = Encoding.UTF8.GetString(deciphered);
                    return pass;
               }
               catch
               {
                    return "";
               }
          }

          private string EncryptedPEM1024(string content, string publickey)
          {
               try
               {
                    PemReader pr = new PemReader(new StringReader(publickey));
                    RsaKeyParameters publicKey = (RsaKeyParameters)pr.ReadObject();
                    IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());
                    cipher.Init(true, publicKey);
                    var bytesToEncrypt = Encoding.UTF8.GetBytes(content);
                    var encrypted = cipher.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    var cryptMessage = Convert.ToBase64String(encrypted);
                    return cryptMessage;
               }
               catch
               {
                    return "";
               }
          }
          public bool BCryptVerify(string submittedPassword, string hashedPassword)
          {

               if (String.IsNullOrEmpty(submittedPassword) || string.IsNullOrEmpty(hashedPassword))
                    return false;
               try
               {
                    return BCrypt.Net.BCrypt.Verify(submittedPassword, hashedPassword);
               }
               catch
               {
                    return false;
               }
          }
          public string BCryptHashPassword(string submittedPassword)
          {
               if (string.IsNullOrEmpty(submittedPassword))
                    return "";
               return BCrypt.Net.BCrypt.HashPassword(submittedPassword, 12);
          }
     }
}
