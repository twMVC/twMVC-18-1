using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SampleWeb.Models;
using SampleWeb.Models.Interface;
using SampleWeb.Models.Repository;

namespace SampleWeb.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        private ICategoryRepository categoryRepository;

        public IEnumerable<Category> Categories
        {
            get { return categoryRepository.GetAll(); }
        }

        public ProductsController()
        {
            this.productRepository = new ProductRepository();
            this.categoryRepository = new CategoryRepository();
        }

        public ActionResult Index()
        {
            var products = productRepository.GetAll().ToList();
            return View(products);
        }

        public ActionResult Details(int id = 0)
        {
            Product product = productRepository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product products)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Create(products);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        public ActionResult Edit(int id = 0)
        {
            Product product = this.productRepository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product products)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        public ActionResult Delete(int id = 0)
        {
            Product product = this.productRepository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.productRepository.Get(id);
            this.productRepository.Delete(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.productRepository.Dispose();
                this.categoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}