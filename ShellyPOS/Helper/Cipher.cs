using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace ShellyPOS.Helper
{
    public static class Cipher
    {
        private const string _CipherNetWorkPublicKey = @"-----BEGIN PUBLIC KEY-----
     MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDpxbABeFGU4yFoJpxw3lZ3Vjxr
     4mncyfD1YYpa0cyCH+TcGkE4PXyTU6btn2WkwQkkXPIVKR7lIZi/0W4ldfQ8yG/a
     ypMsq7WZyXXFcwiDAlVx4E7D4Ck2xKaHvVMoir9Hnga8f5e0rEOt66kWFSBdsrGe
     hU+vdLzYAuOeicJhywIDAQAB
     -----END PUBLIC KEY----";
        public static string EncryptPEMNetWork(string encrypted)
        {
            return EncryptPEM1024(encrypted, _CipherNetWorkPublicKey);
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
    }
}
