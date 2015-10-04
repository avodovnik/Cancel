using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using Microsoft.ApplicationInsights;

namespace Demo02.Diagnostics
{
    public class Startup
    {
        public Startup(IApplicationEnvironment appEvn)
        {
            var builder = new ConfigurationBuilder(appEvn.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .AddApplicationInsightsSettings(developerMode: true);
            
            Configuration = builder.Build();
            
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddApplicationInsightsTelemetry(Configuration);
        }

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseErrorHandler(a =>
            {
                a.UseMiddleware<ErrorMiddleware>();
            });

            app.UseWelcomePage("/welcome");
            app.UseRuntimeInfoPage("/runtimeinfo");


            //app.UseErrorPage();


            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("throw"))
                    throw new AggregateException("Some funny exception, 42");

                await context.Response.WriteAsync("Hello World!");
            });            
        }
    }

    public class ErrorMiddleware
    {
        RequestDelegate _next;
        ILogger _logger;

        public ErrorMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            _next = next;
            _logger = factory.CreateLogger<ErrorMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var errorFeature = context.GetFeature<IErrorHandlerFeature>();

            if(errorFeature.Error != null)
            {
                _logger.LogCritical("A critical exception occurred.", errorFeature.Error);
            } else
            {
                _logger.LogCritical("There was an error...");
            }

            //IErrorHandlerFeature
            context.Response.StatusCode = 200;
            
            // we're going to "short-circuit" the pipeline
            await context.Response.WriteAsync("There was an error . But it was logged.");            
        }
    }
}
