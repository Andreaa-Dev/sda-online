using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        // ILogger

        // constructor 
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        //method
        // print request + response information
        public async Task InvokeAsync(HttpContext context)
        {

            // request
            _logger.LogInformation($"Incoming request: {context.Request.Method} , {context.Request.Path}");


            // measure  how long request
            var stopwatch = Stopwatch.StartNew();

            // server - hang
            await _next(context);

            stopwatch.Stop();

            // response
            _logger.LogInformation($"Outgoing request: {context.Response.StatusCode} takes ({stopwatch.ElapsedMilliseconds}ms)");

        }



    }
}