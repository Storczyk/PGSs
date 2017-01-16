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
                    Year = movie.Year,
                    Genre = movie.Genre
                   
                });
                ctx.SaveChanges();
            }
        }
        /* ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre***  ***Movies By Genre*** */
        internal IEnumerable<MovieResponse> GetByGenre(Genres genre)
        {
            if (!Enum.IsDefined(typeof(Genres), genre))
            {
                return null;
            }
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Where(g => g.Genre == genre).Select(m => new MovieResponse()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Genre = m.Genre
                }).ToList();
            }
        }
        /* *** 10 Top Movies*** *** 10 Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** ***Top Movies*** */
        internal IEnumerable<MovieAvgRateResponse> GetTopMovies(Genres genre) //lub <MovvieResponse> ale nie mamy podanej średniej
        {
            if (!Enum.IsDefined(typeof(Genres), genre))
            {
                return null;
            }
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Where(i => i.Genre == genre && i.Reviews.Any()).OrderByDescending(i => i.Reviews.Average(d => d.Rate)).Take(10).Select(m => new MovieAvgRateResponse()
                {
                    Id = m.Id,
                    Genre = m.Genre,
                    Title = m.Title,
                    Year = m.Year,
                    AverageRate = m.Reviews.Average(i => i.Rate) /*Dla nowego modelu MovieAvgRateResponse*/     
                }).ToList();
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
                    Year = x.Year,
                    Genre = x.Genre
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
                    Year = movie.Year,
                    Genre = movie.Genre
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
                    Year = m.Year,
                    Genre = m.Genre
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
                    Year = m.Year,
                    Genre = m.Genre
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