using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// CategoryCommandModel object
    /// </summary>
    public class CategoryCommandModel
    {
        /// <summary>
        /// Category Name
        /// </summary>
        [Required]
        [StringLength(500)]
        public string CatName { get; set; }

    }
}