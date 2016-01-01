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
    public class ArtistProductController : Controller
    {
        private readonly IArtistProductServices _iArtistProductServices;
        private readonly IArtistServices _iArtistServices;

        public ArtistProductController(IArtistProductServices iArtistProductServices, IArtistServices iArtistServices)
        {
            this._iArtistProductServices = iArtistProductServices;
            this._iArtistServices = iArtistServices;
        }

        //
        // GET: /ArtistProduct/

        public ActionResult Index()
        {
            var artistproducts = _iArtistProductServices.GetAllArtistProducts().OrderBy(a => a.StageName);
            return View(artistproducts.ToList());
        }

        //
        // GET: /ArtistProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // GET: /ArtistProduct/Create

        public ActionResult Create()
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level == 3);
            ViewBag.ArtistId = new SelectList(artists.OrderBy(a => a.Tittle), "Id", "Tittle");
            return View();
        }

        //
        // POST: /ArtistProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistProductEntity artistproductEntity)
        {
            if (ModelState.IsValid)
            {
                _iArtistProductServices.CreateArtistProduct(artistproductEntity);
                return RedirectToAction("Index");
            }

            //  ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproductEntity);
        }

        //
        // GET: /ArtistProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.Level == 3);
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }

            ViewBag.ArtistId = new SelectList(artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproduct);
        }

        //
        // POST: /ArtistProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtistProductEntity artistproductEntity)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(artistproduct).State = EntityState.Modified;
                //db.SaveChanges();
                _iArtistProductServices.UpdateArtistProduct(artistproductEntity.Id, artistproductEntity);
                return RedirectToAction("Index");
            }
            // ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Tittle", artistproduct.ArtistId);
            return View(artistproductEntity);
        }

        //
        // GET: /ArtistProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            if (artistproduct == null)
            {
                return HttpNotFound();
            }
            return View(artistproduct);
        }

        //
        // POST: /ArtistProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ArtistProductEntity artistproduct = _iArtistProductServices.GetArtistProductById(id);
            bool success = _iArtistProductServices.DeleteArtistProduct(id);

            if (!success)
            {
                ModelState.AddModelError("error", "delete fail");
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewArtist(int artistId = -1)
        {
            if (artistId == -1)
            {
                ArtistProductEntity artist = getArtistTestValue();
                return View(artist);
            }
            else
            {
                ArtistProductEntity artist = _iArtistProductServices.GetArtistProductById(artistId);
                return View(artist);
            }
        }

        public ActionResult Songs(int artistId = -1)
        {
            // Lấy những bài hát của cùng môt ca sĩ
            if (artistId == -1)
            {
                ICollection<ProductEntity> products = getProductsTestValue();
                ViewData["ArtistName"] = getTestArtistName();
                System.Diagnostics.Debug.Write("artistId = -1");
                return PartialView(products.Where(product => product.Category != "Mv"));
            }
            var allartistproduct = _iArtistProductServices.GetAllArtistProducts();

            if (allartistproduct == null)
                return null;
            if (allartistproduct.Any())
            {
                var foundArtist = allartistproduct.Where(art => art.ArtistId == artistId);
                IEnumerable<ProductEntity> products = null;
                if (foundArtist.Any())
                {
                    products = foundArtist.First().Products;
                    if (products != null)
                    {
                        products = products.Where(product => product.Category != "Mv");
                    }
                    ViewData["ArtistName"] = foundArtist.First().StageName;
                    return PartialView(products);
                }
            }
            return null;

        }
        public ActionResult Videos(int artistId = -1)
        {
            // Lất những video của một ca sĩ.
            if (artistId == -1)
            {
                var products = getProductsTestValue();
                return PartialView(products.Where(product => product.Category == "MV"));
            }
            else
            {
                var allartistproduct = _iArtistProductServices.GetAllArtistProducts();

                var foundartist = allartistproduct.Where(artist => artist.ArtistId == artistId);
                string artistname = String.Empty;
                if (foundartist.Any())
                {
                    IEnumerable<ProductEntity> products = foundartist.First().Products;
                    if (products != null)
                    {
                        products = products.Where(product => product.Category == "Mv");
                    }
                    ViewData["ArtistName"] = foundartist.First().StageName;

                    return PartialView(products);
                }
            }
            return null;
        }
        private string getTestArtistName()
        {
            return getArtistTestValue().StageName;
        }

        private ICollection<ProductEntity> getProductsTestValue()
        {
          
            return new List<ProductEntity>()
            {
                new ProductEntity(){Name = "Nắng Và Mưa",  Views =  2594599, ArtistProductId = -1, Id = 1},
                new ProductEntity(){Name = "Đôi Khi Muốn",  Views = 3943778, ArtistProductId = -1, Id = 2},
                new ProductEntity(){Name = "Đàn Ông Là Thế (Remix)",  Views = 180565, ArtistProductId = -1, Id = 3},
                new ProductEntity(){Name = "Hai Ba Năm",Views = 6889405, ArtistProductId = -1, Id = 4},
                new ProductEntity(){Name = "Trang Giấy Trắng", Views = 3329897, ArtistProductId = -1, Id = 5},
                new ProductEntity(){Name = "Đừng Đánh Mất Hạnh Phúc", Views =  340335, ArtistProductId = -1, Id = 6},
                new ProductEntity(){Name = "Hai Ba Năm", Views = 6889405, ArtistProductId = -1, Id = 7},
                new ProductEntity(){Name = "Hai Ba Năm", Views = 6889405, ArtistProductId = -1, Id = 8},
                new ProductEntity(){Name = "Người Dự Bị", Views = 1700114, ArtistProductId = -1, Id = 9},
                new ProductEntity(){Name = "Siêu nhân đại chiến", Category = "MV", Views = 271, ArtistProductId = -1, Id = 10},
                new ProductEntity(){Name = "Thuỷ Thủ Mặt Trăng",Category = "MV", Views = 6889405, ArtistProductId = -1, Id = 11},
                new ProductEntity(){Name = "Kamen Raider OOO Full Hd", Category = "MV", Views = 6889405, ArtistProductId = -1, Id = 12},
            };
        }

        private ArtistProductEntity getArtistTestValue()
        {
            return new ArtistProductEntity()
            {
                Artist = _iArtistServices.GetArtistById(8),
                BirthDay = new DateTime(1995, 11, 26),
                Description = "Tôi là một lập trình viên chứ không phải một ca sĩ",
                Gender = "Nam",
                GroupId = 0,
                Id = -1,
                Products = getProductsTestValue(),
                RealName = "Hồ Hoàng Tùng",
                Specialization = "Lập trình viên",
                StageName = "7ung",
                Thumbnail = "7ung.jpg",
                UserArtists = null
            };
        }

    }
}