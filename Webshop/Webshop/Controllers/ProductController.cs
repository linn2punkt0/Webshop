using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
            private readonly ProductService productService;

            public ProductController(IConfiguration configuration)
            {
                var connectionString = configuration.GetConnectionString("ConnectionString");
                this.productService = new ProductService(new ProductRepository(connectionString));
            }
            
            [HttpGet]
            public IActionResult Get()
            {
                var allProducts = productService.Get();
                if (allProducts != null)
                {
                    return Ok(allProducts);
                }

                return NotFound();
            }
            
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var products = productService.Get(id);
                if (products != null)
                {
                    return Ok(products);
                }

                return NotFound();
            }
            
            [HttpPost]
            public IActionResult Post([FromBody]Products products)
            {
                var result = this.productService.Add(products);

                if (!result)
                {
                    return BadRequest();
                }

                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var result = this.productService.Delete(id);

                if (!result)
                {
                    return BadRequest();
                }

                return Ok();
            }
     }
}