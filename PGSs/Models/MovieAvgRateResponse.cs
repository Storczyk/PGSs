using PGSs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.Models
{
    public class MovieAvgRateResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genres Genre { get; set; }
        public double AverageRate { get; set; }
    }
}