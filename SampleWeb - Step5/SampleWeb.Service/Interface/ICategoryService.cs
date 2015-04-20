using SampleWeb.Models;
using System.Collections.Generic;

namespace SampleWeb.Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(Category instance);

        IResult Update(Category instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        Category GetByID(int categoryID);

        IEnumerable<Category> GetAll();
    }
}