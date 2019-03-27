using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;

        public OrderController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService(new OrderRepository(connectionString));
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            var allOrders = orderService.Get();
            if (allOrders != null)
            {
                return Ok(allOrders);
            }

            return NotFound();
        }
            
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = orderService.Get(id);
            if (products != null)
            {
                return Ok(products);
            }

            return NotFound();
        }
            
        [HttpPost]
        public IActionResult Post([FromBody]Orders orders)
        {
            var result = this.orderService.Add(orders);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}