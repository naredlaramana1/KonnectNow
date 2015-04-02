using KonnectNow.WebAPI.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Common
{
    /// <summary>
    /// Result of all model manager methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelManagerResult<T>
    {
        /// <summary>
        /// Response status code
        /// </summary>
        public ResponseCodes Status { get; set; }

        /// <summary>
        /// Result value
        /// </summary>
        public T Value { get; set; }
    }
}