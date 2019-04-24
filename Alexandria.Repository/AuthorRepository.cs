using Alexandria.Model;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Authors> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Authors item)
        {
            throw new NotImplementedException();
        }
    }
}
