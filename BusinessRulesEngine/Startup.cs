using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.PartnerService;
using BusinessRulesEngine.PaymentStrategy;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductBusinessRule, PhysicalProductRule>();
            serviceCollection.AddScoped<IProductBusinessRule, BookBusinessRule>();
            serviceCollection.AddScoped<IProductBusinessRule, MembershipBusinessRule>();
            serviceCollection.AddScoped<IProductBusinessRule, VideoBusinessRules>();
            serviceCollection.AddScoped<IPartnerService, PartnerService.PartnerService>();
            serviceCollection.AddScoped<IPaymentStratgy, PaymentStrategy.PaymentStrategy>();
        }
    }
}
