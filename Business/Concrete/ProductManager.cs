﻿using Business.Abstract;
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
        IProductDal _productdal;                            // Business katmanı kime bağımı? Cevap: Veri Erişime (DataAccess'e) . Ayrıca bu satır bir field.

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
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productdal.GetProductDetails());
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productdal.Get(p => p.ProductId == productId));
        }







        //buradaki if'te else 'e gerek yok. Çünkü zaten if çalışmışsa return ile bitecewk. İf çalışmıyorsa zaten Ekleme başarılıdır if'lik bir durum yoktur.
    }

}
