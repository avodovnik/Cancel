using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Http.Features;
using Demo01.Middleware.Middleware;
using Microsoft.Framework.Logging;

namespace Demo01.Middleware
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestDurationMiddleware>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hi Cancel!<br/>");
                await next.Invoke();
                await context.Response.WriteAsync("<br/>I'm done.");
            });
    
            app.Map("/diagnostics", c =>
            {
                c.Run(async ctx =>
               {
                   var feature = ctx.GetFeature<IHttpConnectionFeature>();
                   await ctx.Response.WriteAsync("Hello Diagnostics test from " +  feature.RemoteIpAddress);
               });
            });

            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }
    }
}
