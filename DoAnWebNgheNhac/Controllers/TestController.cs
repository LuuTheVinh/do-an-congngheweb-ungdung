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
    public class TestController : Controller
    {
        private WebNgheNhacDb1Entities db = new WebNgheNhacDb1Entities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var artistproducts = db.ArtistProducts.Include(a => a.Artist);
            return View(artistproducts.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            ArtistProduct artistproduct = db.ArtistProducts.Find(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle");
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistProduct artistproduct)
        {
            if (ModelState.IsValid)
            {
                db.ArtistProducts.Add(artistproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproduct);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ArtistProduct artistproduct = db.ArtistProducts.Find(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproduct);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtistProduct artistproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproduct);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ArtistProduct artistproduct = db.ArtistProducts.Find(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistProduct artistproduct = db.ArtistProducts.Find(id);
            db.ArtistProducts.Remove(artistproduct);
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