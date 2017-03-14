using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;
using System.Data;

namespace MVC_DAL
{

    public class LoggerRepositery_Ado : ILoggerRepositery
    {
        string ConnectionString = "";

        public LoggerRepositery_Ado(string connectionstring)
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

        public void AddLogger(string Desc, string Error)
        {
            List<object> LoggerValues = new List<object>();
            LoggerValues.Add(Desc);
            LoggerValues.Add(Error);

            DBOperation.ExecuteQuery(CommandType.StoredProcedure, DBEnum.usp_Insert_Logger, LoggerValues.ToArray());
        }

    }
}
