using BusinessRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.BusinessRules
{
    public class BookBusinessRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Book;

        public void Execute(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
