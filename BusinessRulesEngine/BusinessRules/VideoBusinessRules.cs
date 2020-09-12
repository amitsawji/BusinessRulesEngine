using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class VideoBusinessRules : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Video;
        int gstPercentage = 0;
        IPartnerService _partnerService;

        public VideoBusinessRules(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public void Execute(IProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            product.FinalPrice = product.Price + (product.Price * gstPercentage) / 100;

            if (product.ProductName == "Learning To Ski")
            {
                _partnerService.GeneratePackingSlip();
            }
            _partnerService.GeneratePackingSlip();
        }
    }
}
