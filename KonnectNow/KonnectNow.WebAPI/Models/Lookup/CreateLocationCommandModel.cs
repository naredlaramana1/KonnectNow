using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// CreateLocationCommandModel
    /// </summary>
    public class CreateLocationCommandModel
    {
        /// <summary>
        /// Location Name
        /// </summary>
        [Required]
        [StringLength(150)]
        public string LocationName { get; set; }

        /// <summary>
        /// City Id
        /// </summary>
        [Required]
        public int CityId { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        [Required]
        public double Latitude { get; set; }
    }
}