using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KonnectNow.WebAPI.Controllers
{
    /// <summary>
    /// Manages  lookups(country,state,city etc.) operations
    /// </summary>
    public class LookUpsController : KNBaseController
    {

        private readonly ILookUpManager _lookUpManager;

        /// <summary>
        /// Constructor for LookUpsController.
        /// </summary>
        /// <param name="lookUpManager">ILookUpManager object</param>
        public LookUpsController(ILookUpManager lookUpManager)
        {
            _lookUpManager = lookUpManager;
        }
        /// <summary>
        /// Returns all active categories
        /// </summary>
        /// <returns> HTTP Status = 200 {CategoryViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Categories")]
        [ResponseType(typeof(IEnumerable<CategoryViewModel>))]
        public HttpResponseMessage GetCategories()
        {
            var result = _lookUpManager.GetCategories();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Returns allCountries
        /// </summary>
        /// <returns> HTTP Status = 200 {CountryViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Countries")]
        [ResponseType(typeof(IEnumerable<CountryViewModel>))]
        public HttpResponseMessage GetCountries()
        {
            var result = _lookUpManager.GetCountries();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }
    }
}
