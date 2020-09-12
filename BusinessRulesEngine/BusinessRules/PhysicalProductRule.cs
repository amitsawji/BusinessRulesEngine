﻿using BusinessRulesEngine.Models;
using System;

namespace BusinessRulesEngine.BusinessRules
{
    public class PhysicalProductRule : IProductBusinessRule
    {
        public ProductType ProductType => ProductType.PhysicalProduct;
        int gstPercentage = 12;
        int commistionPercentage = 5;

        public void Execute(IProduct product)
        {
            if (product == null) throw new ArgumentNullException();
            
            //There is a better way to do this by injecting the services which facilitate packing slip generation
            //and payment. However it is out of scope for this assessment.

            product.FinalPrice = product.Price + (product.Price * gstPercentage) / 100;

            Console.WriteLine($"Packing Slip generated for product -{product.ProductName}");

            var commision = (product.Price * commistionPercentage) / 100;

            Console.WriteLine($"Payment of {commision} was sent to Agent");
        }
    }
}
