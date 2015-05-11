using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// SellerViewModel Obejct 
    /// </summary>
    public class SellerViewModel
    {
        /// <summary>
        /// Name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Phone number of the company
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// EmailId of the company
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Company Website URL 
        /// </summary>
        public string WebsiteUrl { get; set; }


        /// <summary>
        /// Longitude of the seller
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude of the seller
        /// </summary>

        public double Latitude { get; set; }

        /// <summary>
        ///Company  Pancard Number
        /// </summary>
        public string PanCardNo { get; set; }

        /// <summary>
        ///Company Description
        /// </summary>      
        public string Description { get; set; }

        /// <summary>
        /// Auro Response
        /// </summary>
        public string AutoReponse { get; set; }

        /// <summary>
        /// Response Status
        /// </summary>
        public bool ResponseStatus { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        public string KeyWords { get; set; }



    }
}