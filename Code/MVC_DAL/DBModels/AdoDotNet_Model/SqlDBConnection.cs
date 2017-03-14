using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MVC_DAL
{
    public sealed class SqlDBConnection
    {

        #region Private Members

        private string ConnectionString = "";

        SqlConnection _Connection;
        private SqlConnection Connection
        {
            get
            {
                if (_Connection == null)
                    _Connection = new SqlConnection(ConnectionString);
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }

        #endregion

        public SqlDBConnection(string ConString)
        {
            ConnectionString = ConString;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                return Connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            finally
            {
                Connection.Dispose();
            }
        }

    }

}
