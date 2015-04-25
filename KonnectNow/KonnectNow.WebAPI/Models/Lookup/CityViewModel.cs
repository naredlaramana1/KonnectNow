using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// City View Model Object
    /// </summary>
    public class CityViewModel
    {
        /// <summary>
        /// City Id
        /// </summary>
        public decimal CityId { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string CityName { get; set; }
    }
}