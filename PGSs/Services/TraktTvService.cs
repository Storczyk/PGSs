using PGSs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PGSs.Services
{
    public class TraktTvService
    {
        private MovieService _movieService = new MovieService();
        public async Task DownloadMovies()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://api.trakt.tv/movies/popular");
                var movies = await response.Content.ReadAsAsync<IEnumerable<TraktTvMovie>>();
                foreach(var movie in movies)
                {
                    _movieService.Add(new MovieRequest
                    {
                        Title = movie.Title,
                        Year = movie.Year
                    });
                }
                
            }
        }
    }
}