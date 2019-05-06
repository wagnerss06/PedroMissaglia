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
        public void AddBook(UserBookcaseDTO item)
        {
            BookcaseRepository repository = new BookcaseRepository();

            //Gerar novo ID
            item.IdBookcase = Guid.NewGuid();
            repository.Add(item);
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

        public object createAndUpdateUserWithBookcase(Guid id)
        { 
            UserRepository repository = new UserRepository();

            if (repository.GetItem(id) == null)
            {
                throw new Exception("User does not exists");

            }
            return repository.UpdateBookCase(id);
        }
       


    }
}
