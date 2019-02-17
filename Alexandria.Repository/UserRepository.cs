using Alexandria.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Responsável pelos funções a serem executadas para CRUD do BD
/// </summary>

namespace Alexandria.Repository
{
    public class UserRepository : ICRUD<User>
    {
        public void Add(User item)
        {
            using (Context context = new Context())
            {
                context.User.Add(item);
                context.SaveChanges();
            }

        }

        public string MD5Encrypt(string password) {

            string PasswordHash = "P@@Sw0rd";
            string SaltKey = "S@LT&KEY";
            string VIKey = "@1B2c3D4e5F6g7H8";

            byte[] passwordTextBytes = Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(passwordTextBytes, 0, passwordTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
             return Convert.ToBase64String(cipherTextBytes);

        }
        public static string MD5Decrypt(string password)
        {
            string PasswordHash = "P@@Sw0rd";
            string SaltKey = "S@LT&KEY";
            string VIKey = "@1B2c3D4e5F6g7H8";

            byte[] cipherTextBytes = Convert.FromBase64String(password);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public User GetUser(string email, string password)
        {
            using (Context context = new Context())
            {
                return context.User.Where(x => x.Email == email && MD5Decrypt(x.Password) == password).FirstOrDefault();
            }    
        }

        public User GetUserEmail(string email)
        {
            using (Context context = new Context())
            {
                return context.User.Where(x => x.Email == email).FirstOrDefault();
            }
        }

        //Método avançado para jogar a lambda expression em variável

        //public User Get(Expression<Func<User, bool>> expression)
        //{
        //    using (Context context = new Context())
        //    {
        //        return context.User.Where(expression).FirstOrDefault();
        //    }
        //}

        public void Delete(Guid id)
        {
            var user = GetItem(id);

            using (Context context = new Context())
            {
                if (user != null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                }
            }               
        }

        public User GetItem(Guid id)
        {
            using (Context context = new Context())
            {             
                return context.User.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<User> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, User item)
        {
            var user = GetItem(id);

            using (Context context = new Context())
            {
                if(user != null)
                {

                    user.Name = item.Name;
                    user.Birthdate = item.Birthdate;
                    user.Coin = item.Coin;
                    user.CPF = item.CPF;
                    user.Email = item.Email;
                    user.Gender = item.Gender;
                    user.Password = item.Password;

                    context.SaveChanges();
                }
            }
        }
    }
}
