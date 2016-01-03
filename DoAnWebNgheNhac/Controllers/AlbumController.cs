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
    //[Authorize(Roles="admin")]
    public class AlbumController : Controller
    {
        private readonly IAlbumServices _iAlbumServices;

        public AlbumController(IAlbumServices iAlbumServices)
        {
            this._iAlbumServices = iAlbumServices;
        }

        //
        // GET: /Album/

        public ActionResult Index(string searchString)
        {
            var model = _iAlbumServices.GetAllAlbums().Where(a => a.Level == 1);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(a => a.Tittle.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(model);
        }

        public ActionResult ViewIndex()
        {
            var model = _iAlbumServices.GetAllAlbums().Where(a => a.Level == 3).ToList();
            return View(model);
        }

        
        //
        // GET: /Album/Details/5

        public ActionResult Details(int id = 0)
        {
            AlbumEntity album = _iAlbumServices.GetAlbumById(id);

            album.AlbumLevel2 = _iAlbumServices.GetAllAlbums().Where(a => a.ParentId == album.Id).ToList();

            if (album.AlbumLevel2 == null)
            {
                return HttpNotFound();
            }
            return View(album.AlbumLevel2);
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            var albums = _iAlbumServices.GetAllAlbums().Where(a => a.Level <= 2);
            ViewBag.ParentId = new SelectList(albums, "Id", "Tittle");
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumEntity album)
        {
            //if(String.IsNullOrEmpty(album.ParentId.ToString()))
            //{
            //    album.ParentId = 0;
            //}
            if (ModelState.IsValid)
            {
                _iAlbumServices.CreateAlbum(album);
                return RedirectToAction("Index");
               // return Redirect(Request.UrlReferrer.ToString());
            }
            return View(album);
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AlbumEntity album = _iAlbumServices.GetAlbumById(id);
            var albums = _iAlbumServices.GetAllAlbums();
            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentId = new SelectList(albums, "Id", "Tittle", album.ParentId);
            return View(album);
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumEntity album)
        {
            if (ModelState.IsValid)
            {
                _iAlbumServices.UpdateAlbum(album);
                return RedirectToAction("Index");
            }
            return View(album);
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AlbumEntity album = _iAlbumServices.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /Album/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iAlbumServices.DeleteAlbum(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

        public string GetNameById(int id)
        {
            return _iAlbumServices.GetAlbumById(id).Tittle;
        }
    }
}