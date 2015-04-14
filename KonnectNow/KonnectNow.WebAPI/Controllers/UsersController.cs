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
        /// 
        /// </summary>
        /// <param name="userCommandModel"></param>
        /// <returns>
        /// HTTP Status = 201 - {UserId},
        /// HTTP Status = 400 - {Code = 4009, Message = Mobile already registered},
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
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }
        /// <summary>
        /// Verifies the verification code being sent to user mobile
        /// </summary>
        /// <param name="verificationCommandModel">VerificationCommandModel object</param>
        /// <returns>
        ///  HTTP Status = 200 - {Ok},
        ///  HTTP Status = 404 - {Code = 40q0, Message = Verification code is either invalid or expired.},
        /// </returns>
        [HttpPost]
        [Route("Users/Validate")]
        public HttpResponseMessage Validate(VerificationCommandModel verificationCommandModel)
        {
            var result = _validationManager.VerifyValidationCode(verificationCommandModel.MobileNo, verificationCommandModel.VerificationCode);
            if (result.Status == ResponseCodes.OK)
            {
                
                return BuildSuccessResponse(HttpStatusCode.OK);
            }
            return BuildErrorResponse(result.Status);
        }
    }
}
