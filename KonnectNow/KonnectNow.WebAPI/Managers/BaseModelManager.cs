using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Base class for all the Managers
    /// </summary>
    public class BaseModelManager
    {
        /// <summary>
        /// Gives generic result for all the Manager classes
        /// </summary>
        /// <param name="value">Result value</param>
        /// <param name="code">ResponseCodes</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>ModelManagerResult object</returns>
        protected ModelManagerResult<T> GetManagerResult<T>(ResponseCodes code, T value)
        {
            return new ModelManagerResult<T> { Value = value, Status = code };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected ModelManagerResult<T> GetManagerResult<T>(ResponseCodes code)
        {
            return new ModelManagerResult<T> { Status = code };
        }
    }
}