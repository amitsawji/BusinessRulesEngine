using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.PaymentStrategy
{
    interface IPaymentStratgy
    {
        string ProcessPayment(IProduct product);
    }
}
