using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

//Onde está a regra de negócio

namespace Alexandria.Service
{
    public class UserService
    {


        public bool Email(string email)
        {

            UserRepository repository = new UserRepository();

            if (repository.GetUserEmail(email) != null) {

                repository.SendEmail(email);

                return true;

            }

            return false;
        }
        public User Login(string email, string password)
        {
            
            UserRepository repository = new UserRepository();


            User userEmail = repository.GetUser(email, password);

            //object user = null;
            //string[] nRet = new string[2];


            //if (userEmail != null)
            //{
            //    user = repository.GetUser(email, password);
            //    if (user != null) {

            //        nRet[0] = "1";
            //        nRet[1] = userEmail.Id.ToString() ;
            //    }
            //    else { nRet[0] = "2"; }

            //}
            //else { nRet[0] = "3"; }

            //return nRet;
            return userEmail;
        }

        public User Login(string email)
        {
            UserRepository userRepository = new UserRepository();

            var user = userRepository.GetUserEmail(email);
            return user;
        }

        public void AddUser(User item)
        {
            UserRepository repository = new UserRepository();

            var userEmail = repository.GetUserEmail(item.Email);

            if(userEmail != null)
            {
                throw new Exception("User alredy exists");
                
            }

            //Gerar novo ID
            item.Id = Guid.NewGuid();
            item.Password = repository.MD5Encrypt(item.Password);
            repository.Add(item);     
        }
        public void RemoveUser(IdDTO user)
        {
            UserRepository repository = new UserRepository();

            var usu = repository.GetItem(user.Id);

            if (usu == null)
            {
                throw new Exception("User does not exists");

            }

            repository.Delete(user.Id);
        }
        public void UpdatePasswordUser(NewPasswordDTO item)
        {
            UserRepository repository = new UserRepository();
            var userId = repository.GetItem(item.Id);

            if (userId != null && item.New_Password.CompareTo(item.Confirm_Password) == 0)
            {
                userId.Password = item.Confirm_Password;
                repository.Update(userId.Id, userId);
            }
            else {
                throw new Exception("Passwords do not match.");
            }

        }
        public void UpdateAvatarUser(UserAvatarDTO item)
        {
            UserRepository repository = new UserRepository();
            var userId = repository.GetItem(item.Id);

            if (userId != null )
            {              
                repository.UpdateAvatar(userId.Id, item.AvatarId);
            }
            else
            {
                throw new Exception();
            }

        }
        // função para retornar usuário completo
        public User GetUser(Guid id)
        {
            UserRepository repository = new UserRepository();

            var usu = repository.GetItem(id);

            if (usu == null)
            {
                throw new Exception("User does not exists");
            }
            return usu;
        }

        // função para retornar usuário completo
        public User GetUserEmail(string email)
        {
            UserRepository repository = new UserRepository();

            var usu = repository.GetUserEmail(email);

            if (usu == null)
            {
                throw new Exception("User does not exists");
            }
            return usu;
        }

    }

    
}
