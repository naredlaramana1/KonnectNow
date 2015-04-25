using AutoMapper;
using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages  lookups(country,state,city etc.) operations
    /// </summary>
    public class LookUpManager : BaseModelManager, ILookUpManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IQueryRepository _queryRepository;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Constructor for LookUpManager.
        /// </summary>
        /// <param name="categoryRepository">ICategoryRepository object</param>  
        /// <param name="countryRepository">ICountryRepository object</param>   
        /// <param name="stateRepository">IStateRepository object</param>  
        /// <param name="cityRepository">ICityRepository object</param>  
        /// <param name="locationRepository">ILocationRepository object</param>  
        /// <param name="queryRepository">IQueryRepository object</param> 
        /// <param name="userRepository">IUserRepository object</param>
        public LookUpManager(ICategoryRepository categoryRepository,
                             ICountryRepository countryRepository,
                             IStateRepository stateRepository,
                             ICityRepository cityRepository,
                             ILocationRepository locationRepository,
                             IQueryRepository queryRepository,
                             IUserRepository userRepository
            )
        {
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _locationRepository = locationRepository;
            _queryRepository = queryRepository;
            _userRepository = userRepository;

        }



        /// <summary>
        /// Returns list of  active categories
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CategoriesViewModel))</returns>
        public ModelManagerResult<IEnumerable<CategoriesViewModel>> GetCategories()
        {
            var categories = _categoryRepository.Get();
            return GetManagerResult<IEnumerable<CategoriesViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesViewModel>>(categories));
        }

        /// <summary>
        /// Returns category details
        /// </summary>
        /// <param name="categoryId">CategoryId</param>
        /// <returns>ModelManagerResult(CategoryViewModel)</returns>
        public ModelManagerResult<CategoryViewModel> GetCategory(int categoryId)
        {
            var category = _categoryRepository.GetByID(categoryId);
            return GetManagerResult<CategoryViewModel>(ResponseCodes.OK, Mapper.Map<Category, CategoryViewModel>(category));
        }


        /// <summary>
        /// Creates a category
        /// </summary>    
        /// <param name="categoryCommandModel">CategoryCommandModel object</param>
        /// <returns>CategoryId</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateCategoryViewModel> CreateCategory(CategoryCommandModel categoryCommandModel)
        {
            var item = _categoryRepository.Get(x => x.CatName.ToLower() == categoryCommandModel.CatName.ToLower()).FirstOrDefault();
            if (item != null)
                return GetManagerResult<CreateCategoryViewModel>(ResponseCodes.CATEGORY_ALREADY_EXIST);
            //Build category object
            var category = Mapper.Map<CategoryCommandModel, Category>(categoryCommandModel);
            category.IsActive = true;
            _categoryRepository.Insert(category);
            return GetManagerResult(ResponseCodes.OK, new CreateCategoryViewModel { CategoryId = Convert.ToInt32(category.CatId) });

        }

        /// <summary>
        /// updates the category
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="updateCategoryCommandModel">UpdateCategoryCommandModel Object</param>
        /// <returns>true or false</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> UpdateCategory(int categoryId, UpdateCategoryCommandModel updateCategoryCommandModel)
        {
            var item = _categoryRepository.Get(x => x.CatId == categoryId).FirstOrDefault();
            if (item == null)
                return GetManagerResult<bool>(ResponseCodes.CATEGORY_NOT_FOUND);
            var category = _categoryRepository.Get(x => x.CatName.ToLower() == updateCategoryCommandModel.CatName.ToLower()).FirstOrDefault();
            if (category != null)
                return GetManagerResult<bool>(ResponseCodes.CATEGORY_ALREADY_EXIST);
            item.CatName = updateCategoryCommandModel.CatName;
            item.ModifiedOn = null;
            _categoryRepository.Update(item);
            return GetManagerResult(ResponseCodes.OK, true);
        }

        /// <summary>
        /// Deletes category
        /// </summary>
        /// <param name="categoryId">Category Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> DeleteCategory(int categoryId)
        {
         
            var category = _categoryRepository.Get(x => x.CatId == categoryId).FirstOrDefault();
            if (category == null)
                return GetManagerResult<bool>(ResponseCodes.CATEGORY_NOT_FOUND);
            var query = _queryRepository.Get(x => x.CatId == categoryId).FirstOrDefault();
            if (query == null)
                return GetManagerResult<bool>(ResponseCodes.QUERY_CATEGORY_CANNOT_BE_DELETED);

            //Delete record from category
            _categoryRepository.Delete(category.CatId);

            return GetManagerResult(ResponseCodes.OK, true);
        }

        /// <summary>
        /// Returns list of  Countries
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CountriesViewModel))</returns>
        public ModelManagerResult<IEnumerable<CountriesViewModel>> GetCountries()
        {
            var categories = _countryRepository.Get();
            return GetManagerResult<IEnumerable<CountriesViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Country>, IEnumerable<CountriesViewModel>>(categories));
        }


        /// <summary>
        /// Returns country details
        /// </summary>
        /// <param name="countryId">CountryId</param>
        /// <returns>ModelManagerResult(CountryViewModel)</returns>
        public ModelManagerResult<CountryViewModel> GetCountry(int countryId)
        {
            var country = _countryRepository.GetByID(countryId);
            return GetManagerResult<CountryViewModel>(ResponseCodes.OK, Mapper.Map<Country, CountryViewModel>(country));
        }


        /// <summary>
        /// Creates a country
        /// </summary>    
        /// <param name="createCountryCommandModel">CreateCountryCommandModel object</param>
        /// <returns>CountryId</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateCountryViewModel> CreateCountry(CreateCountryCommandModel createCountryCommandModel)
        {
            var item = _countryRepository.Get(x => x.CountryName.ToLower() == createCountryCommandModel.CountryName.ToLower()).FirstOrDefault();
            if (item != null)
                return GetManagerResult<CreateCountryViewModel>(ResponseCodes.COUNTRY_ALREADY_EXIST);
            //Build category object
            var country = Mapper.Map<CreateCountryCommandModel, Country>(createCountryCommandModel);
            country.IsActive = true;
            _countryRepository.Insert(country);
            return GetManagerResult(ResponseCodes.OK, new CreateCountryViewModel { CountryId = Convert.ToInt32(country.CountryId) });

        }

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <param name="updateCountryCommandModel">UpdateCountryCommandModel Object</param>
        /// <returns>true or false</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> UpdateCountry(int countryId, UpdateCountryCommandModel updateCountryCommandModel)
        {
            var item = _countryRepository.Get(x => x.CountryId == countryId).FirstOrDefault();
            if (item == null)
                return GetManagerResult<bool>(ResponseCodes.COUNTRY_NOT_FOUND);
            var country = _countryRepository.Get(x => x.CountryName.ToLower() == updateCountryCommandModel.CountryName.ToLower()).FirstOrDefault();
            if (country != null)
                return GetManagerResult<bool>(ResponseCodes.COUNTRY_ALREADY_EXIST);
            item.CountryName = updateCountryCommandModel.CountryName;
            item.ModifiedOn = null;
            _countryRepository.Update(item);
            return GetManagerResult(ResponseCodes.OK, true);
        }

        /// <summary>
        /// Removes country
        /// </summary>
        /// <param name="countryId">Country Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> DeleteCountry(int countryId)
        {
            var country = _countryRepository.GetByID(countryId);
            if (country == null)
                return GetManagerResult<bool>(ResponseCodes.COUNTRY_NOT_FOUND);
            var query = _userRepository.Get(x => x.CountryId == countryId).FirstOrDefault();
            if (query != null)
                return GetManagerResult<bool>(ResponseCodes.USER_COUNTRY_CANNOT_BE_DELETED);

            //Delete record from country
            _countryRepository.Delete(country.CountryId);

            return GetManagerResult(ResponseCodes.OK, true);
        }



        /// <summary>
        /// Creates a city
        /// </summary>    
        /// <param name="createCityCommandModel">CreateCityCommandModel object</param>
        /// <returns>CityId</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateCityViewModel> CreateCity(CreateCityCommandModel createCityCommandModel)
        {
            var item = _cityRepository.Get(x => x.CityName.ToLower() == createCityCommandModel.CityName.ToLower()).FirstOrDefault();
            if (item != null)
                return GetManagerResult<CreateCityViewModel>(ResponseCodes.CITY_ALREADY_EXIST);
            //Build city object
            var city = Mapper.Map<CreateCityCommandModel, City>(createCityCommandModel);
            city.IsActive = true;
            city.StateId = 1;
            _cityRepository.Insert(city);
            return GetManagerResult(ResponseCodes.OK, new CreateCityViewModel { CityId = Convert.ToInt32(city.CityId) });

        }

        /// <summary>
        /// Updates the city
        /// </summary>
        /// <param name="cityId">City Id</param>
        /// <param name="updateCityCommandModel">UpdateCityCommandModel Object</param>
        /// <returns>true or false</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> UpdateCity(int cityId, UpdateCityCommandModel updateCityCommandModel)
        {
            var item = _cityRepository.GetByID(cityId);
            if (item == null)
                return GetManagerResult<bool>(ResponseCodes.CITY_NOT_FOUND);
            var country = _cityRepository.Get(x => x.CityName.ToLower() == updateCityCommandModel.CityName.ToLower()).FirstOrDefault();
            if (country != null)
                return GetManagerResult<bool>(ResponseCodes.CITY_ALREADY_EXIST);
            item.CityName = updateCityCommandModel.CityName;
            item.Latitude = updateCityCommandModel.Latitude;
            item.Longitude = updateCityCommandModel.Longitude;
            item.ModifiedOn = null;
            _cityRepository.Update(item);
            return GetManagerResult(ResponseCodes.OK, true);
        }



        /// <summary>
        /// Returns list of  Cities
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CitiesViewModel))</returns>
        public ModelManagerResult<IEnumerable<CitiesViewModel>> GetCities()
        {
            var cities = _cityRepository.Get();
            return GetManagerResult<IEnumerable<CitiesViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<City>, IEnumerable<CitiesViewModel>>(cities));
        }


        /// <summary>
        ///  Returns  city for a given longitude,latitude
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>ModelManagerResult(CityViewModel)</returns>
        public ModelManagerResult<CityViewModel> GetCityByGeography(double latitude, double longitude)
        {
            var city = _cityRepository.Get(x => x.Latitude == latitude && x.Longitude == longitude).FirstOrDefault();
            return GetManagerResult<CityViewModel>(ResponseCodes.OK,
                                                                          Mapper.Map<City, CityViewModel>(city));
        }


        /// <summary>
        ///  Returns  city latitude,longitude for given city
        /// </summary>
        /// <param name="cityId">City Id</param>
        /// <returns>ModelManagerResult(CityGeographyViewModel)</returns>
        public ModelManagerResult<CityGeographyViewModel> GetCityGeographyById(int cityId)
        {
            var city = _cityRepository.GetByID(cityId);
            if (city == null)
                return GetManagerResult<CityGeographyViewModel>(ResponseCodes.CITY_NOT_FOUND);

            return GetManagerResult<CityGeographyViewModel>(ResponseCodes.OK,
                                                                          Mapper.Map<City, CityGeographyViewModel>(city));
        }

        /// <summary>
        /// Returns list of  locations
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(LocationsViewModel))</returns>
        public ModelManagerResult<IEnumerable<LocationsViewModel>> GetLocations()
        {
            var locations = _locationRepository.Get();
            return GetManagerResult<IEnumerable<LocationsViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Location>, IEnumerable<LocationsViewModel>>(locations));
        }

        /// <summary>
        ///  Returns all Locations for a given city
        /// </summary>
        /// <param name="cityId">City Id</param>
        /// <returns>ModelManagerResult(IEnumerable(LocationsViewModel))</returns>
        public ModelManagerResult<IEnumerable<LocationsViewModel>> GetLocationsByCity(int cityId)
        {

            if (_cityRepository.GetByID(cityId) == null)
                return GetManagerResult<IEnumerable<LocationsViewModel>>(ResponseCodes.CITY_NOT_FOUND);
            var locations = _locationRepository.Get(x => x.CityId == cityId);
            return GetManagerResult<IEnumerable<LocationsViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Location>, IEnumerable<LocationsViewModel>>(locations));
        }


        /// <summary>
        ///  Returns  Location for a given longitude,latitude
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>ModelManagerResult(LocationViewModel)</returns>
        public ModelManagerResult<LocationViewModel> GetLocationsByGeography(double latitude, double longitude)
        {
            var location = _locationRepository.Get(x => x.Latitude == latitude && x.Longitude == longitude).FirstOrDefault();
            return GetManagerResult<LocationViewModel>(ResponseCodes.OK,
                                                                          Mapper.Map<Location, LocationViewModel>(location));
        }


        /// <summary>
        ///  Returns  Location latitude,longitude for given location
        /// </summary>
        /// <param name="locationId">Location Id</param>
        /// <returns>ModelManagerResult(LocationGeographyViewModel)</returns>
        public ModelManagerResult<LocationGeographyViewModel> GetLocationsGeographyById(int locationId)
        {
            var location = _locationRepository.GetByID(locationId);
            if (location == null)
                return GetManagerResult<LocationGeographyViewModel>(ResponseCodes.LOCATION_NOT_FOUND);
             
            return GetManagerResult<LocationGeographyViewModel>(ResponseCodes.OK,
                                                                          Mapper.Map<Location, LocationGeographyViewModel> (location));
        }




        /// <summary>
        /// Creates a location
        /// </summary>    
        /// <param name="createLocationCommandModel">CreateLocationCommandModel object</param>
        /// <returns>LocationId</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateLocationViewModel> CreateLocation(CreateLocationCommandModel createLocationCommandModel)
        {
            var item = _cityRepository.GetByID(createLocationCommandModel.CityId);
            if (item == null)
                return GetManagerResult<CreateLocationViewModel>(ResponseCodes.CITY_NOT_FOUND);
            var location = _locationRepository.Get(x => x.LocationName.ToLower() == createLocationCommandModel.LocationName.ToLower()).FirstOrDefault();
            if(location!=null)
                return GetManagerResult<CreateLocationViewModel>(ResponseCodes.LOCATION_ALREADY_EXIST);
            //Build loaction object
            var locationItem = Mapper.Map<CreateLocationCommandModel, Location>(createLocationCommandModel);
            locationItem.IsActive = true;
            locationItem.CityId = createLocationCommandModel.CityId;
            _locationRepository.Insert(locationItem);
            return GetManagerResult(ResponseCodes.OK, new CreateLocationViewModel { LocationId = Convert.ToInt32(locationItem.LocationId) });

        }

        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="locationId">Location Id</param>
        /// <param name="updateLocationCommandModel">UpdateLocationCommandModel Object</param>
        /// <returns>true or false</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> UpdateLocation(int locationId, UpdateLocationCommandModel updateLocationCommandModel)
        {

            var item = _cityRepository.GetByID(updateLocationCommandModel.CityId);
            if (item == null)
                return GetManagerResult<bool>(ResponseCodes.CITY_NOT_FOUND);
            var location = _locationRepository.GetByID(locationId);
            if (location == null)
                return GetManagerResult<bool>(ResponseCodes.LOCATION_NOT_FOUND);

            var locationItem = _locationRepository.Get(x => x.LocationName.ToLower() == updateLocationCommandModel.LocationName.ToLower()).FirstOrDefault();
            if (locationItem != null)
                return GetManagerResult<bool>(ResponseCodes.LOCATION_ALREADY_EXIST);

            location.CityId = updateLocationCommandModel.CityId;
            location.LocationName = updateLocationCommandModel.LocationName;
            location.Latitude = updateLocationCommandModel.Latitude;
            location.Longitude = updateLocationCommandModel.Longitude;
            item.ModifiedOn = null;
            _cityRepository.Update(item);
            return GetManagerResult(ResponseCodes.OK, true);
        }


    }
}