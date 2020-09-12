using System;
using System.Threading.Tasks;

namespace BusinessRulesEngine.PartnerService
{
    public class PartnerService : IPartnerService
    {
        public async Task ActivateMembership()
        {
            Console.WriteLine("Membership activated!");
        }

        public async Task GenerateCommision()
        {
            Console.WriteLine("Commision Generated!");
        }

        public async Task GeneratePackingSlip()
        {
            Console.WriteLine("Packing slip generated!");
        }

        public async Task MakePayment()
        {
            Console.WriteLine("Payment successful!");
        }

        public async Task SendEmail()
        {
            Console.WriteLine("Email sent!");
        }

        public async Task UpgradeMembership()
        {
            Console.WriteLine("Membership upgraded!");
        }
    }
}
