using Alexandria.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexandria.Repository
{
    public class BookcaseRepository : ICRUD<Bookcase>
    {

        public void Add(UserBookcaseDTO item)
        {
            Bookcase item2 = new Bookcase();
            item2.Id = item.IdBookcase;
            item2.Status = item.Status;
            item2.PageCount = item.PageCount;
            item2.BookId = item.BookId;

            using (Context context = new Context())
            {
                context.Bookcase.Add(item2);
                context.SaveChanges();
            }
        }

        public void Add(Bookcase item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public Bookcase GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Bookcase.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public User GetUserId(Guid id)
        {
            using (Context context = new Context())
            {
                return context.User.Where(x => x.Id == id).FirstOrDefault();
            }
        }


        public void AddBookinBC(Guid? bookcaseid, UserBookcaseDTO item)
        {
            string oi = bookcaseid.ToString();
            Bookcase item2 = new Bookcase();
            item2.Id = Guid.Parse(oi);
            item2.Status = item.Status;
            item2.PageCount = item.PageCount;
            item2.BookId = item.BookId;

            using (Context context = new Context())
            {
                context.Bookcase.Add(item2);
                context.SaveChanges();
            }
        }

        public List<Bookcase> GetItens(int n)
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


