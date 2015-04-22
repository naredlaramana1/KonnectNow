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
        /// <returns> HTTP Status = 200 {CategoriesViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Categories")]
        [ResponseType(typeof(IEnumerable<CategoriesViewModel>))]
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
        /// Returns category details
        /// </summary>
        /// <returns> 
        ///  HTTP Status = 200 {CategoryViewModel}
        ///  HTTP Status = 404 - {Code = 4003, Message = Category not found}
        /// </returns>
        [HttpGet]
        [Route("LookUps/Categories/{categoryId}")]
        [ResponseType(typeof(CategoryViewModel))]
        public HttpResponseMessage GetCategory(int categoryId)
        {
            var result = _lookUpManager.GetCategory(categoryId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Creates a category
        /// </summary>
        /// <returns> 
        /// HTTP Status = 201 - {CategoryId},
        /// HTTP Status = 400 - {Code = 4002, Message = Category already exist}
        /// </returns>
        [HttpPost]
        [Route("LookUps/Categories")]
        [ResponseType(typeof(CreateCategoryViewModel))]
        public HttpResponseMessage CreateCategory(CategoryCommandModel categoryCommandModel)
        {
            var result = _lookUpManager.CreateCategory(categoryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="updateCategoryCommandModel">UpdateCategoryCommandModel Object</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4003, Message = Category not found}
        /// HTTP Status = 400 - {Code = 4002, Message = Category already exist}
        /// </returns>
        [HttpPut]
        [Route("LookUps/Categories/{categoryId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateCategory(int categoryId, UpdateCategoryCommandModel updateCategoryCommandModel)
        {
            var result = _lookUpManager.UpdateCategory(categoryId, updateCategoryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Removes a category
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4003, Message = Category not found}
        /// HTTP Status = 403 - {Code = 4004, Message = Queries associated with this category cannot be deleted}
        /// </returns>
        [HttpDelete]
        [Route("LookUps/Categories/{categoryId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage DeleteCategory(int categoryId)
        {
            var result = _lookUpManager.DeleteCategory(categoryId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Returns all countries
        /// </summary>
        /// <returns> HTTP Status = 200 {CountriesViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Countries")]
        [ResponseType(typeof(IEnumerable<CountriesViewModel>))]
        public HttpResponseMessage GetCountries()
        {
            var result = _lookUpManager.GetCountries();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Returns country details.
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <returns> 
        ///  HTTP Status = 200 {CountryViewModel}
        ///  HTTP Status = 404 - {Code = 4006, Message = Country not found}
        /// </returns>
        [HttpGet]
        [Route("LookUps/Countries/{countryId}")]
        [ResponseType(typeof(CountryViewModel))]
        public HttpResponseMessage GetCountry(int countryId)
        {
            var result = _lookUpManager.GetCountry(countryId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Creates a country
        /// </summary>
        /// <returns> 
        /// HTTP Status = 201 - {CountryId},
        /// HTTP Status = 400 - {Code = 4005, Message = Country already exist}
        /// </returns>
        [HttpPost]
        [Route("LookUps/Countries")]
        [ResponseType(typeof(CreateCountryViewModel))]
        public HttpResponseMessage CreateCountry(CreateCountryCommandModel createCountryCommandModel)
        {
            var result = _lookUpManager.CreateCountry(createCountryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <param name="updateCountryCommandModel">UpdateCountryCommandModel Object</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4006, Message = Country not found}
        /// HTTP Status = 400 - {Code = 4005, Message = Country already exists}
        /// </returns>
        [HttpPut]
        [Route("LookUps/Countries/{countryId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage UpdateCountry(int countryId, UpdateCountryCommandModel updateCountryCommandModel)
        {
            var result = _lookUpManager.UpdateCountry(countryId, updateCountryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Removes a country
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4006, Message = Country not found}
        /// HTTP Status = 403 - {Code = 4007, Message = Country Dependency Exist.Cannot be deleted}
        /// </returns>
        [HttpDelete]
        [Route("LookUps/Countries/{countryId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage DeleteCountry(int countryId)
        {
            var result = _lookUpManager.DeleteCountry(countryId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Returns all cities
        /// </summary>
        /// <returns> HTTP Status = 200 {CitiesViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Cities")]
        [ResponseType(typeof(IEnumerable<CitiesViewModel>))]
        public HttpResponseMessage GetCities()
        {
            var result = _lookUpManager.GetCities();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }



        /// <summary>
        /// Returns all Locations
        /// </summary>
        /// <param name="cityId">City Id</param>
        /// <returns> HTTP Status = 200 {LocationsViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Locations")]
        [ResponseType(typeof(IEnumerable<LocationsViewModel>))]
        public HttpResponseMessage GetLocations()
        {
            var result = _lookUpManager.GetLocations();

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Returns all Locations for a given city
        /// </summary>
        /// <returns>
        /// HTTP Status = 200 {LocationsViewModel}
        /// HTTP Status = 404 - {Code = 4013, Message =  City not found}
        /// </returns>
        [HttpGet]
        [Route("LookUps/Cities/{cityId}/Locations")]
        [ResponseType(typeof(IEnumerable<LocationsViewModel>))]
        public HttpResponseMessage GetLocationsByCity(int cityId)
        {
            var result = _lookUpManager.GetLocationsByCity(cityId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Returns  Location for a given latitude,longitude
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns> HTTP Status = 200 {LocationViewModel}</returns>
        [HttpGet]
        [Route("LookUps/Locations/{latitude}/{longitude}")]
        [ResponseType(typeof(LocationViewModel))]
        public HttpResponseMessage GetLocationsByGeography(double latitude, double longitude)
        {
            var result = _lookUpManager.GetLocationsByGeography(latitude, longitude);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }

    }
}
