using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Models.Common;


namespace KonnectNow.WebAPI.Filters
{
    /// <summary>
    /// Handles all request validation
    /// </summary>
    public class ValidationActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Process all request validation in current context
        /// </summary>
        /// <param name="actionContext">HttpActionContext object</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                var errorParameters = new StringBuilder();
                foreach (var item in modelState.Keys)
                {
                    var itemVal = modelState[item];
                    if (itemVal.Errors.Count > 0)
                    {
                        var itemIndex = item.IndexOf('.');
                        if (itemIndex > -1 || !string.IsNullOrEmpty(itemVal.Errors[0].ErrorMessage))
                        {
                            errorParameters.Append(item.Substring(item.IndexOf('.') + 1));
                            errorParameters.Append(',');
                        }
                    }
                }

                string errors = errorParameters.ToString().Substring(0, errorParameters.Length - 1);

                var peErrorResponse = new KNErrorModel
                {
                    Code = (int)ResponseCodes.INVALID_MISSING_INPUTS,
                    Message = EnumManager.Instance.GetDescription<ResponseCodes>(ResponseCodes.INVALID_MISSING_INPUTS)
                };

                var serviceResponse = peErrorResponse;
                serviceResponse.Message = serviceResponse.Message + " " + errors;

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, serviceResponse);
            }
        }
    } 
}