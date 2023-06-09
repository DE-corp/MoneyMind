using DAL_SQLLite;
using DAL_SQLLite.Models;
using DAL_SQLLite.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<CostsDbContext>();

        //builder.Services.AddIdentityCore<User>(opts =>
        //{
        //    opts.Password.RequiredLength = 5;
        //    opts.Password.RequireNonAlphanumeric = false;
        //    opts.Password.RequireLowercase = false;
        //    opts.Password.RequireUppercase = false;
        //    opts.Password.RequireDigit = false;
        //});

        builder.Services.AddTransient<IRepository<Category>,Repository<Category>>();
        builder.Services.AddTransient<IRepository<Spend>, Repository<Spend>>();


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}