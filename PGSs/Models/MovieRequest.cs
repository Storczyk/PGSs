using PGSs.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGSs.Models
{
    public class MovieRequest
    {
        public string Title { get; set; }
        [Range(1888,Int32.MaxValue,ErrorMessage ="Year should be greater than 1888")]
        public int Year { get; set; }
        public Genres Genre { get; set; }

    }
}