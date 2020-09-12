using BusinessRulesEngine.Models;

namespace BusinessRulesEngine.BusinessRules
{
    /// <summary>
    /// Interface for executing businessrules. Any new business rule should
    /// implement this business rule and provide their own implementation
    /// </summary>
    public interface IProductBusinessRule
    {
        /// <summary>
        /// Product Type enum
        /// </summary>
        ProductType ProductType { get; }

        /// <summary>
        /// Execute method. Each businessrule can implement their own logic
        /// </summary>
        /// <param name="product"></param>
        void Execute(IProduct product);
    }
}
