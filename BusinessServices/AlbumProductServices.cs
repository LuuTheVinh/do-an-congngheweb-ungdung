using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
    public class AlbumProductServices : IAlbumProductServices
    {
        private readonly UnitOfWork _unitOfWork;

        public AlbumProductServices()
       {
           _unitOfWork = new UnitOfWork();
       }

        public BusinessEntities.AlbumProductEntity GetAlbumProductById(int albumProductId)
        {
            var albumProduct = _unitOfWork.AlbumProductRepository.GetById(albumProductId);
            if (albumProduct != null)
            {
                var albumProductModel = Mapper.Map<AlbumProduct, AlbumProductEntity>(albumProduct);
                return albumProductModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.AlbumProductEntity> GetAllAlbumProducts()
        {
            var albumProduct = _unitOfWork.AlbumProductRepository.GetAll();
            if (albumProduct.Any())
            {
                var albumProductModel = Mapper.Map<IEnumerable<AlbumProduct>, IEnumerable<AlbumProductEntity>>(albumProduct);
                return albumProductModel;
            }
            return null;
        }

        public int CreateAlbumProduct(BusinessEntities.AlbumProductEntity albumProductEntity)
        {
            using (var scope = new TransactionScope())
            {
                var albumProductModel = Mapper.Map<AlbumProductEntity, AlbumProduct>(albumProductEntity);
                _unitOfWork.AlbumProductRepository.Insert(albumProductModel);
                _unitOfWork.Save();
                scope.Complete();
                return albumProductModel.Id;
            }
        }

        public bool UpdateAlbumProduct(int albumProductId, BusinessEntities.AlbumProductEntity albumProductEntity)
        {
            var success = false;
            if (albumProductEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var albumProduct = Mapper.Map<AlbumProductEntity, AlbumProduct>(albumProductEntity);
                    _unitOfWork.AlbumProductRepository.Update(albumProduct);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteAlbumProduct(int albumProductId)
        {
            var success = false;
            if (albumProductId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var albumProduct = _unitOfWork.AlbumProductRepository.GetById(albumProductId);
                    if (albumProduct != null)
                    {
                        _unitOfWork.AlbumProductRepository.Delete(albumProduct);
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
