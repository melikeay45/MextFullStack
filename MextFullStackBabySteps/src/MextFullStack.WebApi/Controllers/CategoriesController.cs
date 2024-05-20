using MextFullStack.Domain.Dtos;
using MextFullStack.Domain.Entities;
using MextFullStack.WebApi.Data;
using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private RequestCounterManager _requestCounterManager;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeDatabase.Categories);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            _requestCounterManager.Increment();

            var category = FakeDatabase
                .Categories
                .FirstOrDefault(p => p.Id == id);

            if (category == null)
                return NotFound("Aradaginiz urun sistemde bulunamadi.");

            return Ok(category);
        }

        [HttpGet("[action]")]
        public IActionResult GetAllForSelect()
        {

            var categories = FakeDatabase
                .Categories
                .Where(x => x.IsActive)
                .Select(c => CategoriesGetAllForSelectDto.FromCategory(c))
                .ToList();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _requestCounterManager.Increment();

            if (category.Name.Length <= 2)
                return BadRequest("Urun ismi en az 2 karakter olmalidir.");

            if (category.Description.Length <= 0)
                return BadRequest("Kategory aciklamasi 10 karakterdeb buyuk olmalidi.");


            if (FakeDatabase.Products.Any(p => p.Name.ToLowerInvariant() == category.Name.ToLowerInvariant()))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            FakeDatabase.Categories.Add(category);

            return Ok(category.Id);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _requestCounterManager.Increment();

            if (category.Id == Guid.Empty)
                return BadRequest("Gecersiz category id'si.");

            if (FakeDatabase.Categories.Any(p => p.Name.ToLowerInvariant() == category.Name.ToLowerInvariant()
                && p.Id != category.Id))
                return BadRequest("Bu isimde bir category zaten mevcut.");

            var categoryIndex = FakeDatabase.Categories.FindIndex(p => p.Id == category.Id);

            if (categoryIndex == -1)
                return NotFound("Guncellemek istediginiz category sistemde bulunamadi.");

            category.ModifiedOn = DateTime.Now;

            FakeDatabase.Categories[categoryIndex] = category;


            return Ok(category.Id);
        }
    }
}
