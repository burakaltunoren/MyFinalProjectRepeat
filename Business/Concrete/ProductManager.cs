using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==19)
            {
                return ErrorDataResult();
            }
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(),true,"Ürünler Listelendi");

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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)                               
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public Product GetById(int productId)
        {
            return _productdal.Get(p=>p.ProductId == productId);
        }





        //buradaki if'te else 'e gerek yok. Çünkü zaten if çalışmışsa return ile bitecewk. İf çalışmıyorsa zaten Ekleme başarılıdır if'lik bir durum yoktur.
    }

}
