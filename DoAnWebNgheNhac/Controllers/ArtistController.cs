﻿using System;
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
   // [Authorize(Roles = "admin")]
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
            var model = _iArtistServices.GetAllArtists().Where(a => a.Level == 1);
            return View(model);
        }

        [AllowAnonymous]
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
            artist.ArtistLevel2 = _iArtistServices.GetAllArtists().Where(a => a.ParentId == artist.Id).ToList();
            if (artist.ArtistLevel2 == null)
            {
                return HttpNotFound();
            }
            return View(artist.ArtistLevel2);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level <= 2);
            ViewBag.ParentId = new SelectList(artists, "Id", "Tittle");
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
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level <= 2);
            if (artist == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentId = new SelectList(artists, "Id", "Tittle", artist.ParentId);
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtistEntity artist)
        {
            //var artists = _iArtistServices.GetAllArtists().Where(a => a.Level <= 2);
            if (ModelState.IsValid)
            {
                _iArtistServices.UpdateArtist(artist);
                return RedirectToAction("Index");
            }
            //ViewBag.ParentId = new SelectList(artists, "ParentId", "Tittle", artist.ParentId);
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
        public ActionResult SameParent(int parentId = -1)
        {
            if (parentId == -1)
            {
                var artists = new List<ArtistEntity>()
                {
                    _iArtistServices.GetArtistById(8),
                    _iArtistServices.GetArtistById(9)
                };
                return PartialView(artists);
            }
            else
            {
                var artists = _iArtistServices.GetAllArtists().Where(item => item.ParentId == parentId);
                return PartialView(artists);
            }
        }

        public string GetNameById(int id)
        {
            if (_iArtistServices != null)
                return _iArtistServices.GetArtistById(id).Tittle;
            else
                return "";
        }
    }
}