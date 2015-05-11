using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KonnectNow.WebAPI.Controllers
{
    /// <summary>
    /// Manages  user retaled operations
    /// </summary>
    public class UsersController : KNBaseController
    {
        private readonly IUserManager _userManager;
        private readonly IValidationManager _validationManager;
        /// <summary>
        /// Constructor for UsersController.
        /// </summary>
        /// <param name="userManager">IUserManager object</param>
        /// <param name="validationManager">IValidationManager object</param>
        public UsersController(IUserManager userManager, IValidationManager validationManager)
        {
            _userManager = userManager;
            _validationManager = validationManager;
        }

        /// <summary>
        /// Register's a new user
        /// </summary>
        /// <param name="userCommandModel"></param>
        /// <returns>
        /// HTTP Status = 201,
        /// HTTP Status = 400 - {Code = 4009, Message = Mobile already registered},
        /// HTTP Status = 404 - {Code = 4006, Message = Country not found}
        /// HTTP Status = 400 - {Code = 4008, Message = Verification already issued, please check message}
        /// </returns>
        [HttpPost]
        [Route("Users/Register")]
        [ResponseType(typeof(CreateUserViewModel))]
        public HttpResponseMessage Register(UserCommandModel userCommandModel)
        {
            string validationCode = string.Empty;
            var result = _userManager.RegisterUser(userCommandModel, out validationCode);
            if (result.Status == ResponseCodes.OK)
            {
                _userManager.SendVerificationCode(userCommandModel.MobileNo, validationCode);
                return BuildSuccessResponse(HttpStatusCode.Created,result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Updates the user profile
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="updateUserCommandModel">UpdateUserCommandModel Object</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4012, Message = User not avialable},
        /// </returns>
        [HttpPut]
        [Route("Users/{userId}/Register")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateUser(int userId, UpdateUserCommandModel updateUserCommandModel)
        {
            var result = _userManager.UpdateUser(userId, updateUserCommandModel);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Returns user profile details for given mobile no.
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <returns> 
        ///  HTTP Status = 200 {UserViewModel}
        /// HTTP Status = 404 - {Code = 4011, Message = Mobile Not registered},
        /// </returns>
        [HttpGet]
        [Route("Users/Register/{mobileNo}/Profile")]
        [ResponseType(typeof(UserViewModel))]
        public HttpResponseMessage GetUserByMobileNo(string mobileNo)
        {
            var result = _userManager.GetUserByMobileNo(mobileNo);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Returns user profile details for given UserId.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns> 
        ///  HTTP Status = 200 {UserEditViewModel}
        /// HTTP Status = 404 - {Code = 4012, Message = User not avialable},
        /// </returns>
        [HttpGet]
        [Route("Users/{userId}")]
        [ResponseType(typeof(UserEditViewModel))]
        public HttpResponseMessage GetUserById(long userId)
        {
            var result = _userManager.GetUserById(userId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Verifies the verification code for user
        /// </summary>
        /// <param name="verificationCommandModel">VerificationCommandModel object</param>
        /// <returns>
        ///  HTTP Status = 200 - {Ok},
        ///  HTTP Status = 404 - {Code = 4010, Message = Verification code is either invalid or expired.},
        /// </returns>
        [HttpPost]
        [Route("Users/Verification")]
        public HttpResponseMessage Validate(VerificationCommandModel verificationCommandModel)
        {
            var result = _validationManager.VerifyVerificationCode(verificationCommandModel.MobileNo, verificationCommandModel.VerificationCode);
            if (result.Status == ResponseCodes.OK)
            {
                
                return BuildSuccessResponse(HttpStatusCode.OK);
            }
            return BuildErrorResponse(result.Status);
        }

        /// <summary>
        /// Resends verification code being sent to user mobile
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <returns>
        /// HTTP Status = 200 - {Ok},
        /// HTTP Status = 404 - {Code = 4011, Message = Mobile Not registered},
        /// </returns>
        [HttpPost]
        [Route("Users/{mobileNo}/Verification")]
        public HttpResponseMessage ResendVerification(string mobileNo)
        {
            var result = _validationManager.ResendVerificationCode(mobileNo);
            if (result.Status == ResponseCodes.OK)
            {

                _userManager.SendVerificationCode(mobileNo, result.Value);
                return BuildSuccessResponse(HttpStatusCode.OK);
            }
            return BuildErrorResponse(result.Status);
        }

        /// <summary>
        /// Updates the user profile
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="sellerProfileCommandModel">SellerProfileCommandModel Object</param>
        /// <returns>
        /// HTTP Status = 200,
        /// HTTP Status = 404 - {Code = 4012, Message = User not avialable},
        /// </returns>
        [HttpPost]
        [Route("Users/{userId}/Seller")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage SellerProfile(long userId, SellerProfileCommandModel sellerProfileCommandModel)
        {
            var result = _userManager.SellerProfile(userId, sellerProfileCommandModel);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK);
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Returns seller profile details for given userId
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns> 
        ///  HTTP Status = 200 {SellerViewModel}
        /// HTTP Status = 404 - {Code = 4011, Message = Mobile Not registered},
        /// </returns>
        [HttpGet]
        [Route("Users/{userId}/Seller")]
        [ResponseType(typeof(SellerViewModel))]
        public HttpResponseMessage GetSellerInfo(long userId)
        {
            var result = _userManager.GetSellerProfile(userId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Returns user validationcode for given mobile no.
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <returns> 
        ///  HTTP Status = 200 {string}
        /// HTTP Status = 404 - {Code = 4018, Message = Verification code not found"},
        /// </returns>
        [HttpGet]
        [Route("Users/{mobileNo}/ValidationCode")]
        [ResponseType(typeof(string))]
        public HttpResponseMessage GetValidationByMobileNo(string mobileNo)
        {
            var result = _userManager.GetValidationByMobileNo(mobileNo);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }
    }
}
