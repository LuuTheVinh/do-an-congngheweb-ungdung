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
        private readonly IAlbumServices _iAlbumServices;
        private readonly IAlbumProductServices _iAlbumProductServices;

        public HomeController(IServices iServices, IAlbumServices iAlbumServices, IAlbumProductServices iAlbumProductServices)
        {
            this._iServices = iServices;
            this._iAlbumServices = iAlbumServices;
            this._iAlbumProductServices = iAlbumProductServices;
        }

        public ActionResult Index()
        {

            HomeServices homealbums = new HomeServices();
            homealbums.NhacVietHot = _iServices.GetNhacVietHot();
            homealbums.NhacVietMoi = _iServices.GetNhacVietMoi();
            return View(homealbums);         
        }

        public PartialViewResult SearchIndex(string searchString)
        {
            var products = _iServices.GetListProducts();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(a => a.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            return PartialView(products);
        }

        public PartialViewResult NhacVietHotIndex()
        {
            //var nhacviethot = new HomeServices();
            //nhacviethot.NhacVietHot = _iServices.GetNhacVietHot().ToList();
            var albums = _iServices.GetNhacVietHot();
            return PartialView(albums);
        }

        public PartialViewResult NhacVietMoiIndex()
        {
            //var nhacvietmoi = new HomeServices();
            //nhacvietmoi.NhacVietMoi = _iServices.GetNhacVietMoi().ToList();
            var albums = _iServices.GetNhacVietMoi();
            return PartialView(albums);
            //return PartialView(nhacvietmoi.NhacVietMoi);
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
		
        public ActionResult PlayMusic()
        {
            return View();
        }
    }
}
