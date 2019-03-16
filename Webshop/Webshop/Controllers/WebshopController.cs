using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Service;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    public class WebshopController : Controller
    {
            private readonly WebshopService webshopService;

            public WebshopController(IConfiguration configuration)
            {
                var connectionString = configuration.GetConnectionString("ConnectionString");
                this.webshopService = new WebshopService(new WebshopRepository(connectionString));
            }
            
            [HttpGet]
            public IActionResult Get()
            {
                var allItems = webshopService.Get();
                if (allItems != null)
                {
                    return Ok(allItems);
                }

                return NotFound();
            }
            
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var items = webshopService.Get(id);
                if (items != null)
                {
                    return Ok(items);
                }

                return NotFound();
            }
            
            [HttpPost]
            public IActionResult Post([FromBody]Items items)
            {
                var result = this.webshopService.Add(items);

                if (!result)
                {
                    return BadRequest();
                }

                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var result = this.webshopService.Delete(id);

                if (!result)
                {
                    return BadRequest();
                }

                return Ok();
            }
        }
    }
}