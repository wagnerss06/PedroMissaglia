using Alexandria.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Responsável pelos funções a serem executadas para CRUD do BD
/// </summary>

namespace Alexandria.Repository
{
    public class BookRepository : ICRUD<Book>
    {
        public void Add(Book item)
        {
            using (Context context = new Context())
            {
                context.Book.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        //Auxiliar
        public Book GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Book.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<Book> GetItens(int n)
        {
            using (Context context = new Context())
            {
                return context.Book.ToList().GetRange(0, n);
            }
        }

        public void Update(Guid id, Book item)
        {
            var book = GetItem(id);

            using (Context context = new Context())
            {
                if (book != null)
                {
                    book.Title          = item.Title;
                    book.Title_long     = item.Title_long;
                    book.ISBN           = item.ISBN;
                    book.ISBN13         = item.ISBN13;
                    book.Editora        = item.Editora;
                    book.Edition        = item.Edition;
                    book.Date_published = item.Date_published;
                    book.Language       = item.Language;
                    book.Pages          = item.Pages;
                    book.Literary_genre = item.Literary_genre;
                    book.PageCount      = item.PageCount;
                    book.Status         = book.Status;
                       
                    context.Update(book);
                    context.SaveChanges();
                }
            }
        }

        public Book GetBookTitle(string title)
        {
            using (Context context = new Context())
            {
                return context.Book.Where(x => x.Title == title).FirstOrDefault();
            }
        }

        public Book GetBookIsbn(string isbn) // method por ISBN
        {
            using (Context context = new Context())
            {
                return context.Book.Where(x => x.ISBN == isbn).FirstOrDefault();
            }
        }

        public Book GetBookIsbn13(string isbn13) // method por ISBN13
        {
            using (Context context = new Context())
            {
                return context.Book.Where(x => x.ISBN13 == isbn13).FirstOrDefault();
            }
        }


        public List<Book> GetBookByAuthor(Guid authorId) // method por ISBN13
        {
            using (Context context = new Context())
            {
                return context.Book.Where(x => x.AuthorsId == authorId).ToList();

            }
        }

        
        public List<Book> GetItens()
        {
            throw new NotImplementedException();
        }
    }
}
