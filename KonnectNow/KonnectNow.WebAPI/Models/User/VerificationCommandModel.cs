using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// VerificationCommandModel object
    /// </summary>
    public class VerificationCommandModel
    {
        /// <summary>
        /// User's Mobile Number
        /// </summary>
        [Required]
        [Phone]
        public string MobileNo { get; set; }

        /// <summary>
        /// Verification
        /// </summary>
        [Required]
        public string VerificationCode { get; set; }
    }
}