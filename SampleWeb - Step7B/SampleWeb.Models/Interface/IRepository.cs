using System;
using System.Linq;
using System.Linq.Expressions;
using SampleWeb.Models.UnitOfWork;

namespace SampleWeb.Models.Interface
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IUnitOfWork _UnitOfWork { get; set; }

        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
    }
}