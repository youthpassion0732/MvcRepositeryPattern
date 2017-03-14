using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public class ProductRepositery_Ado : IProductRepositery
    {

        string ConnectionString = "";

        public ProductRepositery_Ado(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        SQLOperations _DBOperation;
        private SQLOperations DBOperation
        {
            get
            {
                if (_DBOperation == null)
                {
                    _DBOperation = new SQLOperations(ConnectionString);
                }
                return _DBOperation;
            }
        }

        public int AddProduct(Product product, string UserId)
        {
            int ProductId = -1;

            try
            {
                List<object> ProductValues = new List<object>();
                ProductValues.Add(product.CategoryId);
                ProductValues.Add(product.Name);
                ProductValues.Add(product.Price);                
                ProductValues.Add(UserId);

                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Insert_Product, ProductValues.ToArray());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ProductId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                }

                return ProductId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> ProductsList()
        {
            List<Product> ProductList = new List<Product>();

            try
            {
                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_List_Product, null);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Product product = new Product();

                    product.ProductId = Convert.ToInt32(row["ProductId"]);
                    product.CategoryId = Convert.ToInt32(row["CategoryId"]);
                    product.Name = row["Name"].ToString();
                    product.Price = Convert.ToDecimal(row["Price"]);

                    ProductList.Add(product);
                }

                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> UserProductsList(string UserId)
        {
            List<Product> ProductList = new List<Product>();

            try
            {
                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_List_Product_By_UserId, UserId);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Product product = new Product();

                    product.ProductId = Convert.ToInt32(row["ProductId"]);
                    product.CategoryId = Convert.ToInt32(row["CategoryId"]);
                    product.Name = row["Name"].ToString();
                    product.Price = Convert.ToDecimal(row["Price"]);
                    product.Category = new Category();
                    product.Category.Name = row["Name1"].ToString();

                    ProductList.Add(product);
                }

                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProduct(int? Id)
        {
            Product product = null;

            try
            {
                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Get_Product_By_Id, Id);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    product = new Product();
                    product.ProductId = Convert.ToInt32(row["ProductId"]);
                    product.CategoryId = Convert.ToInt32(row["CategoryId"]);
                    product.Name = row["Name"].ToString();
                    product.Price = Convert.ToDecimal(row["Price"]);
                    product.Category = new Category();
                    product.Category.Name = row["CategoryName"].ToString();
                }

                return product;
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

                DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Delete_Product_By_Id, Id);

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
                List<object> ProductValues = new List<object>();
                ProductValues.Add(EditProduct.ProductId);
                ProductValues.Add(EditProduct.CategoryId);
                ProductValues.Add(EditProduct.Name);
                ProductValues.Add(EditProduct.Price);

                DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Update_Product_By_Id, ProductValues.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
