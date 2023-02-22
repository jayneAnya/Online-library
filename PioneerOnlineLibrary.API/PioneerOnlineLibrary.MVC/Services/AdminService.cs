using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Helpers.Helpers;
using PioneerOnlineLibrary.MVC.Interface;

namespace PioneerOnlineLibrary.MVC.Services
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Admin/";

        public AdminService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Book> CreateBook(Book book)
        {
            var response = await _client.GetAsync(BasePath + book.ToString());
            return await response.ReadContentAsync<Book>();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var response = await _client.GetAsync(BasePath + book.ToString());
            return await response.ReadContentAsync<Book>();
        }

        public async Task<Book> DeleteBook(Book ISBN)
        {
            var response = await _client.GetAsync(BasePath + ISBN.ToString());
            return await response.ReadContentAsync<Book>();
        }
    }
}
