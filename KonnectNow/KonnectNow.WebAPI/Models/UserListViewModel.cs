using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            Users = new List<UserViewModel>();

        }
        public IList<UserViewModel> Users { get; set; }
    }
}