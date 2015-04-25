using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
   /// <summary>
    /// CityGeographyViewModel object
   /// </summary>
    public class CityGeographyViewModel
    {
        /// <summary>
        /// Longitude
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public decimal Latitude { get; set; }
    }
}