using SampleWeb.Models.Interface;
using System;
using System.Data.Entity;
using System.Linq;

namespace SampleWeb.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected NorthwindEntities db { get; private set; }

        public ProductRepository()
        {
            this.db = new NorthwindEntities();
        }


        public void Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Products.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }


        public Product Get(int productID)
        {
            return db.Products.FirstOrDefault(x => x.ProductID == productID);
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products.Include(p => p.Category).OrderByDescending(x => x.ProductID);
        }


        public void SaveChanges()
        {
            this.db.SaveChanges();
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}