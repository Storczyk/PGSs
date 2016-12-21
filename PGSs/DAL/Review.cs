using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.DAL
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public short Rate { get; set; }
        public virtual Movie movie { get; set; }
    }
}