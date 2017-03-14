using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public class CategoryRepositery_Ado : ICategoryRepositery
    {
        string ConnectionString = "";

        public CategoryRepositery_Ado(string connectionstring)
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

        public int AddCategory(Category category)
        {
            int CategoryId = -1;

            try
            {
              List<object> CategoryValues = new List<object>();
              CategoryValues.Add(category.Name);

              DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Insert_Category, CategoryValues.ToArray());
              if (ds.Tables[0].Rows.Count > 0)
              {
                  CategoryId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
              }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CategoryId;
        }

        public IEnumerable<Category> CategoryList()
        {
            List<Category> CatList = new List<Category>();

            try
            {
                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_List_Category, null);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(row["CategoryId"]);
                    category.Name = row["Name"].ToString();

                    CatList.Add(category);
                }

                return CatList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetCategory(int? id)
        {
            Category category = null;

            try
            {
                DataSet ds = DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Get_Category_By_Id, id);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    category = new Category();
                    category.CategoryId = Convert.ToInt32(row["CategoryId"]);
                    category.Name = row["Name"].ToString();
                }

                return category;
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

                DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Delete_Category_By_Id, Id);

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
                List<object> CategoryValues = new List<object>();
                CategoryValues.Add(EditCategory.CategoryId);
                CategoryValues.Add(EditCategory.Name);

                DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Update_Category_By_Id, CategoryValues.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
