using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGSs.Models;
using PGSs.DAL;

namespace PGSs.Services
{
    public class DatabaseAccess : IDatabaseAccess
    {

        public void Add(ActorRequest actor, int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                movie.Actors.Add(new Actor()
                {
                    Forename = actor.Forename,
                    Surname = actor.Surname,
                    Birthdate = actor.Birthdate
                });
                ctx.SaveChanges();
            }
        }

        public void Add(ReviewRequest review, int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                movie.Reviews.Add(new Review()
                {
                    Comment = review.Comment,
                    Rate = review.Rate,
                });
                ctx.SaveChanges();
            }
        }

        public void Add(MovieRequest movie)
        {
            using (var ctx = new TvApiContext())
            {
                ctx.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Genre = movie.Genre
                });
                ctx.SaveChanges();
            }
        }
    }
}