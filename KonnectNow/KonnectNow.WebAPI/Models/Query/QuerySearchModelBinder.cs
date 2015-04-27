using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace KonnectNow.WebAPI.Models.Query
{
    /// <summary>
    /// Manages query building model binder operations  for querysearchmodel.  
    /// </summary>
    public class QuerySearchModelBinder: SearchQueryModelBinder, IModelBinder
    {

        #region Public Methods
        /// <summary>
        /// Builds the  QueryearchQueryModel.
        /// </summary>
        /// <param name="actionContext">HttpActionContext Object</param>
        /// <param name="bindingContext">ModelBindingContext Object</param>
        /// <returns>Boolean</returns>
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ErrorBuilder = new StringBuilder();
            if (bindingContext.ModelType != typeof(QuerySearchComamndModel))
                return false;

            var model = (QuerySearchComamndModel)bindingContext.Model ?? new QuerySearchComamndModel();

            var hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);

            var searchPrefix = (hasPrefix) ? string.Format("{0}.", bindingContext.ModelName) : string.Empty;

            //Offset           
            model.Offset = SetOffset(GetValue(bindingContext, searchPrefix, KNReources.KonnectNow.Offset));

            //Limit       
            model.Limit = SetLimit(GetValue(bindingContext, searchPrefix, KNReources.KonnectNow.Limit));

          

            if (ErrorBuilder.Length > 0)
            {
                bindingContext.ModelState.AddModelError(string.Format(".{0}", ErrorBuilder).TrimEnd(','), string.Empty);
                return false;
            }
            bindingContext.Model = model;
            return true;
        }

        #endregion

       
    }
}