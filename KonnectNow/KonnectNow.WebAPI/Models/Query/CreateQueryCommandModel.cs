using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Query
{
    /// <summary>
    /// CreateQueryCommandModel Object
    /// </summary>
    public class CreateQueryCommandModel
    {
        /// <summary>
        /// Login User Id
        /// </summary>
        [Required]
        public decimal UserId { get; set; }

        /// <summary>
        /// Category Id
        /// </summary>
        [Required]
        public decimal CatId { get; set; }

        /// <summary>
        /// Query Text
        /// </summary>
        [Required]
        public string QueryText { get; set; }

        /// <summary>
        /// User Location Id
        /// </summary>
        
        public decimal? LocationId { get; set; }

        /// <summary>
        /// User Location Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// User Loaction Latitude
        /// </summary>
        public double Latitude { get; set; }
    }
}