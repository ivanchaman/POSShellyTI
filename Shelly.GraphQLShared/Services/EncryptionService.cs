namespace Shelly.GraphQLShared.Services
{
    public class EncryptionService : IEncryptionService
    {
        private AppSettings _Options;

        public EncryptionService(AppSettings options)
        {
            _Options = options;
        }

        public string DecodedRSA1024(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                    return "";
                PemReader pr = new PemReader(new StringReader(_Options.Privatekey));
                AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();
                RsaKeyParameters privateKey = (RsaKeyParameters)keys.Private;
                var cipher = new Pkcs1Encoding(new RsaEngine());
                cipher.Init(false, privateKey);
                byte[] ciphered = Convert.FromBase64String(content);
                byte[] deciphered = cipher.ProcessBlock(ciphered, 0, ciphered.Length);
                var pass = Encoding.UTF8.GetString(deciphered);
                return pass;
            }
            catch
            {
                return "";
            }
        }

        public string EncryptedRSA1024(string content)
        {
            try
            {
                PemReader pr = new PemReader(new StringReader(_Options.PublicKey));
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
