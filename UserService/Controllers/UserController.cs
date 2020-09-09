using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Shared.Interface;
using UserService.Shared.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserManager UserManager;
        public UserController(IUserManager userManager)
        {
            this.UserManager = userManager;
        }
        [HttpGet, Route("GetUsers")]

        public IEnumerable<User> GetUsers()
        {
            return  UserManager.GetUsers();
        }
        [HttpGet, Route("GetUserById")]
        public User GetUserById(int id)
        {
            return UserManager.GetUserById(id);
        }

        [HttpPost, Route("AddUser")]
        public bool AddUser(User user)
        {
            return UserManager.InsertUser(user);
        }
    }
}
