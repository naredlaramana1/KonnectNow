using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.WebAPI.Managers.Interfaces
{
    /// <summary>
    /// This interface must be implemented by all user related business operations.
    /// </summary>
    public interface IUserManager
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

        /// <summary>
        /// updates user profile
        /// </summary>
        /// <param name="userId">UserId Object</param>
        /// <param name="updateUserCommandModel">UpdateUserCommandModel Object</param>
        /// <returns></returns>
        ModelManagerResult<bool> UpdateUser(int userId, UpdateUserCommandModel updateUserCommandModel);

           /// <summary>
        /// Returns user profile based on mobile number
        /// </summary>
        /// <param name="mobileNo"Mobile No></param>
        /// <returns></returns>
        ModelManagerResult<UserViewModel> GetUserByMobileNo(string mobileNo);

         /// <summary>
        /// Modifies the seller profile 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="sellerProfileCommandModel">SellerProfileCommandModel Object</param>        
        /// <returns></returns>        
        ModelManagerResult<bool> SellerProfile(long userId, SellerProfileCommandModel sellerProfileCommandModel);

                /// <summary>
        /// Returns seller profile details for given userId
        /// </summary>
        /// <param name="userId">Usr Id</param>
        /// <returns></returns>
        ModelManagerResult<SellerViewModel> GetSellerProfile(long userId);


            /// <summary>
        /// Returns user profile based on mobile number
        /// </summary>
        /// <param name="mobileNo">Mobile No></param>
        /// <returns></returns>
        ModelManagerResult<string> GetValidationByMobileNo(string mobileNo);
    }
}
