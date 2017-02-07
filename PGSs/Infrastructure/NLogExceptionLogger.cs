using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace PGSs.Infrastructure
{
    public class NLogExceptionLogger:ExceptionLogger
    {
        private readonly static NLog.Logger nLogger = NLog.LogManager.GetCurrentClassLogger();
        public override void Log(ExceptionLoggerContext context)
        {
            nLogger.Error(context.Exception);
        }
    }
}