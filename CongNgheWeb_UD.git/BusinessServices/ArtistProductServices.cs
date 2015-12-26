using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
     public class ArtistProductServices : IArtistProductServices
    {
         private readonly UnitOfWork _unitOfWork;

         public ArtistProductServices()
         {
             _unitOfWork = new UnitOfWork();
         }

        public BusinessEntities.ArtistProductEntity GetArtistProductById(int artistProductId)
        {
            var artistProduct = _unitOfWork.ArtistProductRepository.GetById(artistProductId);
            if (artistProduct != null)
            {
                var artistProductModel = Mapper.Map<ArtistProduct, ArtistProductEntity>(artistProduct);
                return artistProductModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.ArtistProductEntity> GetAllArtistProducts()
        {
            var artistProduct = _unitOfWork.ArtistProductRepository.GetAll().ToList();
            if (artistProduct.Any())
            {
                var artistProductModel = Mapper.Map<List<ArtistProduct>, List<ArtistProductEntity>>(artistProduct);
                return artistProductModel;
            }
            return null;
        }

        //public IQueryable<BusinessEntities.ArtistProductEntity> GetAllArtistProductsWithInclude()
        //{
        //    var artistProduct = _unitOfWork.ArtistProductRepository.GetWithInclude();
        //    if (artistProduct.Any())
        //    {
        //        Mapper.CreateMap<ArtistProduct, ArtistProductEntity>().ForMember(x => x.Artist, option => option.Ignore()).ForMember(x => x.Products, option => option.Ignore());//.ForAllMembers(option => option.Ignore());
        //        var artistProductModel = Mapper.Map<List<ArtistProduct>, List<ArtistProductEntity>>(artistProduct);
        //        return artistProductModel;
        //    }
        //    return null;
        //}

        public int CreateArtistProduct(BusinessEntities.ArtistProductEntity artistProductEntity)
        {
            using (var scope = new TransactionScope())
            {
                var artistProduct = Mapper.Map<ArtistProductEntity, ArtistProduct>(artistProductEntity);
                _unitOfWork.ArtistProductRepository.Insert(artistProduct);
                _unitOfWork.Save();
                scope.Complete();
                return artistProduct.Id;
            }
        }

        public bool UpdateArtistProduct(int artistProductId, BusinessEntities.ArtistProductEntity artistProductEntity)
        {
            var success = false;
            if (artistProductEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var artistProduct = Mapper.Map<ArtistProductEntity, ArtistProduct>(artistProductEntity);
                    _unitOfWork.ArtistProductRepository.Update(artistProduct);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteArtistProduct(int artistProductId)
        {
            var success = false;
            if (artistProductId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var artistProduct = _unitOfWork.ArtistProductRepository.GetById(artistProductId);
                    if (artistProduct != null)
                    {
                        _unitOfWork.ArtistProductRepository.Delete(artistProduct);
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
