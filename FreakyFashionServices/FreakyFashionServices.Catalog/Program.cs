using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashionServices.Catalog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FreakyFashionServices.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connection = configuration.GetConnectionString("FreakyFashionServicesBasketDatabase");
            var options = new DbContextOptionsBuilder<FreakyFashionServicesBasketContext>()
                                .UseSqlServer(new SqlConnection(connection))
                                .Options;

            //seed db
            using (var context = new FreakyFashionServicesBasketContext(options))
            {
                context.Database.EnsureCreated();

                var testItems = context.Items.FirstOrDefault(items => items.Id == 1);
                if (testItems == null)
                {
                    context.Items.Add(new Items { Name = "Freaky Jeans", Description = "lorem ipsum dolor", Price = 60, AvailableStock = 21 });
                    context.Items.Add(new Items { Name = "Luxury Blouse", Description = "lorem ipsum dolor", Price = 25, AvailableStock = 13 });
                    context.Items.Add(new Items { Name = "Amazing Hoodie", Description = "lorem ipsum dolor", Price = 80, AvailableStock = 20 });
                    context.Items.Add(new Items { Name = "Super Cap", Description = "lorem ipsum dolor", Price = 15, AvailableStock = 10 });
                    context.Items.Add(new Items { Name = "Great T-Shirt", Description = "lorem ipsum dolor", Price = 19, AvailableStock = 9 });
                }
                context.SaveChanges();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
