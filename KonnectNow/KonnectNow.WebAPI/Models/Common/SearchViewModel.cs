using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Common
{
    /// <summary>
    /// Search View Model
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// Page Number
        /// </summary>      
        public int Offset { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>      
        public int Limit { get; set; }

        /// <summary>
        /// Total
        /// </summary>      
        public int Total { get; set; }
    }
}