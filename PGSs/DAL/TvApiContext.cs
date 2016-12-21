using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PGSs.DAL
{
    public class TvApiContext : DbContext
    {
        public TvApiContext() : base("tvApiDb")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}