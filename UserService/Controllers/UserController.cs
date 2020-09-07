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

            //return await Task.Run(() =>
            //{
            //    List<User> users = new List<User>();
            //    users.Add(new User() { Id = 1, Name = "Admin1", Age = 30, Email = "admin1@c.com" });
            //    users.Add(new User() { Id = 2, Name = "User1", Age = 40, Email = "user1@c.com" });
            //    users.Add(new User() { Id = 3, Name = "User2", Age = 50, Email = "user2@c.com" });
            //    users.Add(new User() { Id = 4, Name = "User3", Age = 60, Email = "user3@c.com" });
            //    return users;

            //});
        }

        [HttpGet, Route("GetUserById")]
        //[HttpGet("{id}", Name = "Get")]
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
