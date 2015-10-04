using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo01.Middleware.Middleware
{
    public class RequestDurationMiddleware
    {
        RequestDelegate _next;

        public RequestDurationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Debug.WriteLine("Handling request " + context.Request.Path);
            await _next.Invoke(context);

            stopwatch.Stop();

            Debug.WriteLine(String.Format("The request to {0} took {1} ms.", context.Request.Path, stopwatch.ElapsedMilliseconds));
        }

    }
}
