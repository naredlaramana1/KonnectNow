using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Country View Model
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Country Id
        /// </summary>
        public decimal CountryId { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }
       
    }
}