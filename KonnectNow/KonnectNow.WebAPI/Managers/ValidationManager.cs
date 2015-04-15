using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{

    /// <summary>
    ///  Provides account validation related operations
    /// </summary>
    public class ValidationManager : BaseModelManager, IValidationManager
    {
        private readonly IValidationRepository _validationRepository;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validationRepository">IValidationRepository object</param>
        /// <param name="userRepository">IUserRepository object</param>
        public ValidationManager(IValidationRepository validationRepository,IUserRepository userRepository)
        {
            _validationRepository = validationRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets verification code based on the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="isDuplicate">Is Duplicate</param>
        /// <returns>VerificationCode</returns>
        public string GetVerificationCode(string mobileNo,out bool isDuplicate)
        {
            isDuplicate = false;
            //if active validation code exist throw an exception
            var item = _validationRepository.Get(e => e.MobileNo == mobileNo && e.StartDate >= DateTime.Now);
            if (item != null)
            {
                isDuplicate = true;
                
            }
            string verificationCode = RandomCodeGenerator.Instance.Generate();

            var validation = new Validation { ValidationCode = verificationCode, MobileNo = mobileNo, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(Convert.ToDouble(1)) };
            if (_validationRepository.Insert(validation) <= 0)
                verificationCode = string.Empty;

            return verificationCode;
        }

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="mobileNo">MobileNo</param>
        /// <param name="verificationCode">Verification Code</param>
        /// <returns>Boolean</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> VerifyVerificationCode(string mobileNo, string verificationCode)
        {
            return CheckVerificationCode(mobileNo, verificationCode);
        }

        /// <summary>
        /// Verifies the verification code
        /// </summary>
        /// <param name="mobileNo">MobileNo</param>
        /// <param name="verificationCode">Verification Code</param>
        /// <returns>Boolean</returns>
        public ModelManagerResult<bool> CheckVerificationCode(string mobileNo, string verificationCode)
        {
            Validation validation = _validationRepository.Get(e => e.ValidationCode == verificationCode &&
                                                                 e.MobileNo== mobileNo &&
                                                                 e.EndDate >= DateTime.Now).FirstOrDefault();
            if (validation != null)
            {
                validation.EndDate = DateTime.Now;
                _validationRepository.Update(validation);
                return GetManagerResult<bool>(ResponseCodes.OK);
            }
            return GetManagerResult<bool>(ResponseCodes.VERIFICATION_CODE_NOTFOUND);
        }


        /// <summary>
        /// Gets verification code based on the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>      
        /// <returns>VerificationCode</returns>
        [UnitOfWork]
        public ModelManagerResult<string> ResendVerificationCode(string mobileNo)
        {
            var user = _userRepository.Get(x => x.MobileNo == mobileNo).FirstOrDefault();
            if(user==null)
                return GetManagerResult<string>(ResponseCodes.MOBILENO_NOT_FOUND);
            //if active validation code exist throw an exception
            var validation = _validationRepository.Get(e => e.MobileNo == mobileNo).FirstOrDefault();
            string verificationCode = RandomCodeGenerator.Instance.Generate();
            if (validation != null)
            {
                validation.ValidationCode = verificationCode;
               validation.StartDate = DateTime.Now;
               validation.EndDate = DateTime.Now.AddDays(Convert.ToDouble(1));

            }
            else
            {
                validation = new Validation { ValidationCode = verificationCode, MobileNo = mobileNo, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(Convert.ToDouble(1)) };
            }
           

            
            if (_validationRepository.Insert(validation) <= 0)
                verificationCode = string.Empty;

            return GetManagerResult<string>(ResponseCodes.OK, verificationCode);
        }
    }

}