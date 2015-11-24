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
    public class VideoController : Controller
    {
        private readonly IVideoServices _iVideoServices;

        public VideoController(IVideoServices iVideoServices)
        {
            this._iVideoServices = iVideoServices;
        }

        //
        // GET: /Video/

        public ActionResult Index()
        {
            var model = _iVideoServices.GetAllVideos();
            return View(model);
        }


        public ActionResult ViewIndex()
        {
            var model = _iVideoServices.GetAllVideos();
            return View(model);
        }

        //
        // GET: /Video/Details/5

        public ActionResult Details(int id = 0)
        {
            VideoEntity video = _iVideoServices.GetVideoById(id);
            video.VideoLevel = _iVideoServices.GetAllVideos().Where(a => a.ParentId == video.Id).ToList();
            if (video.VideoLevel == null)
            {
                return HttpNotFound();
            }
            return View(video.VideoLevel);
        }

        //
        // GET: /Video/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Video/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoEntity video)
        {
            if (ModelState.IsValid)
            {
                _iVideoServices.CreateVideo(video);
                return RedirectToAction("Index");
            }

            return View(video);
        }

        //
        // GET: /Video/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VideoEntity video = _iVideoServices.GetVideoById(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoEntity video)
        {
            if (ModelState.IsValid)
            {
                _iVideoServices.UpdateVideo(video.Id,video);
                return RedirectToAction("Index");
            }
            return View(video);
        }

        //
        // GET: /Video/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VideoEntity video = _iVideoServices.GetVideoById(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        //
        // POST: /Video/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool success = _iVideoServices.DeleteVideo(id);
            if (!success)
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