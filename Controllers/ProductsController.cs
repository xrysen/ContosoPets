using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Api.Data;
using ContosoPets.Api.Models;

namespace ContosoPets.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ContosoPetsContext _context;

    public ProductsController(ContosoPetsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll() =>
      _context.Products.ToList();

    // Get product by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      return product;
    }
  }
}