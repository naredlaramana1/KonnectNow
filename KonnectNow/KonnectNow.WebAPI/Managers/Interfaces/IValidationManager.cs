using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.WebAPI.Managers.Interfaces
{

    /// <summary>
    /// Provides account validation related operations
    /// </summary>
    public interface IValidationManager
    {
       /// <summary>
        /// Gets verification code based on the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="isDuplicate">Is Duplicate</param>
        /// <returns>VerificationCode</returns>
        string GetVerificationCode(string mobileNo, out bool isDuplicate);

        /// <summary>
        /// Verifies the verification code
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="verificationCode">Verification Code</param>
        /// <returns>Boolean</returns>
        ModelManagerResult<bool> VerifyVerificationCode(string mobileNo, string verificationCode);

        /// <summary>
        /// Verifies the verification code
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="verificationCode">Verification Code</param>
        /// <returns>Boolean</returns>
        ModelManagerResult<bool> CheckVerificationCode(string mobileNo, string verificationCode);

        /// <summary>
        /// Resends verification code to the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>      
        /// <returns>VerificationCode</returns>
        ModelManagerResult<string> ResendVerificationCode(string mobileNo);
    }
}
