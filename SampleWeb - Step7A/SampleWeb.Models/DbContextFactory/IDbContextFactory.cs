using System.Data.Entity;

namespace SampleWeb.Models.DbContextFactory
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}