using System;
using System.Linq;

namespace SampleWeb.Models.Interface
{
    public interface ICategoryRepository : IDisposable
    {
        void Create(Category instance);

        void Update(Category instance);

        void Delete(Category instance);

        Category Get(int categoryID);

        IQueryable<Category> GetAll();

        void SaveChanges();
    }
}