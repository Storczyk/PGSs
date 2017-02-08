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
    public class ReviewController : ApiController
    {
        private ReviewService _reviewService;

        public ReviewController()
        {
            _reviewService = new ReviewService();
        }


        [ModelValidation]
        [HttpPost, Route("movies/{movieId:int}/review")]
        public IHttpActionResult AddReviewToMovie(int movieId, ReviewRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _reviewService.AddReviewToMovie(movieId, request);
            return Ok("Review added");
        }

        [HttpGet, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult GetReviewsForMovie(int movieId)
        {
            return Ok(_reviewService.GetReviewsForMovie(movieId));
        }

        //4.       Zwracanie średniej oceny dla filmu
        [HttpGet, Route("movies/{movieId:int}/rate")]
        public IHttpActionResult GetAvgRateForMovieById(int movieId)
        {
            var rate = _reviewService.GetAvgRateForMovie(movieId);
            return Ok(rate);
        }

    }
}
