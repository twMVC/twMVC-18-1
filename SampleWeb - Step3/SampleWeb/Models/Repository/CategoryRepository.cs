using SampleWeb.Models.Interface;

namespace SampleWeb.Models.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public Category GetByID(int categoryID)
        {
            return this.Get(x => x.CategoryID == categoryID);
        }
    }}