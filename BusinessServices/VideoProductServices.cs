using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using AutoMapper;
using System.Transactions;
using DataModel;

namespace BusinessServices
{
   public class VideoProductServices: IVideoProductServices
    {

       private readonly UnitOfWork _unitOfWork;

       public VideoProductServices()
       {
           _unitOfWork = new UnitOfWork();
       }

        public BusinessEntities.VideoProductEntity GetVideoProductById(int videoProductId)
        {
            var videoProduct = _unitOfWork.VideoProductRepository.GetById(videoProductId);
            if (videoProduct != null)
            {
                var videoProductModel = Mapper.Map<VideoProduct, VideoProductEntity>(videoProduct);
                return videoProductModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.VideoProductEntity> GetAllVideoProducts()
        {
            var videoProducts = _unitOfWork.VideoProductRepository.GetAll();
            if (videoProducts.Any())
            {
                var videoProductsModel = Mapper.Map<IEnumerable<VideoProduct>, IEnumerable<VideoProductEntity>>(videoProducts);
                return videoProductsModel;
            }
            return null;
        }

        public int CreateVideoProduct(BusinessEntities.VideoProductEntity videoProductEntity)
        {
            using (var scope = new TransactionScope())
            {
                var videoProduct = Mapper.Map<VideoProductEntity, VideoProduct>(videoProductEntity);
                _unitOfWork.VideoProductRepository.Insert(videoProduct);
                _unitOfWork.Save();
                scope.Complete();
                return videoProduct.Id;
            }
        }

        public bool UpdateVideoProduct(int videoProductId, BusinessEntities.VideoProductEntity videoProductEntity)
        {
            var success = false;
            if (videoProductEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                        var videoProduct = Mapper.Map<VideoProductEntity, VideoProduct>(videoProductEntity);
                        _unitOfWork.VideoProductRepository.Update(videoProduct);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                }
            }
            return success;
        }

        public bool DeleteVideoProduct(int videoProductId)
        {
            var success = false;
            if (videoProductId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var videoProduct = _unitOfWork.VideoProductRepository.GetById(videoProductId);
                    if (videoProduct != null)
                    {
                        _unitOfWork.VideoProductRepository.Delete(videoProduct);
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
