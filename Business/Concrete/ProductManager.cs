using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)       // bana bir tane IProductDal referansı ver???
        {
            _productdal = productdal;
        }

        public List<Product> GetAll()
        {
            // iş kodları
            return _productdal.GetAll();

        }
    }
}
