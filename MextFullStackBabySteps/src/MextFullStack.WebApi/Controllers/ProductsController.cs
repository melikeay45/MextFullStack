using MextFullStack.Domain.Dtos;
using MextFullStack.Domain.Entities;
using MextFullStack.WebApi.Data;
using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //
        private RequestCounterManager _requestCounterManager;
        public ProductGetAllDto ProductGetAllDto { get; set; }

        public ProductsController(RequestCounterManager requestCounterManager)
        {
            _requestCounterManager = requestCounterManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _requestCounterManager.Increment();

            List<ProductGetAllDto> productDtos = FakeDatabase
                .Products
                .Select(p => ProductGetAllDto.FromProduct(p))
                .ToList();

            return Ok(productDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            _requestCounterManager.Increment();

            var product = FakeDatabase
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound("Aradaginiz urun sistemde bulunamadi.");

            var category = FakeDatabase
                .Categories
                .FirstOrDefault(c => c.Id == product.CategoryId);

            var productDto = ProductGetByIdDto.FromProduct(product, category);

            return Ok(productDto);
        }

        [HttpPost]
        public IActionResult Create(ProductAddDto productAddDto)
        {
            _requestCounterManager.Increment();

            if (productAddDto.Name.Length <= 2)
                return BadRequest("Urun ismi en az 2 karakter olmalidir.");

            if (productAddDto.Price <= 0)
                return BadRequest("Urun fiyati sifirdan buyuk olmalidir.");


            if (FakeDatabase.Products.Any(p => p.Name.ToLowerInvariant() == productAddDto.Name.ToLowerInvariant()))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            var product = new Product();

            product.Id = Guid.NewGuid();
            product.Name = productAddDto.Name;
            product.Price = productAddDto.Price;
            product.Description = productAddDto.Description;
            product.CategoryId = productAddDto.CategoryId;
            product.ModifiedOn = DateTime.Now;

            FakeDatabase.Products.Add(product);

            return Ok(productAddDto.Id);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _requestCounterManager.Increment();

            if (product.Id == Guid.Empty)
                return BadRequest("Gecersiz urun id'si.");

            if (FakeDatabase.Products.Any(p => p.Name.ToLowerInvariant() == product.Name.ToLowerInvariant()
                && p.Id != product.Id))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            var productIndex = FakeDatabase.Products.FindIndex(p => p.Id == product.Id);

            if (productIndex == -1)
                return NotFound("Guncellemek istediginiz urun sistemde bulunamadi.");

            product.ModifiedOn = DateTime.Now;

            FakeDatabase.Products[productIndex] = product;

            return Ok(product.Id);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _requestCounterManager.Increment();

            // Empty Guid Example -> 00000000-0000-0000-0000-000000000000

            if (id == Guid.Empty)
                return BadRequest("Gecersiz urun id'si.");

            var product = FakeDatabase
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound("Silmek istediginiz urun sistemde bulunamadi.");

            FakeDatabase.Products.Remove(product);

            return NoContent();
        }
    }
}
