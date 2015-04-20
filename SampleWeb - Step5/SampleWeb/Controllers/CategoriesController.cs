using System.Data;
using System.Linq;
using System.Web.Mvc;
using SampleWeb.Models;
using SampleWeb.Service;
using SampleWeb.Service.Interface;

namespace SampleWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService categoryService;

        public CategoriesController()
        {
            this.categoryService = new CategoryService();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll().ToList();
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
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Category category)
        {
            if (category != null &&
                ModelState.IsValid)
            {
                this.categoryService.Create(category);
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
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Categories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (category != null &&
                ModelState.IsValid)
            {
                this.categoryService.Update(category);
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
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = this.categoryService.GetByID(id);
                this.categoryService.Delete(category.CategoryID);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }
    }
}