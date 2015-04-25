using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// UpdateLocationCommandModel Object
    /// </summary>
    public class UpdateLocationCommandModel
    {
        /// <summary>
        /// Location Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }

        /// <summary>
        /// City Id
        /// </summary>
        [Required]
        public long CityId { get; set; }

        /// <summary>
        /// Location Longitude
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Location Latitude
        /// </summary>
        [Required]
        public double Latitude { get; set; }
    }
}