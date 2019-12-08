using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using HotelInfo.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HotelInfo.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await WriteErrorContent(httpContext, ex);
            }
        }

        private async Task WriteErrorContent(HttpContext httpContext, Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var exMessage = "Something went wrong. Sorry for the inconvenience !!";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            if (ex is BaseException bex)
            {
                exMessage = bex.Message;
                httpContext.Response.StatusCode = bex.StatusCode;
            }

            var exceptionMessage = new { errorMessage = exMessage };
            var errorContent = JsonSerializer.Serialize(exceptionMessage);

            await httpContext.Response.WriteAsync(errorContent);
        }
    }
}
