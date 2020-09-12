using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRulesEngine.PaymentStrategy
{
    public class PaymentStrategy : IPaymentStratgy
    {
        private readonly IEnumerable<IProductBusinessRule> _businessRules;

        public PaymentStrategy(IEnumerable<IProductBusinessRule> productBusinessRules)
        {
            _businessRules = productBusinessRules;
        }

        public string ProcessPayment(IProduct product)
        {
            var rule = _businessRules.FirstOrDefault(x=>x.ProductType == product.ProductType);
            if (rule == null) throw new ArgumentNullException(nameof(rule));
            rule.Execute(product);
            return rule.ProductType.ToString(); //Returning for console display.
        }
    }
}
