﻿using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public class MenuServices : IMenuServices
    {
        private readonly UnitOfWork _unitOfWork;

       /// <summary>
       /// public Constructor
       /// </summary>
        public MenuServices()
       {
           _unitOfWork = new UnitOfWork();
       }
        public IEnumerable<BusinessEntities.AlbumEntity> GetListAlbums()
        {
            var albums = _unitOfWork.AlbumRepository.GetAll().Where(a => a.Level == 1).ToList();
            if (albums.Any())
            {
                var albumsModel = Mapper.Map<List<Album>, List<AlbumEntity>>(albums);
                return albumsModel;
            }
            return new List<AlbumEntity>();
        }

        public IEnumerable<BusinessEntities.AlbumEntity> GetListAlbumsLevel2()
        {
            var albums = _unitOfWork.AlbumRepository.GetAll().Where(a => a.Level == 2).ToList();
            if (albums.Any())
            {
                var albumsModel = Mapper.Map<List<Album>, List<AlbumEntity>>(albums);
                return albumsModel;
            }
            return new List<AlbumEntity>();
        }


        public IEnumerable<VideoEntity> GetListVideos()
        {
            var videos = _unitOfWork.VideoRepository.GetAll().Where(a => a.Level == 1).ToList();
            if (videos.Any())
            {
                var videosModel = Mapper.Map<List<Video>, List<VideoEntity>>(videos);
                return videosModel;
            }
            return new List<VideoEntity>();
        }

        public IEnumerable<VideoEntity> GetListVideosLevel2()
        {
            var videos = _unitOfWork.VideoRepository.GetAll().Where(a => a.Level == 2).ToList();
            if (videos.Any())
            {
                var videosModel = Mapper.Map<List<Video>, List<VideoEntity>>(videos);
                return videosModel;
            }
            return new List<VideoEntity>();
        }


        public IEnumerable<ArtistEntity> GetListArtists()
        {
            var artists = _unitOfWork.ArtistRepository.GetAll().Where(a => a.Level == 1).ToList();
            if (artists.Any())
            {
                var artistsModel = Mapper.Map<List<Artist>, List<ArtistEntity>>(artists);
                return artistsModel;
            }
            return new List<ArtistEntity>();
        }

        public IEnumerable<ArtistEntity> GetListArtistsLevel2()
        {
            var artists = _unitOfWork.ArtistRepository.GetAll().Where(a => a.Level == 2).ToList();
            if (artists.Any())
            {
                var artistsModel = Mapper.Map<List<Artist>, List<ArtistEntity>>(artists);
                return artistsModel;
            }
            return new List<ArtistEntity>();
        }
    }
}
