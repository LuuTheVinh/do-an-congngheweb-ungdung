using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using BusinessEntities;
using BusinessServices;

namespace DoAnWebNgheNhac.Controllers
{
    public class AccountInfoController : Controller
    {
        private WebNgheNhacDb1Entities db = new WebNgheNhacDb1Entities();
        private readonly IAccountInforServices _iAccountInforServices;

        public AccountInfoController(IAccountInforServices iAccountInforServices)
        {
            this._iAccountInforServices = iAccountInforServices;
        }

        //
        // GET: /AccountInfo/

        public ActionResult Index()
        {
            var accountInfoes = _iAccountInforServices.GetAllAccountInfo();
            return View(accountInfoes);
        }

        //
        // GET: /AccountInfo/Details/5

        public ActionResult Details(int id = 0)
        {
            AccountInfo accountinfo = db.AccountInfoes.Find(id);
            if (accountinfo == null)
            {
                return HttpNotFound();
            }
            return View(accountinfo);
        }

        //
        // GET: /AccountInfo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AccountInfo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountInfo accountinfo)
        {
            if (ModelState.IsValid)
            {
                db.AccountInfoes.Add(accountinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountinfo);
        }

        //
        // GET: /AccountInfo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AccountInfo accountinfo = db.AccountInfoes.Find(id);
            if (accountinfo == null)
            {
                return HttpNotFound();
            }
            return View(accountinfo);
        }

        //
        // POST: /AccountInfo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountInfo accountinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountinfo);
        }

        //
        // GET: /AccountInfo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AccountInfo accountinfo = db.AccountInfoes.Find(id);
            if (accountinfo == null)
            {
                return HttpNotFound();
            }
            return View(accountinfo);
        }

        //
        // POST: /AccountInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountInfo accountinfo = db.AccountInfoes.Find(id);
            db.AccountInfoes.Remove(accountinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}