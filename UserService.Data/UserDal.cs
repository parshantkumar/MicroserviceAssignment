using System;
using System.Collections.Generic;
using System.Text;
using UserService.Shared.Interface;
using UserService.Shared.Model;
using System.Linq;

namespace UserService.Data
{
    public class UserDal : IUserDal
    {
        private readonly UserDbContext _Context;
       public UserDal(UserDbContext context)
        {
            this._Context = context;
        }

        #region Methods
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> ret = null;
            try
            {
                ret = _Context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        public User GetUserById(int userId)
        {
            User ret = null;
            try
            {
                ret = _Context.Users.Find(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        public bool InsertUser(User user)
        {
            bool ret = false;
            try
            {
                _Context.Users.Add(user);
                ret = _Context.SaveChanges() != 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }


        public bool DeleteUser(int userId)
        {
            bool ret = false;
            try
            {
                var user = _Context.Users.Find(userId);
                if (user != null)
                {
                    _Context.Users.Remove(user);
                    if (_Context.SaveChanges() > 0)
                    {
                        ret = true;
                    }
                }
                else
                {
                    ret = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        #endregion

    }
}
