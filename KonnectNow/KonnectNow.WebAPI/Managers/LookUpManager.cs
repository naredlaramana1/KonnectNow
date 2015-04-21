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
            var query = _queryRepository.Get(x => x.Cat_Id == categoryId).FirstOrDefault();
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


    }
}