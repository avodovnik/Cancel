using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Internal;

namespace Demo04.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        public LogFilter()
        {
            Order = 1;
        }

        private ILogger _logger;
        public LogFilter(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<LogFilter>();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("An action was exectued, full path: {0}", context.HttpContext.Request.Path.ToString());

            base.OnActionExecuted(context);
        }
    }
}
