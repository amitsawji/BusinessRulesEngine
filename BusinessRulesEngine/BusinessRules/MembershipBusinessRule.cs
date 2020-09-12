using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class MembershipBusinessRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.Membership;
        IPartnerService _partnerService;
        int gstPercentage = 5;

        public MembershipBusinessRule(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public void Execute(IProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            var newProduct = (Membership)product;

            newProduct.FinalPrice = newProduct.Price + (newProduct.Price * gstPercentage) / 100;

            if (newProduct.IsUpgrade)
            {
                _partnerService.UpgradeMembership();
                _partnerService.SendEmail();
            }
            _partnerService.ActivateMembership();
            _partnerService.SendEmail();
        }
    }
}
