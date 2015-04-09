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
         private readonly IStateRepository  _stateRepository;
         private readonly ICityRepository _cityRepository;
         private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Constructor for LookUpManager.
        /// </summary>
         /// <param name="categoryRepository">ICategoryRepository object</param>  
         /// <param name="countryRepository">ICountryRepository object</param>   
         /// <param name="stateRepository">IStateRepository object</param>  
         /// <param name="cityRepository">ICityRepository object</param>  
         /// <param name="locationRepository">ILocationRepository object</param>  
         public LookUpManager(ICategoryRepository categoryRepository, 
                              ICountryRepository countryRepository,
                              IStateRepository stateRepository,
                              ICityRepository cityRepository,
                              ILocationRepository locationRepository
             )
        {
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _locationRepository = locationRepository;
            
        }



        /// <summary>
        /// Returns list of  active categories
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CategoryViewModel))</returns>
        public ModelManagerResult<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var categories = _categoryRepository.Get();
            return GetManagerResult<IEnumerable<CategoryViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories));
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
            if(item!=null)
                return GetManagerResult<CreateCategoryViewModel>(ResponseCodes.CATEGORY_ALREADY_EXIST);
            //Build category object
            var category = Mapper.Map<CategoryCommandModel, Category>(categoryCommandModel);
            category.IsActive = true;
            //category.CreatedOn = DateTime.Now;
            //category.ModifiedOn = DateTime.Now;
            //Insert record into category table
            _categoryRepository.Insert(category);
            return GetManagerResult(ResponseCodes.OK, new CreateCategoryViewModel { CategoryId = Convert.ToInt32(category.CatId)});

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
            if (category!=null)
                return GetManagerResult<bool>(ResponseCodes.CATEGORY_ALREADY_EXIST);
            item.CatName = updateCategoryCommandModel.CatName;
            item.ModifiedOn = null;
            _categoryRepository.Update(item);
            return GetManagerResult(ResponseCodes.OK,true);
        }

        /// <summary>
        /// Deletes category
        /// </summary>
        /// <param name="categoryId">Category Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        [UnitOfWork]
        public ModelManagerResult<bool> DeleteCategory(int categoryId)
        {
            //Find patient with patient id
            var category = _categoryRepository.Get(x=>x.CatId==categoryId).FirstOrDefault();
          if(category==null)
          return GetManagerResult<bool>(ResponseCodes.CATEGORY_NOT_FOUND);
            //Delete record from category
          _categoryRepository.Delete(category.CatId);

            return GetManagerResult(ResponseCodes.OK, true);
        }

        /// <summary>
        /// Returns list of  Countries
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CountryViewModel))</returns>
        public ModelManagerResult<IEnumerable<CountryViewModel>> GetCountries()
        {
            var categories = _countryRepository.Get();
            return GetManagerResult<IEnumerable<CountryViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(categories));
        }
    }
}