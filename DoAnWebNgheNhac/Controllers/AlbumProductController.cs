using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessServices;

namespace DoAnWebNgheNhac.Controllers
{
   // [Authorize(Roles = "admin")]
    public class AlbumProductController : Controller
    {
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
            return View(albumproducts);
        }

        public ActionResult ViewIndex()
        {
            var albumproducts = _iAlbumProductServices.GetAllAlbumProducts();
            return View(albumproducts);
        }

        //
        // GET: /AlbumProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            AlbumProductEntity albumproduct = _iAlbumProductServices.GetAlbumProductById(id);
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
            ViewBag.AlbumId = new SelectList(albums.Where(a => a.Level == 3).OrderBy(a => a.Tittle), "Id", "Tittle");
            ViewBag.ProductId = new SelectList(products.Where(a => a.Category != "Video").OrderBy(a => a.Name), "Id", "Name");
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

        private ActionResult PlayList(int albumId = -1)
        {
            if (albumId == -1)
            {
                albumId = 65; // for test
            }
            var all_product = _iAlbumProductServices.GetAllAlbumProducts();
            var productsId = _iAlbumProductServices.GetAllAlbumProducts().Where(album => album.AlbumId == albumId)
                .Select(album => album.ProductId);
            List<ProductEntity> products = new List<ProductEntity>();
            foreach (var id in productsId)
            {
                products.Add(_iProductServices.GetProductById(id));
            }
            return PartialView(products);
        }

        public ActionResult PlayList(IEnumerable<ProductEntity> products)
        {
            if (products == null)
            {
                return PlayList(-1);
            }
            return PartialView(products);
        }

        private void getChildAlbumId(int albumId, List<int> resultlist)
        {
            // Lấy tất cả album con
            var album = _iAlbumServices.GetAlbumById(albumId);
            if (album.Level == 3)
            {
                resultlist.Add(albumId);
                return;
            }
            else
            {
                var all_album = _iAlbumServices.GetAllAlbums();
                var child_album = all_album.Where(alb => alb.ParentId == albumId);
                foreach (var child in child_album)
                {
                    getChildAlbumId(child.Id, resultlist);
                }
            }
        }
    }
}