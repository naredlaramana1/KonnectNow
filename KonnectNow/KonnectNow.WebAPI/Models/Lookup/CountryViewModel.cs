using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
    /// <summary>
    /// Country View Model object
    /// </summary>
    public class CountryViewModel
    {
         /// <summary>
        /// Country Id
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Is Active or Not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Created On
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Modified On
        /// </summary>
        public DateTime ModifiedOn { get; set; }


    }
}