using Microsoft.OpenApi.Models;
using SaleOnIce.Repository;
using SaleOnIce.Services;
using AutoMapper;
using SaleOnIce.Models;
using SaleOnIce.Models.ViewModels.DTOs;

using System.Text.Json.Serialization;

namespace SaleOnIce
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(
                x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
          

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IPurchaseRepository,PurchaseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped <IProductServices, ProductServices>();
            services.AddScoped <IPurchaseServices, PurchaseServices>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(contact =>
            contact.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "SaleOnICe",
                Description = " This is an api that controls a trading system e comerceotn for a field hockey store. ",
            })

             );
          
        }

        public void ConfigureMiddlewares(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
                app.UseSwagger(x =>
                {
                    x.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        swagger.Servers = new List<OpenApiServer> {
                            new OpenApiServer {
                                Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/"
                            }
                        };
                    });
                });
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 SaleOnIce");
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Add services to the container.

        //    builder.Services.AddControllersWithViews();

        //

        //        // Test conexion from a database in memory
        //        //builder.Services.AddDbContext<SaleOnIceContext>(x => x.UseInMemoryDatabase("SaleOnIceDB"));

        //        var app = builder.Build();

        ////app.MapGet("/dbconexion",([FromServices] SaleOnIceContext dbContext) =>
        ////{
        ////    dbContext.Database.EnsureCreated();
        ////    return Results.Ok("Database stored correctly ");
        ////});

        //// Configure the HTTP request pipeline.

        //
        //    }
    }
}