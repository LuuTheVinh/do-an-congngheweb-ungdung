using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using BusinessEntities;
using BusinessServices;

namespace DoAnWebNgheNhac.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductServices _iProductServices;
        private readonly IArtistProductServices _iArtistProductServices;

        public ProductController(IProductServices iProductServices, IArtistProductServices iArtistProductServices)
        {
            this._iProductServices = iProductServices;
            this._iArtistProductServices = iArtistProductServices;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
           // var products = db.Products.Include(p => p.ArtistProduct);
           // var artistproducts = _iProductServices.GetAllProducts();
            var products = _iProductServices.GetAllProducts();
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            var artistproducts = _iArtistProductServices.GetAllArtistProducts();
            ViewBag.ArtistProductId = new SelectList(artistproducts, "Id", "StageName");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductEntity product)
        {
            if (ModelState.IsValid)
            {
                _iProductServices.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var artistproducts = _iArtistProductServices.GetAllArtistProducts();
            ViewBag.ArtistProductId = new SelectList(artistproducts, "Id", "StageName", product.ArtistProductId);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEntity product)
        {
            if (ModelState.IsValid)
            {
                _iProductServices.UpdateProduct(product.Id, product);
                return RedirectToAction("Index");
            }
        //    ViewBag.ArtistProductId = new SelectList(db.ArtistProducts, "Id", "StageName", product.ArtistProductId);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductEntity product = _iProductServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iProductServices.DeleteProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}