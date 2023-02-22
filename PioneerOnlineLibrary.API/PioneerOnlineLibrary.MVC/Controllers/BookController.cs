using Microsoft.AspNetCore.Mvc;
using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Domain.Model;

namespace PioneerOnlineLibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServ _BookServ;


        public BookController(IBookServ bookServ)
        {
            _BookServ = bookServ ?? throw new ArgumentNullException(nameof(_BookServ));
        }

        public async Task<ActionResult> GetAuthor(string author)
        {
            try
            {
                var book = await _BookServ.GetByAuthor(author);
                return View(book);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult GetAuthor()
        {
            return View();
        }


        [Route("GetISBN")]
        public async Task<ActionResult> GetISBN(string Isbn)
        {
            try
            {
                var book = await _BookServ.GetByISBN(Isbn);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
       

        public IActionResult GetISBN()
        {
            return View();
        }

        public async Task<ActionResult> GetByTitle(string title)
        {
            try
            {
                var book = await _BookServ.GetByTitle(title);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult GetByTitle()
        {
            return View();
        }


        public async Task<ActionResult> GetByPublisher(string publisher)
        {
            try
            {
                var book = await _BookServ.GetByPublisher(publisher);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        

        public IActionResult GetByPublisher()
        {
            return View();
        }

        public async Task<ActionResult> GetByDatePublished(string datePublished)
        {
            try
            {
                var book = await _BookServ.GetByDatePublished(datePublished);
                return View(book);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult GetByDatePublished()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("AllBooks")]
        public async Task<IActionResult> Index(Book book)
        {
            var books = await _BookServ.AllBookList(book);
            return View(books);
        }
       

    }
}
