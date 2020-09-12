using System.Threading.Tasks;

namespace BusinessRulesEngine.PartnerService
{
    /// <summary>
    /// Interface for handling thirt party operations. To keep this short,
    /// all methods are added in a single interface. 
    /// </summary>
    public interface IPartnerService
    {
        Task GeneratePackingSlip();
        Task ActivateMembership();
        Task UpgradeMembership();
        Task SendEmail();
        Task GenerateCommision();
        Task MakePayment();
    }
}
