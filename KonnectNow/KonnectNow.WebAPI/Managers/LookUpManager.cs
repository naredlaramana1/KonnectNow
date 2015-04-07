using AutoMapper;
using KonnectNow.Entity.Entities;
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
        /// <summary>
        /// Constructor for LookUpManager.
        /// </summary>
         /// <param name="categoryRepository">ICategoryRepository object</param>  
         /// <param name="countryRepository">ICountryRepository object</param>          
         public LookUpManager(ICategoryRepository categoryRepository, ICountryRepository countryRepository)
        {
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            
        }



        /// <summary>
        /// Returns list of  categories
        /// </summary>
        /// <returns>ModelManagerResult(IEnumerable(CategoryViewModel))</returns>
        public ModelManagerResult<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var categories = _categoryRepository.Get();
            return GetManagerResult<IEnumerable<CategoryViewModel>>(ResponseCodes.OK,
                                                                          Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories));
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