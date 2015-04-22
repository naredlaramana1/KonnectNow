using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// LocationViewModel object
    /// </summary>
    public class LocationViewModel
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