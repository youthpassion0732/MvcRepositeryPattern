using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;

namespace MVC_BLL
{
    public interface IUserService
    {
        User AddUser(User user);

        IEnumerable<User> UsersList();

        User GetUser(string UserId);

        bool DeleteUser(string UserId);

        void EditUser(User user);
    }

}
