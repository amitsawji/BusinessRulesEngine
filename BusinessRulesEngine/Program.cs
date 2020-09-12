using BusinessRulesEngine.Models;
using BusinessRulesEngine.PaymentStrategy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace BusinessRulesEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", true, true);
            })
            .UseEnvironment(Environments.Development)
            .ConfigureServices((services) =>
            {
                Startup.ConfigureServices(services);
            })
            .Build();

            var products = GenerateTestData();

            var paymentService = builder.Services.GetRequiredService<IPaymentStratgy>();

            foreach (var product in products)
            {
                var result = paymentService.ProcessPayment(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Product Type = {product.ProductType} - BusinessRule - {result}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static List<IProduct> GenerateTestData()
        {
            return new List<IProduct>
            {
             new Book {AuthorName ="John Doe", Price = 100, ProductType = ProductType.Book },
             new PhysicalProduct {ProductName = "Laptop", Price = 45000,ProductType = ProductType.PhysicalProduct },
             new Video {Title = "Learning To Ski", Price = 50, ProductType = ProductType.Video },
             new Membership {ProductName = "Netflix", IsUpgrade = true, Price = 800, ProductType = ProductType.Membership }
            };
        }
    }
}
