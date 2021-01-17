using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FreakyFashionServices.APIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreakyFashionServices.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly HttpClient _httpClient;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Basket basket)
        {
            HttpResponseMessage responseOrder = await _httpClient.PutAsync("https://localhost:5001/api/basket/" + id, new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json"));
            return NoContent();
        }
    }
}
