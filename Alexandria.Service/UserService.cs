using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Repository;
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
        public bool Login(string email, string password)
        {

            UserRepository repository = new UserRepository();

            if (repository.GetUser(email, password) != null)



                return true;

            return false;
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
        public void RemoveUser(User user)
        {
            UserRepository repository = new UserRepository();

            var userEmail = repository.GetUserEmail(user.Email);

            if (userEmail == null)
            {
                throw new Exception("User does not exists");

            }

            repository.GetUser(user.Email, user.Password);

            repository.Delete(user.Id);
        }
        public void UpdateUser(NewPasswordDTO item)
        {
            UserRepository repository = new UserRepository();
            var userEmail = repository.GetUserEmail(item.Email);

            if (userEmail != null && item.New_Password.CompareTo(item.Confirm_Password) == 0)
            {
                userEmail.Password = item.Confirm_Password;
                repository.Update(userEmail.Id, userEmail);
            }
            else {
                throw new Exception("Passwords do not match.");
            }

        }

    }
}
