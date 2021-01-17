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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly HttpClient _httpClient;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostOrderAsync(OrderPostRequest request)
        {
            HttpResponseMessage responseOrder = await _httpClient.PostAsync("https://localhost:5021/api/order", new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
            var serializedOrderId = await responseOrder.Content.ReadAsStringAsync();
            Console.WriteLine(serializedOrderId);
            int orderId = int.Parse(serializedOrderId);
            return orderId;
        }
    }
}
