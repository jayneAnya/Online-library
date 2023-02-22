using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Infrastructure.Interface;

namespace PioneerOnlineLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("ISBN")]
        public IActionResult GetByISBN(string ISBN)
        {
            var byIsbn = _bookService.GetByISBN(ISBN);
            return Ok(byIsbn);
        }

        [HttpGet("get-by-title/{title} ")]
        public IActionResult GetByTitle(string title)
        {
            var byTitle = _bookService.GetByTitle(title);
            return Ok(byTitle);
        }

        [HttpGet("author")]
        public IActionResult GetByAuthor(string author)
        {
            var byAuthor = _bookService.GetByAuthor(author);
            return Ok(byAuthor);
        }
        
        [HttpGet("get-by-publisher/{publisher}")]
        public IActionResult GetByPublisher(string publisher)
        {
            var byPublisher = _bookService.GetByPublisher(publisher);
            return Ok(byPublisher);
        }

        [HttpGet("get-by-year-published/{yearPublished}")]
        public IActionResult GetByYearPublished(string yearPublished)
        {
            var byYear = _bookService.GetByDatePublished(yearPublished);
            return Ok(byYear);
        }
    }
}
