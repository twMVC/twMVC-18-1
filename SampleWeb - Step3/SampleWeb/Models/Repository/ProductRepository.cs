using SampleWeb.Models.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SampleWeb.Models.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="productID">The product ID.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Product GetByID(int productID)
        {
            return this.Get(x => x.ProductID == productID);
        }

        /// <summary>
        /// Gets the by cateogy.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Product> GetByCateogy(int categoryID)
        {
            return this.GetAll().Where(x => x.CategoryID == categoryID);
        }
    }
}