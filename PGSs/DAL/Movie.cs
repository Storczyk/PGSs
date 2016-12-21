﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.DAL
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}