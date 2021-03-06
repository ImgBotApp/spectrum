namespace Spectrum.Content.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class EncryptionService : IEncryptionService
    {
        /// <summary>
        /// The random.
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// The rm
        /// </summary>
        private readonly RijndaelManaged rm;
        
        /// <summary>
        /// The encoder.
        /// </summary>
        private readonly UTF8Encoding encoder;
        
        /// <summary>
        /// The encryptionKey.
        /// </summary>
        private byte[] encryptionKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptionService"/> class.
        /// </summary>
        public EncryptionService()
        {
            random = new Random();
            rm = new RijndaelManaged();
            encoder = new UTF8Encoding();
            encryptionKey = Convert.FromBase64String("ABCD+123456+qsw987+0987654321+Abd+s234+1q93=");
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt.</param>
        /// <returns></returns>
        public string EncryptString(string textToEncrypt)
        {
            byte[] vector = new byte[16];
            random.NextBytes(vector);
            IEnumerable<byte> cryptogram = vector.Concat(Encrypt(encoder.GetBytes(textToEncrypt), vector));
            return Convert.ToBase64String(cryptogram.ToArray());
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt.</param>
        /// <param name="key">The encryptionKey.</param>
        /// <returns></returns>
        public string EncryptString(
            string textToEncrypt, 
            string key)
        {
            encryptionKey = Convert.FromBase64String(key);
            return EncryptString(textToEncrypt);
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="textToDecrypt">The text to decrypt.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Not a valid encrypted string;encrypted</exception>
        public string DecryptString(string textToDecrypt)
        {
            byte[] cryptogram = Convert.FromBase64String(textToDecrypt);

            if (cryptogram.Length < 17)
            {
                throw new ArgumentException("Not a valid encrypted string", "encrypted");
            }

            byte[] vector = cryptogram.Take(16).ToArray();
            byte[] buffer = cryptogram.Skip(16).ToArray();
            return encoder.GetString(Decrypt(buffer, vector));
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="textToDecrypt">The text to decrypt.</param>
        /// <param name="key">The ket.</param>
        /// <returns></returns>
        public string DecryptString(
            string textToDecrypt, 
            string key)
        {
            encryptionKey = Convert.FromBase64String(key);
            return DecryptString(textToDecrypt);
        }

        /// <summary>
        /// Encrypts the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        private byte[] Encrypt(
            byte[] buffer,
            byte[] vector)
        {
            ICryptoTransform encryptor = rm.CreateEncryptor(encryptionKey, vector);
            return Transform(buffer, encryptor);
        }

        /// <summary>
        /// Decrypts the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        private byte[] Decrypt(byte[] buffer, byte[] vector)
        {
            ICryptoTransform decryptor = rm.CreateDecryptor(encryptionKey, vector);
            return Transform(buffer, decryptor);
        }

        /// <summary>
        /// Transforms the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="transform">The transform.</param>
        /// <returns></returns>
        private byte[] Transform(
            byte[] buffer,
            ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();

            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }

            return stream.ToArray();
        }
    }
}