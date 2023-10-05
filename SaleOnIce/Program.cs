using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleOnIce;
using SaleOnIce.Repository;
using AutoMapper;
using SaleOnIce.Models; 
using SaleOnIce.Models.ViewModels.DTOs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services);

        builder.Services.AddSqlServer<SaleOnIceContext>(builder.Configuration.GetConnectionString("defaultConnection") );
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        var app = builder.Build();

        app.MapGet("/dbconexion", ([FromServices] SaleOnIceContext dbcontext) =>
        {
            dbcontext.Database.EnsureCreated();
            return Results.Ok("Database has correct conection");
        });

        app.MapControllerRoute(
             name: "default",
            pattern: "{controller}/{action}/{id?}");

        app.MapFallbackToFile("index.html");

        startup.ConfigureMiddlewares(app, app.Environment);

        app.Run();
    }
}