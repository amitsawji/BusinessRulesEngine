namespace BusinessRulesEngine.Models
{
    public class IProduct
    {
        /// <summary>
        /// Unique identifier for the product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Predefined product type from the enum
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Popular name for the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Net price of the product without any taxes or discounts
        /// </summary>
        public double Price { get; set; }
    }
}
