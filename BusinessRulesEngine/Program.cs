using BusinessRulesEngine.Models;
using BusinessRulesEngine.PaymentStrategy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            var product = new Book { AuthorName = "John Doe", Genre = "Thriller", ProductName = "Murder Mystery", ProductType = ProductType.Book };

            var paymentService = builder.Services.GetRequiredService<IPaymentStratgy>();
            paymentService.ProcessPayment(product);

        }
    }
}
