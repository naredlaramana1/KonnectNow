using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.WebAPI.Managers.Interfaces
{
    public  interface IUserManager
    {
        ModelManagerResult<CreateUserViewModel> CreateUser(UserCommandModel userCommandModel);
    }
}
