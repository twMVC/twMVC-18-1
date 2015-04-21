using SampleWeb.Infrastructure.ActionFilters;
using SampleWeb.Models;
using SampleWeb.Service.Interface;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SampleWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = this._categoryService.GetAll().ToList();
            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this._categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UnitOfWork]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Category category)
        {
            if (category != null &&
                ModelState.IsValid)
            {
                this._categoryService.Create(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this._categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UnitOfWork]
        public ActionResult Edit(Category category)
        {
            if (category != null &&
                ModelState.IsValid)
            {
                this._categoryService.Update(category);
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this._categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [UnitOfWork]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = this._categoryService.GetByID(id);
                this._categoryService.Delete(category.CategoryID);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }
    }
}