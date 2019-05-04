using Microsoft.AspNetCore.Builder;

namespace HotelInfo.Api.Middlewares
{
    public static class Extensions
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
