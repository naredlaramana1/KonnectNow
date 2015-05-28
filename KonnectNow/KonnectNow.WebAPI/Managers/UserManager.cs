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
using System;
using KonnectNow.Common.Logging;
using System.Configuration;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages user account related operations
    /// </summary>
    public class UserManager : BaseModelManager, IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidationManager _validationManager;
        private readonly ICountryRepository _countryRepository;
        private readonly ISellerRepository _sellerRepository;
        /// <summary>
        /// Constructor for UserManager.
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="validationManager">IValidationManager object</param>
        /// <param name="countryRepository">ICountryRepository object</param>
        ///  <param name="sellerRepository">ISellerRepository object</param>
        public UserManager(IUserRepository userRepository,
                           IValidationManager validationManager, 
                           ICountryRepository countryRepository, 
                           ISellerRepository sellerRepository)
        {
            _userRepository = userRepository;
            _validationManager = validationManager;
            _countryRepository = countryRepository;
            _sellerRepository = sellerRepository;

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
                return GetManagerResult<bool>(ResponseCodes.USER_NOT_FOUND);

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
                return GetManagerResult(ResponseCodes.OK, new CreateUserViewModel { UserId = Convert.ToInt64(useMobile.UserId) });
            //return GetManagerResult<CreateUserViewModel>(ResponseCodes.MOBILE_ALREADY_REGISTERED);
            if(_countryRepository.GetByID(userCommandModel.CountryId)==null)
                return GetManagerResult<CreateUserViewModel>(ResponseCodes.COUNTRY_NOT_FOUND);
            var user = Mapper.Map<UserCommandModel, User>(userCommandModel);
            user.IsVerified = false;
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
            return GetManagerResult(ResponseCodes.OK, new CreateUserViewModel { UserId =Convert.ToInt64(a.UserId) });
            
        }

        /// <summary>
        /// Returns user profile based on mobile number
        /// </summary>
        /// <param name="mobileNo"Mobile No></param>
        /// <returns></returns>
        public ModelManagerResult<UserViewModel> GetUserByMobileNo(string mobileNo)
        {
             var useMobile = _userRepository.Get(x => x.MobileNo == mobileNo).FirstOrDefault();
             if (useMobile == null)
                 return GetManagerResult<UserViewModel>(ResponseCodes.MOBILENO_NOT_FOUND);
             else
                 return GetManagerResult<UserViewModel>(ResponseCodes.OK, Mapper.Map<User, UserViewModel>(useMobile));

        }

        /// <summary>
        /// Returns user profile based on mobile number
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        public ModelManagerResult<UserEditViewModel> GetUserById(long userId)
        {
            var user= _userRepository.GetByID(userId);
            if (user == null)
                return GetManagerResult<UserEditViewModel>(ResponseCodes.USER_NOT_FOUND);
             else
                return GetManagerResult<UserEditViewModel>(ResponseCodes.OK, Mapper.Map<User, UserEditViewModel>(user));

        }
        

        /// <summary>
        /// Returns user profile based on mobile number
        /// </summary>
        /// <param name="mobileNo">Mobile No></param>
        /// <returns></returns>
        public ModelManagerResult<string> GetValidationByMobileNo(string mobileNo)
        {
            var validationCode = _validationManager.ValidationCode(mobileNo);
            if (validationCode == string.Empty)
                return GetManagerResult<string>(ResponseCodes.VERIFICATION_CODE_NOT_EXIST);
            else
                return GetManagerResult<string>(ResponseCodes.OK, validationCode);

        }

        /// <summary>
        /// sends verification code to mobile
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        ///  <param name="message">Message</param>
        public void SendVerificationCode(string mobileNo,string message)
        {
            try
            {
                string smsUrl = ConfigurationManager.AppSettings["SMSURL"].ToString();
                string url = string.Format(smsUrl, mobileNo, "Please use the code " + message + " to verify your account.");

                // Set the 'Timeout' property in Milliseconds.           
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 30000;
                WebResponse myWebResponse = request.GetResponse();
            }
            catch (Exception ex)
            {
                Logger.Instance.Log("Error", ex);
            }
        }


        /// <summary>
        /// Modifies the seller profile 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="sellerProfileCommandModel">SellerProfileCommandModel Object</param>        
        /// <returns></returns>
        [UnitOfWork]
        public ModelManagerResult<bool> SellerProfile(long userId, SellerProfileCommandModel sellerProfileCommandModel)
        {
            if (_userRepository.GetByID(userId) == null)
                return GetManagerResult<bool>(ResponseCodes.USER_NOT_FOUND);
            var seller = _sellerRepository.Get(x => x.UserId == userId).FirstOrDefault();
            if (seller != null)
            {
               
                seller.AutoReponse= sellerProfileCommandModel.AutoReponse;
                seller.CompanyName=sellerProfileCommandModel.CompanyName;
                seller.Description=sellerProfileCommandModel.Description;
                seller.EmailId = sellerProfileCommandModel.EmailId;
                seller.UserId = userId;
                seller.CatId = sellerProfileCommandModel.CatId;
                seller.KeyWords = sellerProfileCommandModel.KeyWords;
                seller.Latitude = sellerProfileCommandModel.Latitude;
                seller.Longitude = sellerProfileCommandModel.Longitude;
                seller.PanCardNo = sellerProfileCommandModel.PanCardNo;
                seller.PhoneNumber = sellerProfileCommandModel.PhoneNumber;
                seller.ResponseStatus = sellerProfileCommandModel.ResponseStatus;
                seller.WebsiteUrl = sellerProfileCommandModel.WebsiteUrl;
                seller.ModifiedOn = null;
                _sellerRepository.Update(seller);
            }
            else
            {
                seller= Mapper.Map<SellerProfileCommandModel, Seller>(sellerProfileCommandModel);
                seller.UserId = userId;
                _sellerRepository.Insert(seller);
            }
            return GetManagerResult<bool>(ResponseCodes.OK, true);
           

        }

        /// <summary>
        /// Returns seller profile details for given userId
        /// </summary>
        /// <param name="userId">Usr Id</param>
        /// <returns></returns>
        public ModelManagerResult<SellerViewModel> GetSellerProfile(long userId)
        {

           
            if (_userRepository.GetByID(userId) == null)
                return GetManagerResult<SellerViewModel>(ResponseCodes.USER_NOT_FOUND);
            var seller = _sellerRepository.Get(x => x.UserId == userId).FirstOrDefault();
            if (seller != null)
            {
                return GetManagerResult<SellerViewModel>(ResponseCodes.OK, Mapper.Map<Seller, SellerViewModel>(seller));                
            }
else
                return GetManagerResult<SellerViewModel>(ResponseCodes.OK, new SellerViewModel());


        }
    }
}