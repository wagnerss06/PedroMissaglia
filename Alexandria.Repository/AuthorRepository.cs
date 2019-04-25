using Alexandria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alexandria.Repository
{
    public class AuthorRepository : ICRUD<Authors>
    {
        public void Add(Authors item)
        {
            using (Context context = new Context())
            {
                context.Authors.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Authors GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Authors.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public Authors GetItembyName(string authorName)
        {
            using (Context context = new Context())
            {
                return context.Authors.Where(x => x.Author == authorName).FirstOrDefault();
            }
        }

        public List<Authors> GetItens()
        {
            using (Context context = new Context())
            {
                return context.Authors.ToList();
            }
        }

        public void Update(Guid id, Authors item)
        {
            throw new NotImplementedException();
        }
    }
}
