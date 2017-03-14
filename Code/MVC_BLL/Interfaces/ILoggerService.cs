using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BLL
{
    public interface ILoggerService
    {
        void AddLogger(string Desc, string Error);

    }
}
