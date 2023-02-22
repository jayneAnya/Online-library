using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Core.Interface
{
    public interface IBookServ
    {
        public Task<List<Book>> AllBookList(Book book);
        public Task<Book> GetByISBN(string ISBN);

        public Task<Book> GetByTitle(string title);
        public Task<Book> GetByAuthor(string author);
        public Task<Book> GetByPublisher(string publisher);
        public Task<Book> GetByDatePublished(string datePublished);
    }
}
