using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.PaymentStrategy
{
    interface IPaymentStratgy
    {
        void ProcessPayment(IProduct product);
    }
}
