namespace BusinessRulesEngine.ThirdPartyOperations
{
    /// <summary>
    /// Interface for handling thirt party operations. To keep this short,
    /// all methods are added in a single interface. 
    /// </summary>
    public interface IPartnerService
    {
        void GeneratePackingSlip();
        void ActivateMembership();
        void UpgradeMembership();
        void SendEmail();
        void GenerateCommision();
        void MakePayment();
    }
}
