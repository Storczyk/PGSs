using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace PGSs.Filters
{
    public class TvApiExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if(actionExecutedContext.Exception is TvApiException)
            {
                actionExecutedContext.Response = 
                    actionExecutedContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            }
        }
    }
}