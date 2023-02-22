using Microsoft.EntityFrameworkCore;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Infrastructure.Repository
{
    public class BookRepository :IBookRepository
    {
        private readonly PioneerDbContext _context;
        public BookRepository(PioneerDbContext context)
        {
            _context = context;
        }

        public List<Book> AllBookList(Book book)
        {
            return _context.Books.ToList();
        }

        public Book CreateBook(Book book)
        {
            var books = new Book
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Pages = book.Pages,
                Price = book.Price,
                Genre = book.Genre,
                BookCategory = book.BookCategory,
                ImageURL = book.ImageURL,
                Publisher= book.Publisher,
                Language= book.Language,
                Description= book.Description,
            };
            _context.Add(books);
            _context.SaveChanges();
            return books;
        }

        public Book DeleteBook(Book ISBN)
        {
            _context.Books.Remove(ISBN);
            _context.SaveChanges();
            return ISBN;
        }


        public Book UpdateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Book GetBookByAuthor(string author)
        {
            return _context.Books.FirstOrDefault(x => x.Author == author) ?? new Book();
        }
        public Book GetBookByYearPublished(string yearPublished)
        {
            return _context.Books.FirstOrDefault(x => x.PublicationDate == yearPublished) ?? new Book();
        }
        public Book GetBookByISBN(string ISBN)
        {
            return _context.Books.FirstOrDefault(x => x.ISBN == ISBN) ?? new Book();
        }

        public Book GetBookByPublisher(string publisher)
        {
            return _context.Books.FirstOrDefault(x => x.Publisher == publisher) ?? new Book();
        }
        public Book GetBookByTitle(string title)
        {
            return _context.Books.FirstOrDefault(x => x.Title == title) ?? new Book();
        }

    }
}
