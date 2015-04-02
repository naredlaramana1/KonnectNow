using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}