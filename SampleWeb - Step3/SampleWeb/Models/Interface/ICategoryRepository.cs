namespace SampleWeb.Models.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByID(int categoryID);
    }
}