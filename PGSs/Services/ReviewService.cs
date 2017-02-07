using PGSs.DAL;
using PGSs.Filters;
using PGSs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PGSs.Services
{
    public class ReviewService
    {
        internal void AddReviewToMovie(int movieId, ReviewRequest request)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                {
                    throw new TvApiException("Inavlid movie Id");
                }
                movie.Reviews.Add(new Review()
                {
                    Comment = request.Comment,
                    Rate = request.Rate
                });
                ctx.SaveChanges();
            }
        }

        internal IEnumerable<ReviewResponse> GetReviewsForMovie(int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                    throw new TvApiException("Invalid movie ID");
                return movie.Reviews.Select(i => new ReviewResponse()
                {
                    Id = i.Id,
                    Comment=i.Comment,
                    Rate=i.Rate
                }).ToList();
            }
        }

        internal double? GetAvgRateForMovie(int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                    throw new TvApiException("Invalid movie ID");
                if (movie.Reviews.Select(r => r.Rate).Any())
                {
                    var rate = movie.Reviews.Average(i => i.Rate);
                    return rate;
                }
                return null;
            }
        }
    }
}