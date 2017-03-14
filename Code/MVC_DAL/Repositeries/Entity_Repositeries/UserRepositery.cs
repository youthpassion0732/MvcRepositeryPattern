using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_DomainEntities;

namespace MVC_DAL
{
    public class UserRepositery : IUserRepositery
    {

        StoreContext StoreDBContext;
        public UserRepositery(StoreContext context)
        {
            StoreDBContext = context;
        }

        //For Account Controller
        public UserRepositery()
        {
            if (StoreDBContext == null)
            {
                StoreDBContext = new StoreContext();
            }
        }

        //Article Reference: http://www.codeproject.com/Articles/727054/ASP-NET-MVC-Identity-Extending-and-Modifying-R
        UserManager<User> _userManager = new UserManager<User>(new UserStore<User>(new StoreContext()));

        public User AddUser(User user)
        {
            try
            {
                var idResult = _userManager.Create(user, user.PasswordHash);
                if (idResult.Succeeded)
                    return user;
                else
                    throw new Exception(((string[])(idResult.Errors))[0]);
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
                return StoreDBContext.Users.ToList();
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
                return this.StoreDBContext.Users.Find(UserId);
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
                bool isDeleted = false;

                User user = GetUser(UserId);
                StoreDBContext.Users.Remove(user);
                StoreDBContext.SaveChanges();

                isDeleted = true;
                return isDeleted;
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
                StoreDBContext.Entry(user).State = EntityState.Modified;
                StoreDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
