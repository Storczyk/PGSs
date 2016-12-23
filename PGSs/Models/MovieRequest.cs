using PGSs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.Models
{
    public class MovieRequest
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Genres Genre { get; set; }

    }
}