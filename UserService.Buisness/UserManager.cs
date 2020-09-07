using System;
using System.Collections.Generic;
using System.Text;
using UserService.Shared.Interface;
using UserService.Shared.Model;

namespace UserService.Buisness
{
   public class UserManager : IUserManager
    {
        private readonly IUserDal UserDAL;

        public UserManager(IUserDal userDAL)
        {
            this.UserDAL = userDAL;
        }

        #region Methods
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> ret = null;
            try
            {
                ret = UserDAL.GetUsers();
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
                if (userId > 0)
                {
                    ret = UserDAL.GetUserById(userId);
                }
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
                if (user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email))
                {
                    ret = UserDAL.InsertUser(user);
                }
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
                ret = UserDAL.DeleteUser(userId);
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
