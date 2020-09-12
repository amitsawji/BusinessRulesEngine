using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Models
{
    public class Membership : IProduct
    {
        /// <summary>
        /// flag for setting upgrade
        /// </summary>
        public bool IsUpgrade { get; set; }

        /// <summary>
        /// Membership provider e.g. Amazon, Netflix etc
        /// </summary>
        public string Provider { get; set; }

        public string MemberEmail { get; set; }
    }
}
