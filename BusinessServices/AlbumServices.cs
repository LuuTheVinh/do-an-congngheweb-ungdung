using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using AutoMapper;
using BusinessEntities;
using System.Transactions;

namespace BusinessServices
{
    /// <summary>
    /// Specify CRUD operations
    /// </summary>
   public class AlbumServices : IAlbumServices
    {
       private readonly UnitOfWork _unitOfWork;

       /// <summary>
       /// public Constructor
       /// </summary>
       public AlbumServices()
       {
           _unitOfWork = new UnitOfWork();
       }
       /// <summary>
       /// Get Product detail by Id
       /// </summary>
       /// <param name="albumId"></param>
       /// <returns></returns>
        public BusinessEntities.AlbumEntity GetAlbumById(int albumId)
        {

            var album = _unitOfWork.AlbumRepository.GetById(albumId);
            if (album != null)
            {
                var albumModel = Mapper.Map<Album, AlbumEntity>(album);
                return albumModel;
            }
            return null;
        }

       /// <summary>
       /// Get All products
       /// </summary>
       /// <returns></returns>
        public IEnumerable<BusinessEntities.AlbumEntity> GetAllAlbums()
        {
            var albums = _unitOfWork.AlbumRepository.GetAll().ToList();

            if (albums.Any())
            {
                var albumsModel = Mapper.Map<List<Album>, List<AlbumEntity>>(albums);
                return albumsModel;
            }
            return null;
        }

       /// <summary>
       /// Create a new Album 
       /// </summary>
       /// <param name="albumEntity"></param>
       /// <returns></returns>
        public int CreateAlbum(BusinessEntities.AlbumEntity albumEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<AlbumEntity, Album>();
                var album = Mapper.Map<AlbumEntity, Album>(albumEntity);
                _unitOfWork.AlbumRepository.Insert(album);
                _unitOfWork.Save();
                scope.Complete();
                return album.Id;
            }
        }

       /// <summary>
       /// Update Album by Id
       /// </summary>
       /// <param name="albumId"></param>
       /// <param name="albumEntity"></param>
       /// <returns></returns>
        public bool UpdateAlbum(int albumId, BusinessEntities.AlbumEntity albumEntity)
        {
            var success = false;
            if (albumEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var album = Mapper.Map<AlbumEntity, Album>(albumEntity);
                    _unitOfWork.AlbumRepository.Update(album);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

       /// <summary>
       /// Delete Album by Id
       /// </summary>
       /// <param name="albumId"></param>
       /// <returns></returns>
        public bool DeleteAlbum(int albumId)
        {
            var success = false;
            if (albumId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var album = _unitOfWork.AlbumRepository.GetById(albumId);
                    if (album != null)
                    {
                        _unitOfWork.AlbumRepository.Delete(album);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
