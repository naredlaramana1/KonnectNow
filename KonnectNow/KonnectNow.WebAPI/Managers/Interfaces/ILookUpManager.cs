using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.WebAPI.Managers.Interfaces
{
    /// <summary>
    ///  This interface must be implemented by all lookups related business operations.
    /// </summary>
    public interface ILookUpManager
    {
        /// <summary>
        /// Returns list of  categories
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CategoriesViewModel))</returns>
        ModelManagerResult<IEnumerable<CategoriesViewModel>> GetCategories();

        /// <summary>
        /// Returns category details
        /// </summary>
        /// <param name="categoryId">CategoryId</param>
        /// <returns>ModelManagerResult(CategoryViewModel)</returns>
        ModelManagerResult<CategoryViewModel> GetCategory(int categoryId);

        /// <summary>
        /// Creates a category
        /// </summary>    
        /// <param name="categoryCommandModel">CategoryCommandModel object</param>
        /// <returns>CategoryId</returns>
        ModelManagerResult<CreateCategoryViewModel> CreateCategory(CategoryCommandModel categoryCommandModel);

        /// <summary>
        /// updates the category
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="updateCategoryCommandModel">UpdateCategoryCommandModel Object</param>
        /// <returns>true or false</returns>
        ModelManagerResult<bool> UpdateCategory(int categoryId, UpdateCategoryCommandModel updateCategoryCommandModel);

        /// <summary>
        /// Deletes category
        /// </summary>
        /// <param name="categoryId">Category Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        ModelManagerResult<bool> DeleteCategory(int categoryId);

        /// <summary>
        /// Returns list of  Countries
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CountriesViewModel))</returns>
        ModelManagerResult<IEnumerable<CountriesViewModel>> GetCountries();

        /// <summary>
        /// Returns country details
        /// </summary>
        /// <param name="countryId">CountryId</param>
        /// <returns>ModelManagerResult(CountryViewModel)</returns>
        ModelManagerResult<CountryViewModel> GetCountry(int countryId);

        /// <summary>
        /// Creates a country
        /// </summary>    
        /// <param name="createCountryCommandModel">CreateCountryCommandModel object</param>
        /// <returns>CountryId</returns>
        ModelManagerResult<CreateCountryViewModel> CreateCountry(CreateCountryCommandModel createCountryCommandModel);

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <param name="updateCountryCommandModel">UpdateCountryCommandModel Object</param>
        /// <returns>true or false</returns>
        ModelManagerResult<bool> UpdateCountry(int countryId, UpdateCountryCommandModel updateCountryCommandModel);

        /// <summary>
        /// Removes country
        /// </summary>
        /// <param name="countryId">Country Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        ModelManagerResult<bool> DeleteCountry(int countryId);

        /// <summary>
        /// Returns list of  Cities
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CitiesViewModel))</returns>
        ModelManagerResult<IEnumerable<CitiesViewModel>> GetCities();

        /// <summary>
        /// Returns list of  locations
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(LocationsViewModel))</returns>
        ModelManagerResult<IEnumerable<LocationsViewModel>> GetLocations();


        /// <summary>
        ///  Returns all Locations for a given city
        /// </summary>
        /// <param name="cityId">City Id</param>
        /// <returns>ModelManagerResult(IEnumerable(LocationsViewModel))</returns>
        ModelManagerResult<IEnumerable<LocationsViewModel>> GetLocationsByCity(int cityId);

        /// <summary>
        ///  Returns  Location for a given longitude,latitude
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>ModelManagerResult(LocationViewModel)</returns>
        ModelManagerResult<LocationViewModel> GetLocationsByGeography(double latitude, double longitude);
    }
}
