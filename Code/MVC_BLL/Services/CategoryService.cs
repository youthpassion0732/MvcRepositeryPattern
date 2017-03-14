using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;
using MVC_DAL;

namespace MVC_BLL
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepositery ICategoryRepositery;
        public CategoryService (ICategoryRepositery ICR)
        {
            ICategoryRepositery = ICR;
        }

        public int AddCategory(Category category)
        {
            int Id = -1;

            try
            {
                Id = ICategoryRepositery.AddCategory(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        public IEnumerable<Category> CategoryList()
        {
            try
            {
                return ICategoryRepositery.CategoryList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetCategory(int? Id)
        {
            try
            {
                return ICategoryRepositery.GetCategory(Id);
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
                return ICategoryRepositery.DeleteCategory(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditCategory(Category category)
        {
            try
            {
               ICategoryRepositery.EditCategory(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
