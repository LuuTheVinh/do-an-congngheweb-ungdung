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
    public class BXHController : Controller
    {
        private readonly IProductServices _iProductSerices;
        public BXHController(IProductServices iProductServices)
        {
            this._iProductSerices = iProductServices;
        }

        //
        // GET: /BXH/

        public ActionResult Index()
        {
            //var products = new ProductEntity();
            var bxh = _iProductSerices.GetAllProducts().OrderByDescending(a => a.Views).Where(a => a.Category != "Video");
            return View(bxh);
        }

        public ActionResult ViewIndex()
        {
            //var products = new ProductEntity();
            var bxh = _iProductSerices.GetAllProducts().OrderByDescending(a => a.Views).Where(a => a.Category != "Video");
            return View(bxh);
        }
      
    }
}