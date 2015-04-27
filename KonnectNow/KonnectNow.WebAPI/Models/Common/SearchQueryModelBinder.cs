using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;

namespace KonnectNow.WebAPI.Models.Common
{
    /// <summary>
    /// Manages common  query building model binder operations
    /// </summary>
    public class SearchQueryModelBinder
    {

        #region Variable Declaration
        /// <summary>
        /// Builds request errors string.
        /// </summary>
        public StringBuilder ErrorBuilder = new StringBuilder();
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets value based on key
        /// </summary>
        /// <param name="context">Model Binding Context</param>
        /// <param name="prefix">Prefix</param>
        /// <param name="key">Key</param>
        /// <returns>String</returns>
        public string GetValue(ModelBindingContext context, string prefix, string key)
        {
            var result = context.ValueProvider.GetValue(prefix + key);
            return result == null ? null : result.AttemptedValue;
        }

        /// <summary>
        /// Returns offset value
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public int SetOffset(string inputString)
        {
            int intResult = 0;
            if (inputString != null)
            {
                if (!Int32.TryParse(inputString, out intResult))
                    ErrorBuilder.AppendFormat("{0},", KNReources.KonnectNow.Offset);
            }
            return intResult;
        }

        /// <summary>
        /// Returns Limit value
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public int SetLimit(string inputString)
        {
            int intResult = 10;
            if (inputString != null)
            {
                if (!Int32.TryParse(inputString, out intResult))
                    ErrorBuilder.AppendFormat("{0},", KNReources.KonnectNow.Limit);

            }
            return intResult;
        }
        #endregion

    }
}