using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _review;
        public ReviewService(IReviewRepository review)
        {
            _review = review;
        }
        public Review AddComments(Review review)
        {
            return _review.AddComment(review);
        }

        public Review AddRatings(Review rating)
        {
            return _review.AddRating(rating);
        }
    }
}
