using BusinessRulesEngine.Models;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class VideoBusinessRules : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Video;

        public void Execute(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
