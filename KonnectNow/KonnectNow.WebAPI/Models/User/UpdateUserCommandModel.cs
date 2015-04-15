using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// UpdateUserCommandModel Object
    /// </summary>
    public class UpdateUserCommandModel
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
        /// Profile Pic
        /// </summary>
        public byte[] ProfilePic { get; set; }
    } 
}