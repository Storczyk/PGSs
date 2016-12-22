using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.DAL
{
    public class Actor
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}