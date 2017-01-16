using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSs.Filters
{

    [Serializable]
    public class TvApiException : Exception
    {
        public TvApiException() { }
        public TvApiException(string message) : base(message) { }
        public TvApiException(string message, Exception inner) : base(message, inner) { }
        protected TvApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } 
}