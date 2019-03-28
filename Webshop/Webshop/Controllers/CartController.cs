using System;
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
    
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            var allCarts = cartService.Get();
            if (allCarts != null)
            {
                return Ok(allCarts);
            }

            return NotFound();
        }
            
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = cartService.Get(id);
            if (products != null)
            {
                return Ok(products);
            }

            return NotFound();
        }
            
        [HttpPost]
        public IActionResult Post([FromBody]Carts carts)
        {
//            var cartGuid = Guid.TryParse(guid, out Guid guidresult) ? guidresult : Guid.NewGuid();
            
            var cart = this.cartService.Add(carts);

            if (cart == 0)
            {
                return BadRequest();
            }
            else if (cart == 1)
            {
                return Ok();
            }

            return Ok(cart);
        }
    }
}