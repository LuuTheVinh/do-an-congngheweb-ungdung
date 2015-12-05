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
    public class AlbumProductController : Controller
    {
        private WebNgheNhacDb1Entities db = new WebNgheNhacDb1Entities();
        private readonly IAlbumProductServices _iAlbumProductServices;
        private readonly IAlbumServices _iAlbumServices;
        private readonly IProductServices _iProductServices;
        public AlbumProductController(IAlbumProductServices iAlbumProductServices, IAlbumServices iAlbumServices, IProductServices iProductServices)
        {
            this._iAlbumProductServices = iAlbumProductServices;
            this._iAlbumServices = iAlbumServices;
            this._iProductServices = iProductServices;
        }

        //
        // GET: /AlbumProduct/

        public ActionResult Index()
        {
            var albumproducts = _iAlbumProductServices.GetAllAlbumProducts();
            return View(albumproducts.ToList());
        }

        //
        // GET: /AlbumProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            AlbumProduct albumproduct = db.AlbumProducts.Find(id);
            if (albumproduct == null)
            {
                return HttpNotFound();
            }
            return View(albumproduct);
        }

        //
        // GET: /AlbumProduct/Create

        public ActionResult Create()
        {
            var albums = _iAlbumServices.GetAllAlbums();
            var products = _iProductServices.GetAllProducts();
            ViewBag.AlbumId = new SelectList(albums, "Id", "Tittle");
            ViewBag.ProductId = new SelectList(products, "Id", "Name");
            return View();
        }

        //
        // POST: /AlbumProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumProductEntity albumproduct)
        {
            if (ModelState.IsValid)
            {
                _iAlbumProductServices.CreateAlbumProduct(albumproduct);
                return RedirectToAction("Index");
            }

            //ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle", albumproduct.AlbumId);
            //ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", albumproduct.ProductId);
            return View(albumproduct);
        }

        //
        // GET: /AlbumProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AlbumProductEntity albumproduct = _iAlbumProductServices.GetAlbumProductById(id);
            var albums = _iAlbumServices.GetAllAlbums();
            var products = _iProductServices.GetAllProducts();
            if (albumproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(albums, "Id", "Tittle", albumproduct.AlbumId);
            ViewBag.ProductId = new SelectList(products, "Id", "Name", albumproduct.ProductId);
            return View(albumproduct);
        }

        //
        // POST: /AlbumProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumProductEntity albumproduct)
        {
            if (ModelState.IsValid)
            {
                _iAlbumProductServices.UpdateAlbumProduct(albumproduct.Id, albumproduct);
                return RedirectToAction("Index");
            }
            //ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle", albumproduct.AlbumId);
            //ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", albumproduct.ProductId);
            return View(albumproduct);
        }

        //
        // GET: /AlbumProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AlbumProductEntity albumproduct = _iAlbumProductServices.GetAlbumProductById(id);
            if (albumproduct == null)
            {
                return HttpNotFound();
            }
            return View(albumproduct);
        }

        //
        // POST: /AlbumProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iAlbumProductServices.DeleteAlbumProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}