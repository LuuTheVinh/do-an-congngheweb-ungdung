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
        private readonly IVideoProductServices _iVideoProductServices;
        private readonly IVideoServices _iVideoServices;
        private readonly IArtistServices _iArtistServices;
        private readonly IArtistProductServices _iArtistProductServices;

        private readonly IProductServices _iProductServices;
        /// <summary>
        /// Home Constructor 
        /// </summary>
        /// <param name="iServices"></param>
        /// <param name="iAlbumServices"></param>
        /// <param name="iAlbumProductServices"></param>
        /// <param name="iMenuServices"></param>

        public HomeController(IServices iServices, IAlbumServices iAlbumServices, IAlbumProductServices iAlbumProductServices, IMenuServices iMenuServices, IProductServices iProductServices
            , IVideoProductServices iVideoProductService, IVideoServices iVideoServices, IArtistServices iArtistServices, IArtistProductServices iArtistProductServices)

        {
            this._iServices = iServices;
            this._iAlbumServices = iAlbumServices;
            this._iAlbumProductServices = iAlbumProductServices;
            this._iMenuServices = iMenuServices;
            this._iProductServices = iProductServices;
            this._iVideoProductServices = iVideoProductService;
            this._iVideoServices = iVideoServices;
            this._iArtistServices = iArtistServices;
            this._iArtistProductServices = iArtistProductServices;

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
            homealbums.GetVideo = _iVideoProductServices.GetAllVideoProducts();
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
        /// MenuVideo
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MenuVideo()
        {
            Menu videoMenu = new Menu();
            videoMenu.GetVideoLevel1 = _iMenuServices.GetListVideos();
            videoMenu.GetVideoLevel2 = _iMenuServices.GetListVideosLevel2();
            return PartialView(videoMenu);
        }

        /// <summary>
        /// MenuArtist
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MenuArtist()
        {
            Menu artistMenu = new Menu();
            artistMenu.GetArtistLevel1 = _iMenuServices.GetListArtists();
            artistMenu.GetArtistLevel2 = _iMenuServices.GetListArtistsLevel2();
            return PartialView(artistMenu);
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
        /// VideoIndex
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult VideoIndex(int? Id)
        {
            var videos = _iVideoProductServices.GetAllVideoProducts().Where(a => a.VideoId == Id.Value);
            return View(videos);
        }

        /// <summary>
        /// ArtistIndex
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult ArtistIndex(int? Id)
        {
            var artists = _iArtistServices.GetAllArtists().Where(a => a.ParentId == Id.Value);
            return View(artists);
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

        public ActionResult PlayAlbum(int? albumId)
        {
            int _id = 0;
            if (albumId.HasValue == false)
            {
                _id = 65;
            }
            else
            {
                _id = albumId.Value;
            }
            var all_product = _iAlbumProductServices.GetAllAlbumProducts();
            var productsId = _iAlbumProductServices.GetAllAlbumProducts().Where(album => album.AlbumId == albumId)
                .Select(album => album.ProductId);
            if (productsId.Any() == false)
            {
                return null;
            }
            List<BusinessEntities.ProductEntity> products = new List<BusinessEntities.ProductEntity>();
            foreach (var id in productsId)
            {
                products.Add(_iProductServices.GetProductById(id));
            }
            
            return View(products);
        }
        /// <summary>
        /// PlayVideo Action
        /// </summary>
        /// <returns></returns>
        public ActionResult PlayVideo(int? Id)
            {
            var videos = _iServices.GetProductById(Id.Value); 
                return View(videos);
            }
        }

        private BusinessEntities.ProductEntity getTestVideoValue()
        {
            return new BusinessEntities.ProductEntity()
            {
                AlbumProducts = new List<BusinessEntities.AlbumProductEntity>
                {
                    new BusinessEntities.AlbumProductEntity()
                    {
                        Album = new BusinessEntities.AlbumEntity()
                        {
                            Tittle = "Phim thiếu nhi"
                        }
                    }
                },
                ArtistProduct = new BusinessEntities.ArtistProductEntity()
                {
                    StageName = "7ung",
                    ArtistId = -1,
                },
                ArtistProductId = -1,
                Category = "Video",
                Description = "Tokumei Sentai Go-Busters là series Super Sentai thứ 36 của Toei Company, tiếp nối Kaizoku Sentai Gokaiger.\nBộ phim được phát sóng lần đầu tiên vào ngày 26 tháng 2, 2012 trên TV Asahi, song song với Kamen Rider Fourze trong Super Hero Time",
                Id = -1,
                Name = "Go Buster",
                Thumbnail = "../../Videos/Shi jin.mp4",
                URL = "../../Images/judithhill.jpg",
                UserComments = null,
                UserLikes = null,
                VideoProducts = null,
                Views = 123
            };
        }
    }
}
