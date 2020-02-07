using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using core_api.Data;
using core_api.Models;

namespace core_api.Controllers
{
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var products = await context.Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == id).ToListAsync();

            return products;
        }
    }
}