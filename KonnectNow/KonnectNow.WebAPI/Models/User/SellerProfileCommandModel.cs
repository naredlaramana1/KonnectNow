using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// SellerProfileCommandModel 
    /// </summary>
    public class SellerProfileCommandModel
    {

        /// <summary>
        /// Name of the company
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Phone number of the company
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// EmailId of the company
        /// </summary>
        [Required]
        [StringLength(250)]
        [EmailAddress]
        public string EmailId { get; set; }

        /// <summary>
        /// Company Website URL 
        /// </summary>
        [StringLength(50)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Longitude of the seller
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude of the seller
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        ///Company  Pancard Number
        /// </summary>
        [StringLength(15)]
        public string PanCardNo { get; set; }

        /// <summary>
        ///Company Description
        /// </summary>
        [StringLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// Auro Response
        /// </summary>
        [StringLength(250)]
        public string AutoReponse { get; set; }

        /// <summary>
        /// Response Status
        /// </summary>
        public bool ResponseStatus { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        [StringLength(500)]
        public string KeyWords { get; set; }

        /// <summary>
        /// seller category id
        /// </summary>
        [Required]
        public long CatId { get; set; }

        /// <summary>
        /// Profile Pic
        /// </summary>
        public byte[] ProfilePic { get; set; }
    }
}