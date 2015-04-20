using System.Collections.Generic;

namespace SampleWeb.Models.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByID(int productID);

        IEnumerable<Product> GetByCateogy(int categoryID);
    }
}
