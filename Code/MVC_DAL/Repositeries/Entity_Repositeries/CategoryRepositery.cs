using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public class CategoryRepositery : ICategoryRepositery
    {

        StoreContext StoreDBContext;
        public CategoryRepositery(StoreContext context)
        {
            StoreDBContext = context;
        }

        public int AddCategory(Category category)
        {
            try
            {
                StoreDBContext.Categories.Add(category);
                StoreDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return category.CategoryId;
        }

        public IEnumerable<Category> CategoryList()
        {
            try
            {
                return StoreDBContext.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetCategory(int? id)
        {
            try
            {
                return StoreDBContext.Categories.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCategory(int? Id)
        {
            try
            {
                bool isDeleted = false;

                Category category = GetCategory(Id);
                StoreDBContext.Categories.Remove(category);
                StoreDBContext.SaveChanges();

                isDeleted = true;
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditCategory(Category EditCategory)
        {
            try
            {
                Category CurrentCategory = StoreDBContext.Categories.Find(EditCategory.CategoryId);
                CurrentCategory.Name = EditCategory.Name;
                StoreDBContext.Entry(CurrentCategory).State = EntityState.Modified;
                StoreDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
