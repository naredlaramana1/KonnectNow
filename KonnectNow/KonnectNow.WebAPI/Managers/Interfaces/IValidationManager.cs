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
        /// Gets validation code based on the passed email
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>Validation code</returns>
        string GetValidationCode(string email);

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="validationCode">Validation Code</param>
        /// <returns>Boolean</returns>
        bool VerifyValidationCode(string email, string validationCode);

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="validationCode">Validation Code</param>
        /// <returns>Boolean</returns>
        bool CheckValidationCode(string email, string validationCode);
    }
}
