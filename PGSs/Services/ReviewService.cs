using PGSs.DAL;
using PGSs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.Services
{
    public class ReviewService
    {
        internal void AddReviewToMovie(int movieId, ReviewRequest request)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                movie.Reviews.Add(new Review()
                {
                    Comment = request.Comment,
                    Rate = request.Rate
                });
                ctx.SaveChanges();
            }
        }


    }
}