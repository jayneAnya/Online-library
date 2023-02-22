using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Infrastructure.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PioneerDbContext _context;
        public ReviewRepository(PioneerDbContext context)
        {
            _context = context;
        }
        public Review AddComment(Review review)
        {
            _context.Add(review);
            _context.SaveChanges();
            return review;
        }

        public Review AddRating(Review rating)
        {
            _context.Add(rating);
            _context.SaveChanges();
            return rating;
        }
    }
}
