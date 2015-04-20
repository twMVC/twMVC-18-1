using System;
using System.Collections.Generic;
using System.Linq;
using SampleWeb.Models;
using SampleWeb.Models.Interface;
using SampleWeb.Service.Interface;

namespace SampleWeb.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IResult Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(productID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(productID);
                this._repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int productID)
        {
            return this._repository.GetAll().Any(x => x.ProductID == productID);
        }

        public Product GetByID(int productID)
        {
            return this._repository.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Product> GetAll()
        {
            return this._repository.GetAll();
        }

        public IEnumerable<Product> GetByCategory(int categoryID)
        {
            return this._repository.GetAll().Where(x => x.CategoryID == categoryID);
        }
    }
}