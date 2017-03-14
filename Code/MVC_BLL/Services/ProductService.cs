using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;
using MVC_DAL;

namespace MVC_BLL
{
    public class ProductService : IProductService
    {

        IProductRepositery IProductRepositery;
        public ProductService(IProductRepositery IPR)
        {
            IProductRepositery = IPR;
        }

        public int AddProduct(Product product, string UserId)
        {
            try
            {
                return IProductRepositery.AddProduct(product, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> ProductsList()
        {
            try
            {
                return IProductRepositery.ProductsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> UserProductsList(string UserId)
        {
            try
            {
                return IProductRepositery.UserProductsList(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProduct(int? Id)
        {
            try
            {
                return IProductRepositery.GetProduct(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteProduct(int? Id)
        {
            try
            {
                return IProductRepositery.DeleteProduct(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditProduct(Product product)
        {
            try
            {
                IProductRepositery.EditProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
