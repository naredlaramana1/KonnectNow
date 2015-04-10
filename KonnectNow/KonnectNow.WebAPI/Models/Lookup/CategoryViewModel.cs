using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// CategoryViewModel object
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public long CatId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string CatName { get; set; }


        /// <summary>
        /// is active or not
        /// </summary>
        public bool IsActive { get; set; }

      /// <summary>
      /// Created Date
      /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime ModifiedOn { get; set; }
    }
}