namespace BlazorShop.WebApi.Services
{
    public class EncryptionService : IEncryptionService
    {
        private const string? CipherText = "cipherText";
        private const string? PlainText = "PlainText";
        private const string? KeyParam = "key";
        private const string? IvParam = "iv";

        private readonly IConfiguration _configuration;
        private readonly string? keyString;
        private readonly string? ivString;

        public EncryptionService(IConfiguration configuration)
        {
            _configuration = configuration;
            keyString = _configuration["Cryptography:Key"];
            ivString = _configuration["Cryptography:Iv"];
        }

        public string? DecryptData(string? cipherText)
        {
            try
            {
                var encrypted = Convert.FromBase64String(cipherText);
                var key = Encoding.UTF8.GetBytes(keyString);
                var iv = Encoding.UTF8.GetBytes(ivString);

                if (encrypted == null || encrypted.Length <= 0)
                {
                    throw new ArgumentNullException(CipherText);
                }
                if (key == null || key.Length <= 0)
                {
                    throw new ArgumentNullException(KeyParam);
                }
                if (iv == null || iv.Length <= 0)
                {
                    throw new ArgumentNullException(IvParam);
                }
                string? plaintext = null;

                using (var rijAlg = new RijndaelManaged())
                {
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    rijAlg.Key = key;
                    rijAlg.IV = iv;

                    var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    try
                    {
                        using var msDecrypt = new MemoryStream(encrypted);
                        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                        using var srDecrypt = new StreamReader(csDecrypt);
                        plaintext = srDecrypt.ReadToEnd();
                    }
                    catch
                    {
                        plaintext = "keyError";
                    }
                }
                return plaintext;
            }
            catch (Exception)
            {
                throw new Exception("Invalid data");
            }
        }

        public byte[] EncryptData(string? plainText)
        {
            var key = Encoding.UTF8.GetBytes(keyString);
            var iv = Encoding.UTF8.GetBytes(ivString);

            try
            {
                if (plainText == null || plainText.Length <= 0)
                {
                    throw new ArgumentNullException(PlainText);
                }
                if (key == null || key.Length <= 0)
                {
                    throw new ArgumentNullException(KeyParam);
                }
                if (iv == null || iv.Length <= 0)
                {
                    throw new ArgumentNullException(IvParam);
                }

                byte[] encrypted;
                using (var rijAlg = new RijndaelManaged())
                {
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    rijAlg.Key = key;
                    rijAlg.IV = iv;

                    var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                    using var msEncrypt = new MemoryStream();
                    using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
                return encrypted;
            }
            catch (Exception)
            {
                throw new Exception("Invalid data");
            }
        }
    }
}
