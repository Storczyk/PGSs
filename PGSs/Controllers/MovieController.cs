using PGSs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PGSs.Controllers
{
    public class MovieController : ApiController
    {
        private List<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id=1,
                    Title="film",
                    Author="Ruszpala",
                    Comments = new List<string>
                    {
                        "super", "cool"
                    }
                },
                new Movie
                {
                    Id=2,
                    Title="ruszpalafilmciulowy",
                    Author="rafal",
                    Comments = new List<string>(),
                }
            };
            return movies;
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<Movie> movies = getMovies();

            return Ok(movies);
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie(Movie movie)
        {
            return Ok(movie);
        }

        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            List<Movie> movies = getMovies();
            Movie movie = movies.Where(i => i.Id == id).SingleOrDefault();
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpDelete,Route("movies/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            List<Movie> movies = getMovies();
            var movie = movies.SingleOrDefault(i => i.Id == id);
            if(movie == null)
            {
                return BadRequest();
            }

            movies.Remove(movie);
            return Ok();
        }
    }
}
