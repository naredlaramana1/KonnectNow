using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Countries View Model Object
    /// </summary>
    public class CountriesViewModel
    {
        /// <summary>
        /// Country Id
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }
       
    }
}