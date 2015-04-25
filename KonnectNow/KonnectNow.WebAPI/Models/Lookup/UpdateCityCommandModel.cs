using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
   /// <summary>
    /// UpdateCityCommandModel object
   /// </summary>
    public class UpdateCityCommandModel
    {
        /// <summary>
        /// City Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        /// <summary>
        /// City Longitude
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// City Latitude
        /// </summary>
        [Required]
        public double Latitude { get; set; }
    }
}