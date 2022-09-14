using HotelInfo.Api.DAL.Contexts;
using HotelInfo.Api.DAL.Repository;
using HotelInfo.Api.Exceptions;
using HotelInfo.Api.Middlewares;
using HotelInfo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelInfo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errorMessage = actionContext.ModelState
                        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                        .Select(e => e.Value.Errors.FirstOrDefault()?.ErrorMessage)
                        .FirstOrDefault() ?? "Bad Request. Erroneous model state";

                    throw new BadRequestException(errorMessage);
                };
            });

            var hotelDbConnectionString = Configuration.GetConnectionString("HotelsDBConnectionString");
            services.AddDbContext<HotelInfoContext>(options =>
            {
                options.UseSqlServer(hotelDbConnectionString);
            });
            services.AddScoped<IHotelInfoRepository, HotelInfoRepository>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddAutoMapper(typeof(HotelInfoMappingProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandling();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
