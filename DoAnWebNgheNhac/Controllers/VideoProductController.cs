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
    public class VideoProductController : Controller
    {
        private readonly IVideoProductServices _iVideoProductServices;
        private readonly IProductServices _iProductServices;
        private readonly IVideoServices _iVideoServices;

        public VideoProductController(IVideoProductServices iVideoProductServices, IProductServices iProductServices, IVideoServices iVideoServices)
        {
            this._iVideoProductServices = iVideoProductServices;
            this._iProductServices = iProductServices;
            this._iVideoServices = iVideoServices;
        }
        //
        // GET: /VideoProduct/

        public ActionResult Index()
        {
            var videoproducts = _iVideoProductServices.GetAllVideoProducts();
            return View(videoproducts.ToList());
        }

        //
        // GET: /VideoProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            VideoProductEntity videoproduct = _iVideoProductServices.GetVideoProductById(id);
            if (videoproduct == null)
            {
                return HttpNotFound();
            }
            return View(videoproduct);
        }

        //
        // GET: /VideoProduct/Create

        public ActionResult Create()
        {
            var products = _iProductServices.GetAllProducts();
            var videos = _iVideoServices.GetAllVideos();
            ViewBag.ProductId = new SelectList(products.Where(a => a.Category == "Video"), "Id", "Name");
            ViewBag.VideoId = new SelectList(videos.Where(a => a.Level == 2), "Id", "Tittle");
            return View();
        }

        //
        // POST: /VideoProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoProductEntity videoproduct)
        {
            if (ModelState.IsValid)
            {
                _iVideoProductServices.CreateVideoProduct(videoproduct);
                return RedirectToAction("Index");
            }

            //ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", videoproduct.ProductId);
            //ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // GET: /VideoProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VideoProductEntity videoproduct = _iVideoProductServices.GetVideoProductById(id);
            var videos = _iVideoServices.GetAllVideos();
            var products = _iProductServices.GetAllProducts();
            if (videoproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(products, "Id", "Name", videoproduct.ProductId);
            ViewBag.VideoId = new SelectList(videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // POST: /VideoProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoProductEntity videoproduct)
        {
            if (ModelState.IsValid)
            {
                _iVideoProductServices.UpdateVideoProduct(videoproduct.Id, videoproduct);
                return RedirectToAction("Index");
            }
            //ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", videoproduct.ProductId);
            //ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // GET: /VideoProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VideoProductEntity videoproduct = _iVideoProductServices.GetVideoProductById(id);
            if (videoproduct == null)
            {
                return HttpNotFound();
            }
            return View(videoproduct);
        }

        //
        // POST: /VideoProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iVideoProductServices.DeleteVideoProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}