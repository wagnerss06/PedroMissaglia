using Alexandria.Model;
using Alexandria.Repository;
using System;
using System.Collections.Generic;
using System.Text;

//Onde está a regra de negócio

namespace Alexandria.Service
{
    public class UserService
    {

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

    }
}
