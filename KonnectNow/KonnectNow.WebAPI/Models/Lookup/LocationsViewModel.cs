using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// LocationsViewModel
    /// </summary>
    public class LocationsViewModel
    {
        /// <summary>
        /// Location Id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// Location Name
        /// </summary>
        public string LocationName { get; set; }
    }
}