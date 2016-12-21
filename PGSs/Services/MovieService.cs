using PGSs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGSs.Models;

namespace PGSs.Services
{
    public class MovieService
    {
        public MovieService()
        {

        }

        internal void Add(MovieRequest movie)
        {
            using (var ctx = new TvApiContext())
            {
                ctx.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Year = movie.Year
                });
                ctx.SaveChanges();
            }
        }

        internal IEnumerable<MovieResponse> GetAllMovies()
        {
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Select(x => new MovieResponse()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year
                }).ToList();

            }
        }

        internal MovieResponse Find(int id)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(id);
                if (movie == null)
                {
                    return null;
                }
                return new MovieResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year
                };
            }
        }

        internal void Delete(int id)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(id);
                if(movie == null)
                {
                    return;
                }
                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
        }
    }
}