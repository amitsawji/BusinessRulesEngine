using BusinessRulesEngine.Models;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class MembershipBusinessRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Membership;

        public void Execute(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
