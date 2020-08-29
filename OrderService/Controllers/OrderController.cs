using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet, Route("GetOrders")]
        public async Task<List<Order>> GetOrders()
        {
            return await Task.Run(() =>
            {
                List<Order> orders = new List<Order>();
                orders.Add(new Order() { Id = 1, Amount = 1000, Date = DateTime.Now });
                orders.Add(new Order() { Id = 2, Amount = 2000, Date = DateTime.Now });
                orders.Add(new Order() { Id = 3, Amount = 3000, Date = DateTime.Now });
                orders.Add(new Order() { Id = 4, Amount = 4000, Date = DateTime.Now });
                return orders;

            });
        }
    }
}
