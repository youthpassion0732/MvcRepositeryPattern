using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVC_DomainEntities;
using System.Data.Entity.Validation;

namespace MVC_DAL
{
    public class ProductRepositery : IProductRepositery
    {

        StoreContext StoreDBContext;

        public ProductRepositery(StoreContext context)
        {
            StoreDBContext = context;
        }

        public int AddProduct(Product product, string UserId)
        {
            UserProduct userproduct = null;

            try
            {
                //Adding into Product Table
                product = this.StoreDBContext.Products.Add(product);
                this.StoreDBContext.SaveChanges();

                if (product.ProductId > 0)
                {
                    userproduct = new UserProduct();
                    userproduct.ProductId = product.ProductId;
                    userproduct.UserId = UserId;

                    //Adding into UserProduct Table
                    userproduct = StoreDBContext.UserProducts.Add(userproduct);
                    StoreDBContext.SaveChanges();
                }

                return userproduct.UserProductId;
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> ProductsList()
        {
            try
            {
                return StoreDBContext.Products.ToList();
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
                var products = (from p in StoreDBContext.Products
                                join up in StoreDBContext.UserProducts on p.ProductId equals up.ProductId
                                join cat in StoreDBContext.Categories on p.CategoryId equals cat.CategoryId
                                orderby p.ProductId descending
                                where up.UserId == UserId
                                select p).ToList();

                return products;
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
                return StoreDBContext.Products.Find(Id);
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
                bool isDeleted = false;

                //Removing info from UserProduct table
                UserProduct userproduct = StoreDBContext.UserProducts.FirstOrDefault(u => u.ProductId == Id);
                StoreDBContext.UserProducts.Remove(userproduct);
                StoreDBContext.SaveChanges();

                //Removing info from product table
                Product product = GetProduct(Id);
                StoreDBContext.Products.Remove(product);
                StoreDBContext.SaveChanges();

                isDeleted = true;
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditProduct(Product EditProduct)
        {
            try
            {
                Product CurrentProduct = StoreDBContext.Products.Find(EditProduct.ProductId);
                CurrentProduct.Name = EditProduct.Name;
                CurrentProduct.Price = EditProduct.Price;
                CurrentProduct.CategoryId = EditProduct.CategoryId;

                StoreDBContext.Entry(CurrentProduct).State = EntityState.Modified;
                StoreDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
