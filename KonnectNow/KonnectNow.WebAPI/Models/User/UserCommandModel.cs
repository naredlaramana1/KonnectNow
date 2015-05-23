using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// User Command Model Object
    /// </summary>
    public class UserCommandModel
    {

        /// <summary>
        /// User First Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// User Last Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// CountryId
        /// </summary>
        [Required]
        public int CountryId { get; set; }

        /// <summary>
        /// Mobile No
        /// </summary>
        [Required]
        [Phone]
        public string MobileNo { get; set; }

        /// <summary>
        /// Device ID
        /// </summary>
         [Required]
         [StringLength(500)]
        public string DeviceId { get; set; }

         /// <summary>
         /// City Longitude
         /// </summary>
         [Required]
         public double Longitude { get; set; }

         /// <summary>
         /// City Latitude
         /// </summary>
         [Required]
         public double Latitude { get; set; }
    }
}