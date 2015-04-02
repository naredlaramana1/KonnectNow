using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers;
using KonnectNow.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KonnectNow.WebAPI.Controllers
{
    public class ValuesController : KNBaseController
    {

        private readonly IUserManager _userManager;

        /// <summary>
        /// Constructor for AccountResetController.
        /// </summary>
        /// <param name="accountResetManager">IAccountResetManager object</param>
        public ValuesController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Route("Get/Getvalues")]
        [ResponseType(typeof(UserListViewModel))]
        // GET api/values
        public HttpResponseMessage Get()
        {
            var result = _userManager.GetUsers();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ResponseType(typeof(CreateUserViewModel))]
        public HttpResponseMessage Post(UserCommandModel userCommandModel)
        {
            var result = _userManager.CreateUser(userCommandModel);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.Created, result.Value);
            return BuildErrorResponse(result.Status);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}