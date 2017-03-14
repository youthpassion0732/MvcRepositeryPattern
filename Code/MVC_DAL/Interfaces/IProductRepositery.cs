using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public interface IProductRepositery
    {
        int AddProduct(Product product, string UserId);

        IEnumerable<Product> ProductsList();

        IEnumerable<Product> UserProductsList(string UserId);

        Product GetProduct(int? Id);

        bool DeleteProduct(int? Id);

        void EditProduct(Product product);
    }
}
