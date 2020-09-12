using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class PhysicalProductRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.PhysicalProduct;
        int gstPercentage = 12;
        IPartnerService _partnerService;

        public PhysicalProductRule(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public void Execute(IProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            product.FinalPrice = product.Price + (product.Price * gstPercentage) / 100;

            _partnerService.GeneratePackingSlip();
            _partnerService.GenerateCommision();
        }
    }
}
