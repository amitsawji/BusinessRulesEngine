using BusinessRulesEngine.Models;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class PhysicalProductRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.PhysicalProduct;

        public void Execute(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
