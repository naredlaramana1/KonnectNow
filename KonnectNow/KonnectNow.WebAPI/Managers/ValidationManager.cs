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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validationRepository">IValidationRepository object</param>
        public ValidationManager(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        /// <summary>
        /// Gets validation code based on the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="isDuplicate">Is Duplicate</param>
        /// <returns>Validation code</returns>
        public string GetValidationCode(string mobileNo,out bool isDuplicate)
        {
            isDuplicate = false;
            //if active validation code exist throw an exception
            var item = _validationRepository.Get(e => e.MobileNo == mobileNo && e.StartDate >= DateTime.Now);
            if (item != null)
            {
                isDuplicate = true;
                
            }
            string validationCode = RandomCodeGenerator.Instance.Generate();

            var validation = new Validation { ValidationCode = validationCode, MobileNo = mobileNo, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(Convert.ToDouble(1)) };
            if (_validationRepository.Insert(validation) <= 0)
                validationCode = string.Empty;

            return validationCode;
        }

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="mobileNo">MobileNo</param>
        /// <param name="validationCode">validation code</param>
        /// <returns>Boolean</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> VerifyValidationCode(string mobileNo, string validationCode)
        {
            return CheckValidationCode(mobileNo, validationCode);
        }

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="mobileNo">MobileNo</param>
        /// <param name="validationCode">validation code</param>
        /// <returns>Boolean</returns>
        public ModelManagerResult<bool> CheckValidationCode(string mobileNo, string validationCode)
        {
            Validation validation = _validationRepository.Get(e => e.ValidationCode == validationCode &&
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
    }

}