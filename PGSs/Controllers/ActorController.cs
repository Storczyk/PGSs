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
    public class ActorController : ApiController
    {
        private ActorService _actorService;
        public ActorController()
        {
            _actorService = new ActorService();
        }
        /*Wszystkie filmy w ktorych jest aktor*/
        [TvApiExceptionFilter]
        [HttpGet, Route("actors/{actorId:int}/movies")]
        public IHttpActionResult GetMoviesForActor(int actorId)
        {
            var movies = _actorService.GetMoviesForActor(actorId);
            return Ok(movies);
        }
        [TvApiExceptionFilter]
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
        [TvApiExceptionFilter]
        [ModelValidation]
        [HttpPost, Route("movies/{movieId:int}/actor")]
        public IHttpActionResult AddActorForMovie(int movieId, [FromBody]ActorRequest actor)
        {
            if (!_actorService.Add(movieId, actor))
            {
                return BadRequest();
            }
            return Ok("added");
        }
        [TvApiExceptionFilter]
        [HttpDelete, Route("movies/{movieId:int}/{actorId:int}")]
        public IHttpActionResult DeleteFromMovie(int movieId, int actorId)
        {
            if (!_actorService.DeleteFromMovie(movieId, actorId))
            { 
                return BadRequest();
            }
            return Ok("deleted");
        }
        [TvApiExceptionFilter]
        [HttpDelete, Route("actors/{actorId:int}")]
        public IHttpActionResult DeleteFromDb(int actorId)
        {
            _actorService.DeleteFromDb(actorId); 
            return Ok("deleted");
        }
    }
}
