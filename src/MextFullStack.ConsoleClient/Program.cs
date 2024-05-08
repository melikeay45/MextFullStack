using System.Net.Http.Json;
using MextFullStack.Domain.Entities;

var apiUrl = "http://localhost:5285/api/";

var client = new HttpClient()
{
    BaseAddress = new Uri(apiUrl)
};

// http://localhost:5285/api/Products

var products = await client.GetFromJsonAsync<List<Product>>("Products");


foreach (var product in products)
{
    Console.WriteLine($"Product: {product.Name} - {product.Price}");
}

Console.ReadKey();