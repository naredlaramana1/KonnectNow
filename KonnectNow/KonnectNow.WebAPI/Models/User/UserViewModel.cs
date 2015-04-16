using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// UserViewModel Object
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// User ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Profile Pic
        /// </summary>
        public byte[] ProfilePic { get; set; }

        
    }
}