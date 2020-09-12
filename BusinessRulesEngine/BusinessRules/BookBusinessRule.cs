using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using System;


namespace BusinessRulesEngine.BusinessRules
{
    public class BookBusinessRule : IProductBusinessRule
    {
        IPartnerService _partnerService;

        public BookBusinessRule(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public ProductType ProductType => ProductType.Book;
        int gstPercentage = 0;
        int commistionPercentage = 5;

        public void Execute(IProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            product.FinalPrice = product.Price + (product.Price * gstPercentage) / 100;

            _partnerService.GeneratePackingSlip();
            _partnerService.GenerateCommision();
        }
    }
}
