using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;             //referans tip / sadece _products değişkenini oluşturduk
        public InMemoryProductDal()                 // ctor : proje çalıştığında bu ürün listesini üretecek
        {
            {
                _products = new List<Product> { 
                    new Product{ProductId=1, CategoryId=1,ProductName="Bardak", UnitPrice=15,UnitsInStock=15},
                    new Product{ProductId=1, CategoryId=1,ProductName="Kamera", UnitPrice=500,UnitsInStock=3},
                    new Product{ProductId=1, CategoryId=1,ProductName="Telefon", UnitPrice=1500,UnitsInStock=2},
                    new Product{ProductId=1, CategoryId=1,ProductName="Klavye", UnitPrice=150,UnitsInStock=65},
                    new Product{ProductId=1, CategoryId=1,ProductName="Fare", UnitPrice=85,UnitsInStock=1}
                };
            }
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete;
            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);      //  => lambda demek aynı zamanda LINQ uygulaması
            _products.Remove(productToDelete);            
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;                   // veri tabanını olduğu gibi dön
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();       // where içindeki şarta uyan tüm elemanları yeni bir liste haline getirip onu döndürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);      //  => lambda demek aynı zamanda LINQ uygulaması
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitsInStock;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
