using System;
using System.Data.Entity;
using System.Linq;
using SampleWeb.Models.Interface;

namespace SampleWeb.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected NorthwindEntities db { get; private set; }

        public CategoryRepository()
        {
            this.db = new NorthwindEntities();
        }


        public void Create(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Categories.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Category instance)
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

        public void Delete(Category instance)
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

        public Category Get(int categoryID)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories.OrderBy(x => x.CategoryID);
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
            if (!disposing)
            {
                return;
            }
            if (this.db == null)
            {
                return;
            }
            this.db.Dispose();
            this.db = null;
        }
    }
}