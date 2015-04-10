using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// CreateCountryCommandModel Object
    /// </summary>
    public class CreateCountryCommandModel
    {
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}