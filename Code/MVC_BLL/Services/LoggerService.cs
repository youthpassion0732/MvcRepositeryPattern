using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DAL;

namespace MVC_BLL
{
    public class LoggerService : ILoggerService
    {
        ILoggerRepositery ILoggerRepositery;

        public LoggerService(ILoggerRepositery ILR)
        {
            ILoggerRepositery = ILR;
        }

        //For Account Controller
        public LoggerService()
        {
            if (ILoggerRepositery == null)
                ILoggerRepositery = new LoggerRepositery();
        }

        public void AddLogger(string Desc, string Error)
        {
            ILoggerRepositery.AddLogger(Desc, Error);
        }

    }
}
