using System;
using System.Security.Cryptography;
using System.Text;

namespace Bank_BusinessLayer
{
    public static class clsPasswordHashing
    {
        //public class HashResult
        //{
        //    public string PasswordHash { get; set; }
        //    public string Salt { get; set; }

        //    public HashResult(string passwordHash, string salt)
        //    {
        //        this.PasswordHash = passwordHash;
        //        this.Salt = salt;
        //    }
        //}

        public static byte[] ConvertHexStringToBytes(string hexString)
        {
            int charCount = hexString.Length;
            byte[] byteArray = new byte[charCount / 2];
            
            for (int i = 0; i < charCount; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteArray;
        }                                                             
        
        /// <summary>
        /// Generates a secure SHA-256 password hash combined with a unique random salt.
        /// </summary>
        /// <param name="Password">
        /// The plain-text password to hash.
        /// </param>
        /// <param name="existingSalt">
        /// Optional. If provided, the function will reuse this Base64-encoded salt.  
        /// Otherwise, a new random 16-byte salt will be generated.
        /// </param>
        /// <returns>
        /// A tuple containing:
        /// - Hash: SHA-256 hash of password + salt (hex string)
        /// - Salt: Salt used (Base64 string)
        /// </returns>
        public static (string passwordHashHex, string saltHex) HashPassword(string plainPassword, string existingSaltHex = null)
        {
            byte[] saltBytes;

            // If a salt is provided, reuse it; otherwise generate a new one
            if (!string.IsNullOrEmpty(existingSaltHex))
            {
                // Convert the provided Base64 string back to bytes
                saltBytes = ConvertHexStringToBytes(existingSaltHex);
            }
            else
            {
                // Generate a new random 16-byte salt
                saltBytes = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltBytes);
                }
            }

            // Combine password bytes + salt bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(plainPassword);
            byte[] passwordWithSalt = new byte[passwordBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, passwordWithSalt, passwordBytes.Length, saltBytes.Length);

            // Compute SHA-256 hash
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordWithSalt);
            }

            // Convert both hash and salt to hex strings
            string passwordHashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            string saltHex = BitConverter.ToString(saltBytes).Replace("-", "").ToLower();

            return (passwordHashHex, saltHex);
        }

        /// <summary>
        /// Verifies that the entered password matches the stored hash by using the stored salt.
        /// </summary>
        /// <param name="enteredPassword">The plain-text password entered by the user.</param>
        /// <param name="storedPasswordHashHex">The stored password hash in hex string format.</param>
        /// <param name="storedSaltHex">The stored salt in hex string format.</param>
        /// <returns>
        /// True if the entered password is correct (hashes match); otherwise, false.
        /// </returns>
        public static bool VerifyPassword(string enteredPassword, string storedPasswordHashHex, string storedSaltHex)
        {
            // Convert stored salt back to bytes
            byte[] saltBytes = ConvertHexStringToBytes(storedSaltHex);

            // Combine entered password + stored salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] passwordWithSalt = new byte[passwordBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, passwordWithSalt, passwordBytes.Length, saltBytes.Length);

            // Compute new hash
            byte[] computedHashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                computedHashBytes = sha256.ComputeHash(passwordWithSalt);
            }

            string computedHashHex = BitConverter.ToString(computedHashBytes).Replace("-", "").ToLower();

            // Compare with stored hash
            return computedHashHex == storedPasswordHashHex;
        }
    }
}
