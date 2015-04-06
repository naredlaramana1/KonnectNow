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
    public class LookUpManager : BaseModelManager, ILookUpManager
    {
         private readonly ICategoryRepository _categoryRepository;
       
        /// <summary>
        /// Constructor for LookUpManager.
        /// </summary>
         /// <param name="categoryRepository">ICategoryRepository object</param>          
         public LookUpManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
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
    }
}