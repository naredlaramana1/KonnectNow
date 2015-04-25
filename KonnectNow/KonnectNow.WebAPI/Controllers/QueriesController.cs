using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KonnectNow.WebAPI.Controllers
{    /// <summary>
    /// Manages  query retaled operations
    /// </summary>
    public class QueriesController : KNBaseController
    {
        private readonly IQueryManager _queryManager;
       
        /// <summary>
        /// Constructor for QueriesController.
        /// </summary>
        /// <param name="queryManager">IQueryManager object</param>
        public QueriesController(IQueryManager queryManager)
        {
            _queryManager = queryManager;           
        }


        /// <summary>
        /// Creates a Query
        /// </summary>
        /// <param name="createQueryCommandModel">CreateQueryCommandModel Object</param>
        /// <returns> 
        /// HTTP Status = 201 - {QueryId},
        /// HTTP Status = 404 - {Code = 4014, Message =Location not found}
        /// HTTP Status = 404 - {Code = 4003, Message =Category not found}
        /// HTTP Status = 404 - {Code = 4012, Message =User not avialable}
        /// </returns>
        [HttpPost]
        [Route("Queries")]
        [ResponseType(typeof(CreateQueryViewModel))]
        public HttpResponseMessage CreateQuery(CreateQueryCommandModel createQueryCommandModel)
        {
            var result = _queryManager.CreateQuery(createQueryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }
    }
}
