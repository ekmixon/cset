﻿using System;
using System.Security.Cryptography;
using CSETWebCore.Interfaces.Helpers;

namespace CSETWebCore.Helpers
{
    public class PasswordHash : IPasswordHash
    {
        public const int SaltByteSize = 24;
        public const int HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash 
        public const int iterations = 1000;
        private readonly char[] Punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();

        /// <summary>
        /// This version is used if the salt and hash are supplied in a single string 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="correctHash"></param>
        /// <returns></returns>
        public bool ValidatePassword(string password, string hash, string salt)
        {
            var hashArray = Convert.FromBase64String(hash); 
            var saltArray = Convert.FromBase64String(salt);

            var testHash = GetPbkdf2Bytes(password, saltArray, iterations, hashArray.Length);

            return BitConverter.ToString(hashArray).Equals(BitConverter.ToString(testHash));
        }


        /// <summary>
        /// Creates a new hash.  The hash and its salt are returned in the hash and salt arguments.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public void HashPassword(string password, out string hash, out string salt)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] saltArray = new byte[SaltByteSize];
            cryptoProvider.GetBytes(saltArray);

            var hashArray = GetPbkdf2Bytes(password, saltArray, iterations, HashByteSize);

            hash = Convert.ToBase64String(hashArray);
            salt = Convert.ToBase64String(saltArray);
        }

        public byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public byte[] ConvertFromBase64String(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return null;
            try
            {
                string working = input.Replace('-', '+').Replace('_', '/'); ;
                while (working.Length % 4 != 0)
                {
                    working += '=';
                }
                return Convert.FromBase64String(working);
            }
            catch (Exception exc)
            {
                log4net.LogManager.GetLogger(this.GetType()).Error($"... {exc}");

                return null;
            }
        }
    }
}