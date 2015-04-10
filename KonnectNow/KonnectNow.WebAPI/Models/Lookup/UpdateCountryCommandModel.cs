using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// UpdateCountryCommandModel object
    /// </summary>
    public class UpdateCountryCommandModel
    {
        /// <summary>
        /// Country Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}