using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public interface ICategoryRepositery
    {
        int AddCategory(Category category);

        IEnumerable<Category> CategoryList();

        Category GetCategory(int? Id);

        bool DeleteCategory(int? Id);

        void EditCategory(Category category);

    }

}
