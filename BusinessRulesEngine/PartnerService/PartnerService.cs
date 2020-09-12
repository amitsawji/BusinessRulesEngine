using BusinessRulesEngine.ThirdPartyOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.PartnerService
{
    public class PartnerService : IPartnerService
    {
        public void ActivateMembership()
        {
            Console.WriteLine("Membership activated!");
        }

        public void GenerateCommision()
        {
            Console.WriteLine("Commision Generated!");
        }

        public void GeneratePackingSlip()
        {
            Console.WriteLine("Packing slip generated!");
        }

        public void MakePayment()
        {
            Console.WriteLine("Payment successful!");
        }

        public void SendEmail()
        {
            Console.WriteLine("Email sent!");
        }

        public void UpgradeMembership()
        {
            Console.WriteLine("Membership upgraded!");
        }
    }
}
