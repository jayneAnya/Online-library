using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Infrastructure.Interface
{
    public interface IBookRepository
    {
        List<Book> AllBookList(Book book);
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(Book ISBN);
        Book GetBookByAuthor(string name);
        Book GetBookByTitle(string title);
        Book GetBookByPublisher(string publisher);
        Book GetBookByISBN(string ISBN);
        Book GetBookByYearPublished(string yearPublished);
    }
}
