using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PioneerOnlineLibrary;
using PioneerOnlineLibrary.Helpers.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PioneerOnlineLibrary.Core.Services
{
    public class BookServ : IBookServ
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Book/";

        public BookServ(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<Book>> AllBookList(Book book)
        {
            var response = await _client.GetAsync(BasePath + book.ToString());
            if(response != null)
            {
                return await response.ReadContentAsync<List<Book>>();
            }
            return null;
           
        }

        


        public async Task<Book> GetByISBN(string ISBN)
        {
            var response = await _client.GetAsync(BasePath  + ISBN);

            return await response.ReadContentAsync<Book>();


        }
        //get-by-isbn/{ISBN}

        public async Task<Book> GetByTitle(string title)
        {
            var response = await _client.GetAsync(BasePath + title);

            return await response.ReadContentAsync<Book>();
        }

        public async Task<Book> GetByAuthor(string author)
        {
            var response = await _client.GetAsync(BasePath +  author);

            return await response.ReadContentAsync<Book>();
        }

        public async Task<Book> GetByPublisher(string publisher)
        {
            var response = await _client.GetAsync(BasePath + publisher);

            return await response.ReadContentAsync<Book>();
        }

        public async Task<Book> GetByDatePublished(string datePublished)
        {
            var response = await _client.GetAsync(BasePath  + datePublished);

            return await response.ReadContentAsync<Book>();
        }
    }
}
