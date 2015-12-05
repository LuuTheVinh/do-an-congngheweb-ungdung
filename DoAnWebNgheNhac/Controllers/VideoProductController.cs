using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;

namespace DoAnWebNgheNhac.Controllers
{
    public class VideoProductController : Controller
    {
        private WebNgheNhacDb1Entities db = new WebNgheNhacDb1Entities();

        //
        // GET: /VideoProduct/

        public ActionResult Index()
        {
            var videoproducts = db.VideoProducts.Include(v => v.Product).Include(v => v.Video);
            return View(videoproducts.ToList());
        }

        //
        // GET: /VideoProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            VideoProduct videoproduct = db.VideoProducts.Find(id);
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
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle");
            return View();
        }

        //
        // POST: /VideoProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoProduct videoproduct)
        {
            if (ModelState.IsValid)
            {
                db.VideoProducts.Add(videoproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", videoproduct.ProductId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // GET: /VideoProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VideoProduct videoproduct = db.VideoProducts.Find(id);
            if (videoproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", videoproduct.ProductId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // POST: /VideoProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoProduct videoproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", videoproduct.ProductId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Tittle", videoproduct.VideoId);
            return View(videoproduct);
        }

        //
        // GET: /VideoProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VideoProduct videoproduct = db.VideoProducts.Find(id);
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
            VideoProduct videoproduct = db.VideoProducts.Find(id);
            db.VideoProducts.Remove(videoproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}