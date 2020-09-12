using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace BusinessRulesEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            InitializeProgram();
           
        }

        private static void InitializeProgram()
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
        }
    }
}
