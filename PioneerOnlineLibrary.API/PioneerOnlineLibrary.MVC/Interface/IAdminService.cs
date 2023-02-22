using PioneerOnlineLibrary.Domain.Model;

namespace PioneerOnlineLibrary.MVC.Interface
{
    public interface IAdminService
    {
      
        public Task<Book> CreateBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task<Book> DeleteBook(Book ISBN);
    }
}
