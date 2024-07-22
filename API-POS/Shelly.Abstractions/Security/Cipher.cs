using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System.Text;

namespace Shelly.Abstractions.Security
{
     public class Cipher
     {
          private const string _CipherNetWorkPublicKey = @"-----BEGIN PUBLIC KEY-----
     MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDpxbABeFGU4yFoJpxw3lZ3Vjxr
     4mncyfD1YYpa0cyCH+TcGkE4PXyTU6btn2WkwQkkXPIVKR7lIZi/0W4ldfQ8yG/a
     ypMsq7WZyXXFcwiDAlVx4E7D4Ck2xKaHvVMoir9Hnga8f5e0rEOt66kWFSBdsrGe
     hU+vdLzYAuOeicJhywIDAQAB
     -----END PUBLIC KEY----";

          private const string _CipherNetWorkPrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
     MIICXQIBAAKBgQDpxbABeFGU4yFoJpxw3lZ3Vjxr4mncyfD1YYpa0cyCH+TcGkE4
     PXyTU6btn2WkwQkkXPIVKR7lIZi/0W4ldfQ8yG/aypMsq7WZyXXFcwiDAlVx4E7D
     4Ck2xKaHvVMoir9Hnga8f5e0rEOt66kWFSBdsrGehU+vdLzYAuOeicJhywIDAQAB
     AoGBAKFCFR9ueBhUdX7643+YX90CR7vD+3KqeuVJ2766anB4v8507fh1sbGPSt8v
     zVXRMxU6aGPgccdtXYk0Vt7QdyEFQLq6oFTs+aZ45MQTCy9w976n1VoH1W+Gd9E5
     uOIhKcD/uHiD34Tx6dkJHjSl9sTxVi8S/OLMXm1ZnQus+LOBAkEA9YU/T8GPNwt6
     EnVRY/ySm8LGLbGmYM3DHw5RfIEDtj5+lmilfjptSMLYlNkzO0a15GX5jHu6CNOP
     TEhO/DfbUwJBAPPAEbK/xMr47enyp0vM6QnMtE6zZKMacomaEi8vwr2DWvAwL8LB
     2BMCSflnenPEHudIycAWeWDZx/cxgFTYCKkCQBiH26+IU1rYlrXJavxme+98Injm
     Sw1ZAanUsGeULF7FF7jHc+GMzOZ8MU+N9AR0KDBN0AUtR4UiPisM/ndMzWkCQCHG
     Vm13RxR847KMDgRh01SpSb6x+tri2kYY1DY3nvtVjS9E7glFhOQ1Z/yoCv6piUKx
     AkuckZsK8jtdX5PiD2kCQQDN/PzrtLpeDbUGhiB0fqLNJ+hQsohj+il/mLXZKESh
     uheKXW3/UjVy1I4RpMcPO7bFiv7DpTsNYd5z7VqWp/YA
     -----END RSA PRIVATE KEY-----";




          private const string _CipherDatabasePublicKey = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDORbt7S0B5KK5yk6mkwXRHetbU
1lJzycei5C+qmhUI+rTGcT5KAecLzSA0mxGO2jDMmI1Z/jaZN40kOQK2dSe23Nm5
rEaTP+bMazFj3EvTZWV2QrnisidtC+hPoVRWTau0rw+kalMQl7jolcGeAFc7bKQP
/zbLnpB1JcSb+rk9NQIDAQAB
-----END PUBLIC KEY-----";
          private const string _CipherDatabasePrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICXQIBAAKBgQDORbt7S0B5KK5yk6mkwXRHetbU1lJzycei5C+qmhUI+rTGcT5K
AecLzSA0mxGO2jDMmI1Z/jaZN40kOQK2dSe23Nm5rEaTP+bMazFj3EvTZWV2Qrni
sidtC+hPoVRWTau0rw+kalMQl7jolcGeAFc7bKQP/zbLnpB1JcSb+rk9NQIDAQAB
AoGAXMX4QMfjw5qMe3P2hOeNiOiy3x9WDkXeyGChH7YVZ+h6jhY40chxRlmH9qEY
EIwKDrs+OA+iNt9JV9VcZvviVAmnmchSwgyfoEbTVtRxzYAl+Z7wS8mCeokAK3vJ
JxDVn5dIwCSDKarARCROnZ1En8iFmpw4zAcufa292QGr+QECQQDw+kKuBNjJAfPh
LFVzol3vdNWShj0er1dClyjWUA6+Xen2K+kl7nm/4gdSX+ys/DZX8bV4wtZnk6XW
vdylCMdlAkEA2yGdaptEj9KiW6Uf2aqE1WkObKZ5VhBH/Yrrj76ZzqEPbikcznTL
P9Wjj0yxZWamDoA7LHsugF8d7HAgBUrJkQJBAIDcAm4Vz2rlbWlakLNN/tc+bbp1
qBdRgeLs+/xmQQwRIjvuTTVoaZhvIKUvAFucXt72NKlH3ujyLjs/uc5SfHUCQQDO
JC1GIJK7CdeahxgTWApmCNJ8+46hm+ddaNZ4/0EJ1RIC+8IRpmWdw4h+QhOP5KTK
d28zRR5VvSUVS9WTpOtBAkAAiSIi2zbzrwYnGhX6M3+U3TTKm7uyNc2Ugay6MsMT
FrntXmDQu4Da4P+zKFSl0hO9l/3kW6wCUC99a0T/ro0F
-----END RSA PRIVATE KEY-----";
          public static string DecryptPEMNetWork(string encrypted)
          {
               return DecryptPEM1024(encrypted, _CipherNetWorkPrivateKey);
          }
          public static string EncryptPEMNetWork(string encrypted)
          {
               return EncryptPEM1024(encrypted, _CipherNetWorkPublicKey);
          }
          public static string DecryptPEMDataBase(string encrypted)
          {
               return DecryptPEM1024(encrypted, _CipherDatabasePrivateKey);
          }
          public static string EncryptPEMDataBase(string encrypted)
          {
               return EncryptPEM1024(encrypted, _CipherDatabasePublicKey);
          }
          private static string DecryptPEM1024(string encrypted, string privatekey)
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

          private static string EncryptPEM1024(string content, string publickey)
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
          public static bool BCryptVerify(string submittedPassword, string hashedPassword)
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
          public static string BCryptHashPassword(string submittedPassword)
          {
               if (string.IsNullOrEmpty(submittedPassword))
                    return "";
               return BCrypt.Net.BCrypt.HashPassword(submittedPassword, 12);
          }
     }
}
