using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DomainEntities;
using MVC_DAL;

namespace MVC_BLL
{
    public class UserService : IUserService
    {
        IUserRepositery IUserRepositery;
        public UserService(IUserRepositery IUR)
        {
            IUserRepositery = IUR;
        }

        //For Account Controller
        public UserService()
        {
            if (IUserRepositery == null)
                IUserRepositery = new UserRepositery();
        }

        public User AddUser(User user)
        {
            try
            {
               return IUserRepositery.AddUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> UsersList()
        {
            try
            {
                return IUserRepositery.UsersList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUser(string UserId)
        {
            try
            {
                return IUserRepositery.GetUser(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(string UserId)
        {
            try
            {
               return IUserRepositery.DeleteUser(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditUser(User user)
        {
            try
            {
                IUserRepositery.EditUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
