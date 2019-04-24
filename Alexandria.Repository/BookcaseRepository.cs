using Alexandria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Repository
{
    public class BookcaseRepository : ICRUD<Bookcase>
    {

        public void Add(Bookcase item)
        {
            using (Context context = new Context())
            {
                context.Bookcase.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Bookcase bookId)
        {
            using (Context context = new Context())
            {
                context.Bookcase.Remove(bookId);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Bookcase GetItem(Guid id)
        {
            throw new NotImplementedException();
        }


        public List<Bookcase> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Bookcase item)
        {
            throw new NotImplementedException();
        }
    }
}
