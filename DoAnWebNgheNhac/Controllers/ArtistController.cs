using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessServices;
using BusinessEntities;

namespace DoAnWebNgheNhac.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistServices _iArtistServices;

        public ArtistController(IArtistServices iArtistServices)
        {
            this._iArtistServices = iArtistServices;
        }

        //
        // GET: /Artist/

        public ActionResult Index()
        {
            var model = _iArtistServices.GetAllArtists();
            return View(model);
        }

        public ActionResult ViewIndex()
        {
            var model = _iArtistServices.GetAllArtists();
            return View(model);
        }

        //
        // GET: /Artist/Details/5

        public ActionResult Details(int id = 0)
        {
            ArtistEntity artist = _iArtistServices.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistEntity artist)
        {
            if (ModelState.IsValid)
            {
                _iArtistServices.CreateArtist(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /Artist/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ArtistEntity artist = _iArtistServices.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtistEntity artist)
        {
            if (ModelState.IsValid)
            {
                _iArtistServices.UpdateArtist(artist.Id, artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /Artist/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ArtistEntity artist = _iArtistServices.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iArtistServices.DeleteArtist(id);
            if(!success)
            {
                ModelState.AddModelError("Error", "Delete Failed");
                return View();
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}