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
        /// Gets validation code based on the passed Mobile No
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="isDuplicate">Is Duplicate</param>
        /// <returns>Validation code</returns>
        string GetValidationCode(string mobileNo, out bool isDuplicate);

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="validationCode">Validation Code</param>
        /// <returns>Boolean</returns>
        ModelManagerResult<bool> VerifyValidationCode(string mobileNo, string validationCode);

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="mobileNo">Mobile No</param>
        /// <param name="validationCode">Validation Code</param>
        /// <returns>Boolean</returns>
        ModelManagerResult<bool> CheckValidationCode(string mobileNo, string validationCode);
    }
}
