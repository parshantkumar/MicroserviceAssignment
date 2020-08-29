using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("GetUsers")]

        public async Task<List<User>> GetUsers()
        {
            //return await UserManager.Instance.GetUsers();

            return await Task.Run(() =>
            {
                List<User> users = new List<User>();
                users.Add(new User() { Id = 1, Name = "Admin1", Age = 30, Email = "admin1@c.com" });
                users.Add(new User() { Id = 2, Name = "User1", Age = 40, Email = "user1@c.com" });
                users.Add(new User() { Id = 3, Name = "User2", Age = 50, Email = "user2@c.com" });
                users.Add(new User() { Id = 4, Name = "User3", Age = 60, Email = "user3@c.com" });
                return users;

            });
        }

        //[HttpGet, Route("GetUserById")]

        //public async Task<Domain.Models.User> GetUserById(int id)
        //{
        //    return await UserManager.Instance.GetUserById(id);
        //}

        //[HttpPost, Route("AddUser")]

        //public async Task<int> AddUser(Domain.Models.User user)
        //{
        //    return await UserManager.Instance.AddUser(user);
        //}
    }
}
