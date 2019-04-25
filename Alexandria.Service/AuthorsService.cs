using Alexandria.Model;
using Alexandria.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Service
{
    public class AuthorsService
    {
        public void AddAuthors(Authors item)
        {
            AuthorRepository repository = new AuthorRepository();

            //Gerar novo ID
            item.Id = Guid.NewGuid();
            repository.Add(item);
        }

        public object GetListAut()
        {
            AuthorRepository repository = new AuthorRepository();


            return repository.GetItens();
        }
    }
    



}
