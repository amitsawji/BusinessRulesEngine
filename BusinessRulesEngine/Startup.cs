using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.PaymentStrategy;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductBusinessRule, PhysicalProductRule>();
            serviceCollection.AddScoped<IPaymentStratgy, PaymentStrategy.PaymentStrategy>();
        }
    }
}
