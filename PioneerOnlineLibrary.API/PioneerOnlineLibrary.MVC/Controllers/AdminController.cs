using Microsoft.AspNetCore.Mvc;
using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Core.Services;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.MVC.Interface;

namespace PioneerOnlineLibrary.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(_adminService));
        }

        public async Task<ActionResult> CreateBook(Book book)
        {
            try
            {
                var books = await _adminService.CreateBook(book);
                return View(book);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public IActionResult CreateBook()
        {
            return View();
        }



        public async Task<ActionResult> UpdateBook(Book book)
        {
            try
            {
                var books = await _adminService.UpdateBook(book);
                return View(book);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public IActionResult UpdateBook()
        {
            return View();
        }


        public async Task<ActionResult> DeleteBook(Book book)
        {
            try
            {
                var books = await _adminService.DeleteBook(book);
                return View(book);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        public IActionResult DeleteBook()
        {
            return View();
        }

    }
}
