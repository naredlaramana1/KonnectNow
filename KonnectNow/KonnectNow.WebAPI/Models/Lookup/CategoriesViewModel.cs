using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Categories View Model
    /// </summary>
    public class CategoriesViewModel
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public long CatId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string CatName { get; set; }
       
    }
}