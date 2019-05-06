using Alexandria.Model;
using Alexandria.Model.DTO;
using Alexandria.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Service
{
    public class BookcaseService
    {
        public Guid CreateBookcase(UserBookcaseDTO item)
        {
            BookcaseRepository repository = new BookcaseRepository();

            //Gerar novo ID
            item.IdBookcase = Guid.NewGuid();
            repository.Add(item);

            return item.IdBookcase;
        }


        public object GetListBook(int n)
        {
            BookcaseRepository repository = new BookcaseRepository();


            return repository.GetItens(n);
        }

        public bool questionExistenciality(Guid id) {

            bool s = false;

            BookcaseRepository repository = new BookcaseRepository();


            User iduser = repository.GetUserId(id);

            if (iduser.BookcaseId != null) { 
                s = true;
            }
            return s;
        }

        public void UpdateUserWithBookcase(Guid userid, Guid id)
        { 
            UserRepository repository = new UserRepository();

            repository.UpdateBookCase(userid, id);
        }
       


    }
}
