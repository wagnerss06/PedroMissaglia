using Alexandria.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Responsável pelos funções a serem executadas para CRUD do BD
/// </summary>

namespace Alexandria.Repository
{
    public class UserRepository : ICRUD<User>
    {

        //Adição de usuário no db
        public void Add(User item)
        {
            using (Context context = new Context())
            {
                context.User.Add(item);
                context.SaveChanges();
            }

        }

        //Método de criptografia para senha
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
        //Método para descriptografar a senha do usuário
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
        //Função auxiliar para consultar usuário no db por email e senha
        public User GetUser(string email, string password)
        {
            using (Context context = new Context())
            {
                return context.User.Where(x => x.Email == email && MD5Decrypt(x.Password) == password).FirstOrDefault();
            }    
        }
        //Função auxiliar para pegar email do usuário
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
        //Função para deletar usuário (Não foi implementado ainda, e talvez não seja)
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
        //Função auxiliar para consulta de usuário por ID
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
                    user.Password = MD5Encrypt(item.Password);

                    context.Update(user);
                    context.SaveChanges();
                }
            }
        }
        //Função auxiliar para gerar string aleatório (útil)
        public string RandomString()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 5; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
           
            return builder.ToString();
        }
        //Função para envio de e-mail
        public void SendEmail(string email)
        {

            string emailAlex = "alexandriateste1@gmail.com";
            string passAlex = "Spectro@123";
            string newPassword = RandomString();
            //var contentID = "Image";
            //var inlineLogo = new Attachment(@"C://Alexandria/Assign.png");
            string nomeUser = GetUserEmail(email).Name;
            string htmlBody;
            string url = "https://localhost:3000/?id="+GetUserEmail(email).Id;

            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = true;
            htmlBody = CreateBody(nomeUser, url);
            

            mail.From = new MailAddress(emailAlex);
            mail.To.Add(email); // para
            mail.Subject = "Alexandria - Nova Senha"; // assunto
            mail.Body += htmlBody;
       

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential(emailAlex, passAlex);

                // envia o e-mail
                smtp.Send(mail);

            }
        }
        private string CreateBody(string nameUsuario, string url)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("C://Users/pedro.missaglia/source/repos/PedroMissaglia/Alexandria.API/wwwroot/teste.html"))
            {

                body = reader.ReadToEnd();

            }
            body = body.Replace("{fname}", nameUsuario);
            body = body.Replace("{furl}", url); 


            return body;

        }
        
        
    }
}

