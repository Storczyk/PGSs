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
    public class ReviewController : ApiController
    {
        private ReviewService _reviewService;

        public ReviewController()
        {
            _reviewService = new ReviewService();
        }

        [HttpPost, Route("movies/{id:int}/review")]
        public IHttpActionResult AddReviewToMovie(int movieId, ReviewRequest request)
        {
            //walidacja
            _reviewService.AddReviewToMovie(movieId, request);
            return Ok();
        }
    }
}
