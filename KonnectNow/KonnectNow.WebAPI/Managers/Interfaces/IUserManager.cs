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
         /// <summary>
        /// Registers user in the konnect now system
        /// </summary>
        /// <param name="userCommandModel">UserCommandModel Object</param>
        /// <param name="validationCode">ValidationCode Object</param>
        /// <returns></returns>        
        ModelManagerResult<CreateUserViewModel> RegisterUser(UserCommandModel userCommandModel, out string validationCode);

        /// <summary>
        /// sends verification code to mobile
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        ///  <param name="message">Message</param>
        void SendVerificationCode(string mobileNo, string message);
    }
}
