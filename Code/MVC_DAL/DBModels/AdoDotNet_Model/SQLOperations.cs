using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MVC_DAL
{
    public class SQLOperations
    {

        private string ConnectionString = "";

        public SQLOperations(string constring)
        {
            ConnectionString = constring;
        }

        public DataSet ExecuteQuery(CommandType commandType, DBEnum DBObject, params object[] QueryParameters)
        {
            DataSet ResultSet = null;

            //Setting Connection
            SqlDBConnection con = new SqlDBConnection(ConnectionString);
            con.GetConnection();

            try
            {
                //Setting Query
                string Query = GetQuery(DBObject);

                if (commandType == CommandType.StoredProcedure)
                {
                    ResultSet = SqlHelper.ExecuteDataset(con.GetConnection(), Query, SetParameters(QueryParameters));
                }
                else
                {
                    ResultSet = SqlHelper.ExecuteDataset(con.GetConnection(), commandType, Query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return ResultSet;
        }

        private string GetQuery(DBEnum DBObject)
        {
            string query = "";

            if (DBObject == DBEnum.usp_Insert_Category)
            {
                query = "usp_Insert_Category";
            }
            else if (DBObject == DBEnum.usp_List_Category)
            {
                query = "usp_List_Category";
            }
            else if (DBObject == DBEnum.usp_Get_Category_By_Id)
            {
                query = "usp_Get_Category_By_Id";
            }
            else if (DBObject == DBEnum.usp_Delete_Category_By_Id)
            {
                query = "usp_Delete_Category_By_Id";
            }
            else if (DBObject == DBEnum.usp_Update_Category_By_Id)
            {
                query = "usp_Update_Category_By_Id";
            }
            else if (DBObject == DBEnum.usp_Insert_Product)
            {
                query = "usp_Insert_Product";
            }
            else if (DBObject == DBEnum.usp_List_Product)
            {
                query = "usp_List_Product";
            }
            else if (DBObject == DBEnum.usp_List_Product_By_UserId)
            {
                query = "usp_List_Product_By_UserId";
            }
            else if (DBObject == DBEnum.usp_Get_Product_By_Id)
            {
                query = "usp_Get_Product_By_Id";
            }
            else if (DBObject == DBEnum.usp_Delete_Product_By_Id)
            {
                query = "usp_Delete_Product_By_Id";
            }
            else if (DBObject == DBEnum.usp_Update_Product_By_Id)
            {
                query = "usp_Update_Product_By_Id";
            }
            else if (DBObject == DBEnum.usp_Insert_Logger)
            {
                query = "usp_Insert_Logger";
            }

            return query;
        }

        private object[] SetParameters(params object[] QueryParameters)
        {
            if (QueryParameters == null)
                return null;

            List<object> Parameters = new List<object>();
            for (int index = 0; index < QueryParameters.Length; index++)
            {
                Parameters.Add(QueryParameters[index].ToString());
            }

            return Parameters.ToArray();
        }

    }
}
