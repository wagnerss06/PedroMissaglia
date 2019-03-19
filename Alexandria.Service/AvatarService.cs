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


    }
}
