using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Models
{
    public class PhysicalProduct : IProduct
    {
        /// <summary>
        /// Weight in grams
        /// </summary>
        public int Weight { get; set; }
    }
}
