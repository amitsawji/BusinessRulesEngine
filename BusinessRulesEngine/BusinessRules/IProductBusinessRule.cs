using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.BusinessRules
{
    public interface IProductBusinessRule
    {
        ProductType ProductType { get; }
        void Execute(IProduct product);
    }
}
