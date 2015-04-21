using System;
using System.Data.Entity;
using SampleWeb.Models.DbContextFactory;

namespace SampleWeb.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextFactory DbContextFactory { get; set; }

        private DbContext _context;

        public DbContext Context
        {
            get
            {
                if (this._context != null)
                {
                    return this._context;
                }
                this._context = DbContextFactory.GetDbContext();
                return this._context;
            }
        }

        public UnitOfWork(IDbContextFactory factory)
        {
            this.DbContextFactory = factory;
        }

        public int SaveChange()
        {
            return this.Context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    this._context = null;
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}