using KonnectNow.WebAPI.Models;
using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{
    public interface IUserManager
    {
        ModelManagerResult<UserListViewModel> GetUsers();
        ModelManagerResult<CreateUserViewModel> CreateUser(UserCommandModel userCommandModel);

    }
}