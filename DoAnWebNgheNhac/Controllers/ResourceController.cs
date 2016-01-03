using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebNgheNhac.Controllers
{
   // [Authorize(Roles = "admin")]
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexFile()
        {
            return View();
        }
    }
}
