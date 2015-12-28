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
        private readonly IMenuServices _iMenuServices;

        /// <summary>
        /// Home Constructor 
        /// </summary>
        /// <param name="iServices"></param>
        /// <param name="iAlbumServices"></param>
        /// <param name="iAlbumProductServices"></param>
        /// <param name="iMenuServices"></param>
        public HomeController(IServices iServices, IAlbumServices iAlbumServices, IAlbumProductServices iAlbumProductServices, IMenuServices iMenuServices)
        {
            this._iServices = iServices;
            this._iAlbumServices = iAlbumServices;
            this._iAlbumProductServices = iAlbumProductServices;
            this._iMenuServices = iMenuServices;
        }

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            HomeServices homealbums = new HomeServices();
            homealbums.NhacVietHot = _iServices.GetNhacVietHot();
            homealbums.NhacVietMoi = _iServices.GetNhacVietMoi();
            homealbums.GetAlbum = _iServices.GetListAlbums().Where( a => a.ParentId == 69);
            return View(homealbums);         
        }

        /// <summary>
        /// MenuAlbum Action
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MenuAlbum()
        {
            Menu albumMenu = new Menu();
            albumMenu.GetAlbumLevel1 = _iMenuServices.GetListAlbums();
            albumMenu.GetAlbumLevel2 = _iMenuServices.GetListAlbumsLevel2();
            return PartialView(albumMenu);
        }

        /// <summary>
        /// AlbumIndex Action
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult AlbumIndex(int? Id)
        {
            var albums = _iAlbumServices.GetAllAlbums().Where(a => a.ParentId == Id.Value);         
            return View(albums);
        }
        /// <summary>
        /// SearchIndex PartialView
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public PartialViewResult SearchIndex(string searchString)
        {
            var products = _iServices.GetListProducts();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(a => a.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            return PartialView(products);
        }

        /// <summary>
        /// NhacVietHotIndex PartialView
        /// </summary>
        /// <returns></returns>
        public PartialViewResult NhacVietHotIndex()
        {
            var albums = _iServices.GetNhacVietHot();
            return PartialView(albums);
        }

        /// <summary>
        /// NhacVietMoiIndex PartialView
        /// </summary>
        /// <returns></returns>
        public PartialViewResult NhacVietMoiIndex()
        {
            var albums = _iServices.GetNhacVietMoi();
            return PartialView(albums);
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
		
        /// <summary>
        /// PlayMusic Action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PlayMusic(int? id)
        {
            var product = _iServices.GetProductById(id.Value); 
            return View(product);
        }

        public ActionResult PlayAlbum(int? Id)
        {
            var albums = _iAlbumServices.GetAllAlbums().Where(a => a.ParentId == Id.Value);
            return View(albums);
        }
        /// <summary>
        /// PlayVideo Action
        /// </summary>
        /// <returns></returns>
        public ActionResult PlayVideo()
        {
            return View();
        }
    }
}
