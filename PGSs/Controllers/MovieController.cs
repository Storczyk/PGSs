using PGSs.Models;
using PGSs.Services;
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
        private MovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            return Ok(_movieService.GetAllMovies());
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]MovieRequest movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _movieService.Add(movie);

            return Ok("added");
        }

        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var movie = _movieService.Find(id);
            return Ok(movie);
        }

        [HttpGet, Route("movies/date/{dateMin:int}/{dateMax:int?}")]
        public IHttpActionResult GetMoviesByDate(int dateMin, int? dateMax=null)
        {
            if (!dateMax.HasValue)
            {
                dateMax = dateMin;
            }
            if (dateMax.Value < dateMin)
            {
                int temp = dateMax.Value;
                dateMax = dateMin;
                dateMin = temp;
            }
            var movies = _movieService.GetByDate(dateMin, dateMax.Value);
            return Ok(movies);
        }

        [HttpGet, Route("movies/title/{title}")]
        public IHttpActionResult GetMoviesByTitle(string title)
        {
            var movies = _movieService.GetByTitle(title);
            return Ok(movies);
        }

        [HttpDelete, Route("movies/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok("deleted");
        }
    }
}
