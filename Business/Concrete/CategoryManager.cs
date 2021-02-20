using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            // eğer varsa iş kodları
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            // Seelct * from Categories where categoryId = 3;  --->  aşağıdaki kodun c=> kısmı bu sql sorgusundaki where'e karşılık gelir.
            return _categoryDal.Get(c=>c.CategoryId == categoryId);
        }


    }
}
