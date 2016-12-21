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
            var actors = _actorService.GetActors(movieId);
            return Ok(actors);
        }

        [HttpGet, Route("actors")]
        public IHttpActionResult GetAllActors()
        {
            var actors = _actorService.GetActors();
            return Ok(actors);
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
    }
}
