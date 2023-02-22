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
    //[Authorize(Roles = "User")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("comment")]

        public IActionResult AddComment(Review comment)
        {
            _reviewService.AddComments(comment);
            return Ok(comment);
        }

        [HttpPost("ratings")]

        public IActionResult AddRating(Review rating)
        {
            _reviewService.AddComments(rating);
            return Ok(rating);
        }
    }
}
