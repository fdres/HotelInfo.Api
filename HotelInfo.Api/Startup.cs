using System.Linq;
using AutoMapper;
using HotelInfo.Api.DAL.Contexts;
using HotelInfo.Api.DAL.Repository;
using HotelInfo.Api.Exceptions;
using HotelInfo.Api.Middlewares;
using HotelInfo.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errorMessage = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => e.Value.Errors.FirstOrDefault()?.ErrorMessage)
                        .FirstOrDefault() ?? "Bad Request. Erroneous model state";

                    throw new BadRequestException(errorMessage);
                };
            });

            var hotelDbConnectionString = Configuration.GetConnectionString("HotelsDBConnectionString");
            services.AddDbContext<HotelInfoContext>(options => { options.UseSqlServer(hotelDbConnectionString); });
            services.AddScoped<IHotelInfoRepository, HotelInfoRepository>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddAutoMapper(typeof(HotelInfoMappingProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseCustomExceptionHandling();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
