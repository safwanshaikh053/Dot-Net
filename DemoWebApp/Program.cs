using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EmpDbContext>(options => {
                options.UseSqlServer("name = conStr");
            }); //Provider

            var app = builder.Build();


            //Middlwares
            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
