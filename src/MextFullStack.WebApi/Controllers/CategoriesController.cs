using MextFullStack.Domain.Entities;
using MextFullStack.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeDatabase.Categories);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var category = FakeDatabase
                .Categories
                .FirstOrDefault(p => p.Id == id);

            if (category == null)
                return NotFound("Aradaginiz urun sistemde bulunamadi.");

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name.Length <= 2)
                return BadRequest("Urun ismi en az 2 karakter olmalidir.");

            if (category.Description.Length <= 0)
                return BadRequest("Kategory aciklamasi 10 karakterdeb buyuk olmalidi.");


            if (FakeDatabase.Products.Any(p => p.Name.ToLowerInvariant() == category.Name.ToLowerInvariant()))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            FakeDatabase.Categories.Add(category);

            return Ok(category.Id);
        }
    }
}
