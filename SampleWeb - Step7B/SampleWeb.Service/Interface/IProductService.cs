using System.Collections.Generic;
using SampleWeb.Models;

namespace SampleWeb.Service.Interface
{
    public interface IProductService
    {
        IResult Create(Product instance);

        IResult Update(Product instance);

        IResult Delete(int productID);

        bool IsExists(int productID);

        Product GetByID(int productID);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetByCategory(int categoryID);
    }
}