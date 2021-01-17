using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using FreakyFashionServices.APIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreakyFashionServices.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly HttpClient _httpClient;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<ActionResult<List<Items>>> GetProducts()
        {
            // Get products
            HttpResponseMessage responseProducts = await _httpClient.GetAsync("https://localhost:5011/api/catalog/items");
            var serializedProducts = await responseProducts.Content.ReadAsStringAsync();
            List<Items> products = JsonSerializer.Deserialize<List<Items>>(serializedProducts);

            // Get random price

            var articleNumberList = "";

            foreach (var product in products)
            {
                articleNumberList += product.Id + ",";
            }
            articleNumberList = articleNumberList[0..^1];

            HttpResponseMessage responseProductPrices = await _httpClient.GetAsync("https://localhost:5031/api/productprice/?products=" + articleNumberList);
            var serializedProductPrices  = await responseProductPrices.Content.ReadAsStringAsync();
            List<Product> productPrices = JsonSerializer.Deserialize<List<Product>>(serializedProductPrices);

            foreach (var product in products)
            {
                var productPrice = productPrices.FirstOrDefault(x => x.articleNumber == product.Id.ToString());
                product.Price = productPrice.price;
            }

            return products;
        }
    }
}
