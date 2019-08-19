using Alexandria.Model;
using Alexandria.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Service
{
    public class AvatarService
    {
        public void AddAvatar(Avatar item)
        {
            AvatarRepository repository = new AvatarRepository();


            //Gerar novo ID
            item.Id = Guid.NewGuid();
            repository.Add(item);
        }

        public object GetListAvatar()
        {
            AvatarRepository repository = new AvatarRepository();


            return repository.GetItens();
        }

        public Avatar GetAvatar(Guid id)
        {
            AvatarRepository repository = new AvatarRepository();

            var usu = repository.GetItem(id);

            if (usu == null)
            {
                throw new Exception("User does not exists");
            }
            return usu;
        }



    }
}