using Alexandria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alexandria.Repository
{
    public class AvatarRepository : ICRUD<Avatar>
    {
        //Adição de usuário no db
        public void Add(Avatar item)
        {
            using (Context context = new Context())
            {
                context.Avatar.Add(item);
                context.SaveChanges();
            }

        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Avatar GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Avatar.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Update(Guid id, Avatar item)
        {
            throw new NotImplementedException();
        }


        public List<Avatar> GetItens()
        {
            using (Context context = new Context())
            {
                return context.Avatar.ToList();
            }
        }

        Avatar ICRUD<Avatar>.GetItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
