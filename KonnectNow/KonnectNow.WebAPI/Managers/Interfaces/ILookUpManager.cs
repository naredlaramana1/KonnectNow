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
        /// <returns>ModelManagerResult(IEnumerable(CategoryViewModel))</returns>
        ModelManagerResult<IEnumerable<CategoryViewModel>> GetCategories();

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
        /// <returns>ModelManagerResult(IEnumerable(CountryViewModel))</returns>
        ModelManagerResult<IEnumerable<CountryViewModel>> GetCountries();
    }
}
