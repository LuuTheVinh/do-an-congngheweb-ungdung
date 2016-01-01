using System.Web.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using DataModel;
using BusinessEntities;

namespace DoAnWebNgheNhac
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            CreateMaps();
        }

        protected void CreateMaps()
        {
            Mapper.CreateMap<Artist, ArtistEntity>();
            Mapper.CreateMap<ArtistEntity, Artist>();

            //Mapper.CreateMap<List<Artist>, List<ArtistEntity>>();
            //Mapper.CreateMap<List<ArtistEntity>, List<Artist>>();

            Mapper.CreateMap<Product, ProductEntity>();
            Mapper.CreateMap<ProductEntity, Product>();

            //Mapper.CreateMap<List<Product>, List<ProductEntity>>();
            //Mapper.CreateMap<List<ProductEntity>, List<Product>>();

            Mapper.CreateMap<ArtistProductEntity, ArtistProduct>();
            Mapper.CreateMap<ArtistProduct, ArtistProductEntity>();

            //Mapper.CreateMap<List<ArtistProductEntity>, List<ArtistProduct>>();
            //Mapper.CreateMap<List<ArtistProduct>, List<ArtistProductEntity>>();

            Mapper.CreateMap<Album, AlbumEntity>();
            Mapper.CreateMap<AlbumEntity, Album>();

            Mapper.CreateMap<Video, VideoEntity>();
            Mapper.CreateMap<VideoEntity, Video>();

            Mapper.CreateMap<VideoProduct, VideoProductEntity>();
            Mapper.CreateMap<VideoProductEntity, VideoProduct>();

            Mapper.CreateMap<AlbumProductEntity, AlbumProduct>();
            Mapper.CreateMap<AlbumProduct, AlbumProductEntity>();

            //Mapper.CreateMap<List<AlbumProductEntity>, List<AlbumProduct>>();
            //Mapper.CreateMap<List<AlbumProduct>, List<AlbumProductEntity>>();

            Mapper.CreateMap<AccountInfoEntity, AccountInfo>();
            Mapper.CreateMap<AccountInfo, AccountInfoEntity>();

            Mapper.CreateMap<Playlist, PlaylistEntity>();
            Mapper.CreateMap<PlaylistEntity, Playlist>();

            Mapper.CreateMap<UserArtist, UserArtistEntity>();
            Mapper.CreateMap<UserArtistEntity, UserArtist>();

            Mapper.CreateMap<User, UserEntity>();
            Mapper.CreateMap<UserEntity, User>();

            Mapper.CreateMap<UserComment, UserCommentEntity>();
            Mapper.CreateMap<UserCommentEntity, UserComment>();

            Mapper.CreateMap<UserLike, UserLikeEntity>();
            Mapper.CreateMap<UserLikeEntity, UserLike>();
        }
    }
}