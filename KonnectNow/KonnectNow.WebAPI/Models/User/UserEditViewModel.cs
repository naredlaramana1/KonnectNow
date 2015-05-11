using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.User
{
    /// <summary>
    /// UserEditViewModel Object
    /// </summary>
    public class UserEditViewModel
    {
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