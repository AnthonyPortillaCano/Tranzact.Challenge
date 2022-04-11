using Challenge.Services.Interfaces;
using Challenge.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Caching;
using Challenge.WebApi.Util;
using Challenge.Data.Context;
using Challenge.Data.Interfaces;
using Challenge.External.Interfaces;
using Challenge.Data.Repositories;
using Challenge.External.Implementations;
using Microsoft.EntityFrameworkCore;
using Challenge.WebApi.Models;
using Challenge.External.Models;

namespace Challenge.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<StoreDatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:StoreDatabase"]));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IExternalProxy, ExternalProxy>();

            return services;
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCORS", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();
                });
            });
        }

        public static void SetInvalidModel(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var response = new ResponseEntity<String>();
                    response.code = context.HttpContext.Response.StatusCode;
                    response.status = false;
                    response.message = "Contact the system administrator";
                    response.messageException = "Error 400: bad request";
                    response.result = null;

                    return new BadRequestObjectResult(response)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
        }

        public static void SetCache(this IServiceCollection services)
        {
            ObjectCache cache = MemoryCache.Default;
            List<ProductType> productTypes = (List<ProductType>)cache["ProductTypes"];

            if (productTypes == null)
            {
                cache.Set("ProductTypes", ProductTypeList.GetList(), new DateTimeOffset(DateTime.Now.AddMinutes(30)));
            }
        }
    }
}
