using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using core_api.Data;
using core_api.Models;

namespace core_api.Controllers
{

    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        // private DataContext _context;
        // public CategoryController(DataContext context)
        // {
        //     _context = context
        // }

        [HttpGet] //Se não colocar o default é sempre GET
        [Route("")] //Tudo que for adicionado aqui será concatenado
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync(); //Precisa salvar senão o dado não será persistido no banco
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}