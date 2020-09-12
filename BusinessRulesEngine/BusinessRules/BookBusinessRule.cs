using BusinessRulesEngine.Models;
using System;


namespace BusinessRulesEngine.BusinessRules
{
    public class BookBusinessRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Book;

        public void Execute(IProduct product)
        {
            
        }
    }
}
