using Alexandria.Model;
using Alexandria.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Service
{
    public class BookService
    {
        public void AddBook(Book item)
        {
            BookRepository repository = new BookRepository();

            //Gerar novo ID
            item.Id = Guid.NewGuid();
            repository.Add(item);
        }


        public object GetListBook(int n)
        {
            BookRepository repository = new BookRepository();


            return repository.GetItens(n);
        }

        public object GetBookIsbn(string isbn)
        {
            BookRepository repository = new BookRepository();


            return repository.GetBookIsbn(isbn);
        }

        public object GetBookIsbn13(string isbn13)
        {
            BookRepository repository = new BookRepository();


            return repository.GetBookIsbn13(isbn13);
        }

        public object GetBookAuthor(string author)
        {
            AuthorRepository authrepository = new AuthorRepository();

            Authors item =  authrepository.GetItembyName(author);

            BookRepository repository = new BookRepository();


            return repository.GetBookByAuthor(item.Id);
        }

    }
}
