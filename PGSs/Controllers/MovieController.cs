using PGSs.DAL;
using PGSs.Filters;
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

        //- pole Genre (czyli kateogira filmu jak komedia itp) w Movie. I wyszukiwanie po kategorii
        [HttpGet, Route("movies/genre/{genre}")]
        public IHttpActionResult GetMoviesByGenre(Genres genre)
        {
            var movies = _movieService.GetByGenre(genre);
            return Ok(movies);
        }

        //- wyszukiwanie top 10 filmow z danej kategorii (czyli sortowanie po usrednionej wartosci) 
        [HttpGet, Route("movies/{genre}/top")]
        public IHttpActionResult GetTopMovies(Genres genre)
        {
            var movies = _movieService.GetTopMovies(genre);
            if (movies == null)
                return BadRequest();
            return Ok(movies);
        }
        [ExecutionTime]

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            return Ok(_movieService.GetAllMovies());
        }

        [ModelValidation]
        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]MovieRequest movie)
        {
            _movieService.Add(movie);
            return Ok("added");
        }
        [TvApiExceptionFilter]
        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var movie = _movieService.Find(id);
            return Ok(movie);
        }

        //2. Wyszukiwanie filmów po roku wydania
        [HttpGet, Route("movies/date/{dateMin:int}")]
        public IHttpActionResult GetMoviesByDate(int dateMin, int? dateMax = null)
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

        //3.       Wyszukiwanie filmów po tytule (lub po części tytułu)
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
