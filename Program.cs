using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Context;

namespace WebApi {
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            try {
                using (var scope = host.Services.CreateScope()) {
                    var context = scope.ServiceProvider.GetRequiredService<WebApiContext>();
                    context.Database.Migrate();
                }
            } catch (Exception) {
                throw;
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
