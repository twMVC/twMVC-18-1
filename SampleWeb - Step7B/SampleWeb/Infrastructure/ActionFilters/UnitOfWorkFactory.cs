using System.Web.Mvc;
using SampleWeb.Models.UnitOfWork;

namespace SampleWeb.Infrastructure.ActionFilters
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private IUnitOfWork _unitOfWork;

        public IUnitOfWork Create()
        {
            if (this._unitOfWork != null)
            {
                return this._unitOfWork;
            }
            this._unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            return this._unitOfWork;
        }
    }
}