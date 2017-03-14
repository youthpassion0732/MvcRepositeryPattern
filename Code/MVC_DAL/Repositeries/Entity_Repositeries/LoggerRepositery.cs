using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public class LoggerRepositery : ILoggerRepositery
    {
        StoreContext StoreDBContext;

        public LoggerRepositery(StoreContext context)
        {
            StoreDBContext = context;
        }

        //For Account Controller
        public LoggerRepositery()
        {
            if (StoreDBContext == null)
            {
                StoreDBContext = new StoreContext();
            }
        }

        public void AddLogger(string Desc, string Error)
        {
            Logger logger = new Logger();
            logger.Description = Desc;
            logger.Error = Error;
            StoreDBContext.Loggers.Add(logger);
            StoreDBContext.SaveChanges();
        }
    }
}
