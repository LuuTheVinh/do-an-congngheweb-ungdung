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
    public class ArtistProductController : Controller
    {
        private readonly IArtistProductServices _iArtistProductServices;
        private readonly IArtistServices _iArtistServices;

        public ArtistProductController(IArtistProductServices iArtistProductServices, IArtistServices iArtistServices)
        {
            this._iArtistProductServices = iArtistProductServices;
            this._iArtistServices = iArtistServices;
        }

        //
        // GET: /ArtistProduct/

        public ActionResult Index()
        {
            var artistproducts = _iArtistProductServices.GetAllArtistProducts();
            return View(artistproducts.ToList());
        }

        //
        // GET: /ArtistProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // GET: /ArtistProduct/Create

        public ActionResult Create()
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level == 3);
            ViewBag.ArtistId = new SelectList(artists, "Id", "Tittle");
            return View();
        }

        //
        // POST: /ArtistProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistProductEntity artistproductEntity)
        {
            if (ModelState.IsValid)
            {
                _iArtistProductServices.CreateArtistProduct(artistproductEntity);
                return RedirectToAction("Index");
            }

          //  ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproductEntity);
        }

        //
        // GET: /ArtistProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level == 3);
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ArtistId = new SelectList(artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproduct);
        }

        //
        // POST: /ArtistProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtistProductEntity artistproductEntity)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(artistproduct).State = EntityState.Modified;
                //db.SaveChanges();
                _iArtistProductServices.UpdateArtistProduct(artistproductEntity.Id, artistproductEntity);
                return RedirectToAction("Index");
            }
           // ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproductEntity);
        }

        //
        // GET: /ArtistProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // POST: /ArtistProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            bool success = _iArtistProductServices.DeleteArtistProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}