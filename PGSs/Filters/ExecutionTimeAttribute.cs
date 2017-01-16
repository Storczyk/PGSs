using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PGSs.Filters
{
    public class ExecutionTimeAttribute : ActionFilterAttribute
    {
        private const string stopwatchKey = "StopwatchKey";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.Request.Properties.Add(stopwatchKey, Stopwatch.StartNew());
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(stopwatchKey))
            {
                return;
            }

            var stopwatach = (Stopwatch)actionExecutedContext.Request.Properties[stopwatchKey];
            stopwatach.Stop();

            var time = stopwatach.ElapsedMilliseconds;
            actionExecutedContext.Response.Headers.Add("execution-time", time.ToString());

        }
    }
}