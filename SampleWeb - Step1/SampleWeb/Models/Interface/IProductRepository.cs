using System;
using System.Linq;

namespace SampleWeb.Models.Interface
{
    public interface IProductRepository : IDisposable
    {
        void Create(Product instance);

        void Update(Product instance);

        void Delete(Product instance);

        Product Get(int productID);

        IQueryable<Product> GetAll();

        void SaveChanges();
    }
}