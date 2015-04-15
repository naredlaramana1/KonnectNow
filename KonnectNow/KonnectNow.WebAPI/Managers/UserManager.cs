using AutoMapper;
using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models;
using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.User;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages user account related operations
    /// </summary>
    public class UserManager : BaseModelManager, IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidationManager _validationManager;

        /// <summary>
        /// Constructor for UserManager.
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="validationManager">IValidationManager object</param>
        public UserManager(IUserRepository userRepository, IValidationManager validationManager)
        {
            _userRepository = userRepository;
            _validationManager = validationManager;

        }

        /// <summary>
        /// updates user profile
        /// </summary>
        /// <param name="userId">UserId Object</param>
        /// <param name="updateUserCommandModel">UpdateUserCommandModel Object</param>
       /// <returns></returns>
        [UnitOfWork]
        public ModelManagerResult<bool> UpdateUser(int userId,UpdateUserCommandModel updateUserCommandModel)
        {
            var user=_userRepository.GetByID(userId);
            if(user==null)
                return GetManagerResult<bool>(ResponseCodes.MOBILENO_NOT_FOUND);

            user.FirstName = updateUserCommandModel.FirstName;
            user.LastName = updateUserCommandModel.LastName;
            user.ProfilePic = updateUserCommandModel.ProfilePic;
           _userRepository.Update(user);
            return GetManagerResult(ResponseCodes.OK, true);
        }

       
        /// <summary>
        /// Registers user in the konnect now system
        /// </summary>
        /// <param name="userCommandModel">UserCommandModel Object</param>
        /// <param name="validationCode">ValidationCode Object</param>
        /// <returns></returns>
        [UnitOfWork]
        public ModelManagerResult<CreateUserViewModel> RegisterUser(UserCommandModel userCommandModel,out string validationCode)
        {
            validationCode = string.Empty;
            var useMobile = _userRepository.Get(x => x.MobileNo == userCommandModel.MobileNo).FirstOrDefault();
            if (useMobile!=null)
                return GetManagerResult<CreateUserViewModel>(ResponseCodes.MOBILE_ALREADY_REGISTERED);
            
            var user = Mapper.Map<UserCommandModel, User>(userCommandModel);           
            var a = _userRepository.Insert(user);

            if (a.UserId > 0)
            {
                bool isDuplicate = false;
                validationCode = _validationManager.GetVerificationCode(userCommandModel.MobileNo, out isDuplicate);
                if (isDuplicate)
                {
                    return GetManagerResult<CreateUserViewModel>(ResponseCodes.VERIFICATIONCODE_ALREADY_ACTIVE);
                }
            }
            return GetManagerResult(ResponseCodes.OK, new CreateUserViewModel { UserId = a.UserId });
            
        }

        /// <summary>
        /// sends verification code to mobile
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        ///  <param name="message">Message</param>
        public void SendVerificationCode(string mobileNo,string message)
        {
            string url = string.Format("http://www.jst.smsmobile.co.in/index.php/api/get-balance?username=Skathuroju&password=Weblabs@123&from=9912064674&to={0}&message={1}&sms_type=2", mobileNo, message);
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();
        }
    }
}