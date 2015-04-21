using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SampleWeb.Models.UnitOfWork;

namespace SampleWeb.Infrastructure.ActionFilters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        [Dependency]
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        private IUnitOfWork _unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this._unitOfWork = UnitOfWorkFactory.Create();

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                this._unitOfWork.SaveChange();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}