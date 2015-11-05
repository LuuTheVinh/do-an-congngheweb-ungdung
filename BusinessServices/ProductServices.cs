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
    public class ProductServices : IProductServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.ProductEntity GetProductById(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetById(productId);
            if (product != null)
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<Product, ProductEntity>(product);
                return productModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        {
            var product = _unitOfWork.ProductRepository.GetAll().ToList();
            if (product.Any())
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<List<Product>, List<ProductEntity>>(product);
                return productModel;
            }
            return null;
        }

        public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ProductEntity, Product>();
                var productModel = Mapper.Map<ProductEntity, Product>(productEntity);
                _unitOfWork.ProductRepository.Insert(productModel);
                _unitOfWork.Save();
                scope.Complete();
                return productModel.Id;
            }
        }

        public bool UpdateProduct(int productId, BusinessEntities.ProductEntity productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    Mapper.CreateMap<ProductEntity, Product>();
                    var product = Mapper.Map<ProductEntity, Product>(productEntity);
                    _unitOfWork.ProductRepository.Update(product);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetById(productId);
                    if (product != null)
                    {
                        _unitOfWork.ProductRepository.Delete(product);
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
