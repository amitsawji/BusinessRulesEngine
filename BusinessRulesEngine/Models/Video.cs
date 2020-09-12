using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Models
{
    public class Video: IProduct
    {
        /// <summary>
        /// Link for the video
        /// </summary>
        public Uri Link { get; set; }

        public string Title { get; set; }
    }
}
