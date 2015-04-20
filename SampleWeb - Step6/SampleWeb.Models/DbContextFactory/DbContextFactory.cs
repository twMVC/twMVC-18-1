using System;
using System.Data.Entity;

namespace SampleWeb.Models.DbContextFactory
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly string _ConnectionString;

        public DbContextFactory(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        private DbContext _dbContext;

        private DbContext DbContext
        {
            get
            {
                if (this._dbContext == null)
                {
                    Type t = typeof(DbContext);
                    this._dbContext =
                        (DbContext)Activator.CreateInstance(t, this._ConnectionString);
                }
                return _dbContext;
            }
        }

        public DbContext GetDbContext()
        {
            return this.DbContext;
        }
    }
}