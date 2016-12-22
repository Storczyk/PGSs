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

        internal IEnumerable<MovieResponse> GetByDate(int dateMin, int dateMax)
        {
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Where(x => x.Year >= dateMin && x.Year <= dateMax).Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year
                }).ToList();
            }
        }

        internal IEnumerable<MovieResponse> GetByTitle(string title)
        {
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Where(x => x.Title.Contains(title)).Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year
                }).ToList();
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