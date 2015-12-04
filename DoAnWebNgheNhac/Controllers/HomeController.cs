using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebNgheNhac.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices _iServices;

        public HomeController(IServices iServices)
        {
            this._iServices = iServices;
        }

        public ActionResult Index(int id = 0)
        {
            var albums = _iServices.GetListAlbumByParentId(id).Where(a => a.Level == 2).ToList();
            return View(albums);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
