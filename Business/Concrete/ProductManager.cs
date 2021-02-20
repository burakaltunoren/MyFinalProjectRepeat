using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;                            // Business katmanı kime bağımı? Cevap: Veri Erişime (DataAccess'e)

        public ProductManager(IProductDal productdal)       // bana bir tane IProductDal referansı ver???
        {
            _productdal = productdal;
        }

        public IEnumerable<Product> GetAllByCategoryId()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            // iş kodları
            return _productdal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productdal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productdal.GetProductDetails();
        }
    }
}
