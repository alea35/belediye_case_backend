using Microsoft.AspNetCore.Identity;
using TestCaseWebApp.Utils;

namespace TestCaseWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient("general", (serviceProvider, httpClient) =>
            {
                httpClient.DefaultRequestHeaders.Add("Bearer", GlobalData.Instance.JWTToken);
                httpClient.BaseAddress = new Uri("http://localhost:5189/api/");
            });
            builder.Services.AddHttpClient<GlobalService>((serviceProvider, httpClient) =>
            {
                httpClient.DefaultRequestHeaders.Add("Bearer", GlobalData.Instance.JWTToken);
                httpClient.BaseAddress = new Uri("http://localhost:5189/api/");
            });
    
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                   name: "login",
                   pattern: "login",
                   defaults: new { controller = "Auth", action = "Login" }
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });

            app.Run();
        }
    }
}