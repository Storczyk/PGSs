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
    public class ActorController : ApiController
    {
        private ActorService _actorService;
        public ActorController()
        {
            _actorService = new ActorService();
        }

        [HttpGet, Route("movies/{movieId:int}/actors")]
        public IHttpActionResult GetActorsForMovie(int movieId)
        {
            var actors = _actorService.GetActorsForMovie(movieId);
            return Ok(actors);
        }

        [HttpGet, Route("actors")]
        public IHttpActionResult GetAllActors()
        {
            var actors = _actorService.GetAllActors();
            return Ok(actors);
        }

        [HttpGet, Route("actors/{actorId:int}/movies")]
        public IHttpActionResult GetMoviesForActor(int actorId)
        {
            var movies = _actorService.GetMoviesForActor(actorId);
            if(movies == null) //null gdy aktor nie istnieje
            {
                return BadRequest();
            }
            return Ok(movies);
        }

        [HttpPost, Route("movies/{movieId:int}/actor")]
        public IHttpActionResult AddActorForMovie(int movieId, [FromBody]ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_actorService.Add(movieId, actor))
            {
                return BadRequest();
            }
            return Ok("added");
        }

        [HttpDelete, Route("movies/{movieId:int}/{actorId:int}")]
        public IHttpActionResult DeleteFromMovie(int movieId, int actorId)
        {
            /*Wersja 1*/
            if (!_actorService.DeleteFromMovie(movieId, actorId))
            { 
                return BadRequest();
            }
            return Ok("deleted");
        }

        [HttpDelete, Route("actors/{actorId:int}")]
        public IHttpActionResult DeleteFromDb(int actorId)
        {
            /*Wersja 2 //zawsze zwraca "deleted" nawet jak encja (już) nie istnieje*/
            _actorService.DeleteFromDb(actorId); 
            return Ok("deleted");
        }
    }
}
