using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Cities View Model
    /// </summary>
    public class CitiesViewModel
    {

        /// <summary>
        /// City Id
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string CityName { get; set; }
    }
}