using AutoMapper;
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
    public class Services : IServices
    {
        private readonly UnitOfWork _unitOfWork;

       /// <summary>
       /// public Constructor
       /// </summary>
        public Services()
       {
           _unitOfWork = new UnitOfWork();
       }

        public IEnumerable<AlbumEntity> GetListAlbums()
        {
            var albums = _unitOfWork.AlbumRepository.GetAll().ToList();
            if (albums.Any())
            {
                var albumsModel = Mapper.Map<List<Album>, List<AlbumEntity>>(albums);
                return albumsModel;
            }
            return new List<AlbumEntity>();
        }

        /// <summary>
        /// Get list albums by parentId
        /// </summary>
        /// <param name="parentId">albumId</param>
        /// <returns></returns>
        public IEnumerable<AlbumEntity> GetListAlbumByParentId(int parentId) 
        {
            var list = new List<Album>();
            if (parentId != 0)
            {
                list = _unitOfWork.AlbumRepository.GetAll().Where(a => a.ParentId == parentId).ToList();
            }
            else {
                list = _unitOfWork.AlbumRepository.GetAll().ToList();
            }
            if (list.Any())
            {
                var albumsModel = Mapper.Map<List<Album>, List<AlbumEntity>>(list);
                return albumsModel;
            }
            return new List<AlbumEntity>();
        }
    }
}
