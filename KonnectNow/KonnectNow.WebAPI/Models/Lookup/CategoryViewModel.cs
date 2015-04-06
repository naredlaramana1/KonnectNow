using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Category View Model
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public decimal CatId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string CatName { get; set; }
       
    }
}