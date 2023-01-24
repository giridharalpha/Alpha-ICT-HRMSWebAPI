using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace HRMS.BusinessObjects.Models
{
    public class PasswordSecurity
    {

        public string Encrypt(string clearText)
        {
            CryptoStream cs = null;
            MemoryStream ms = null;
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] ClearBytes = Encoding.Unicode.GetBytes(clearText);

                using (Aes Encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    Encryptor.Key = pdb.GetBytes(32);
                    Encryptor.IV = pdb.GetBytes(16);
                    using (ms = new MemoryStream())
                    {
                        using (cs = new CryptoStream(ms, Encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(ClearBytes, 0, ClearBytes.Length);
                            //cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (ms != null)
                {
                    ms.Dispose();

                }
                if (cs != null)
                {
                    cs.Dispose();
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            CryptoStream cs = null;
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] CipherBytes = Convert.FromBase64String(cipherText);
                using (Aes Encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    Encryptor.Key = pdb.GetBytes(32);
                    Encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (cs = new CryptoStream(ms, Encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(CipherBytes, 0, CipherBytes.Length);
                            //cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cs != null)
                {
                    //cs.Close();
                    //cs.Dispose();
                }
            }
            return cipherText;
        }

        public static string RandomString(int length)
        {
            Random rnd = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[rnd.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }
}

