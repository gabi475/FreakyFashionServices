using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using FreakyFashionServices.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreakyFashionServices.Order.Controllers
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

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostOrderAsync(OrderPostRequest request)
        {
            var context = FreakyFashionServicesOrderContext.Connection.GetDatabase();
            var lastId = context.StringGet("O_lastId_");
            int id;

            if (lastId.IsNullOrEmpty)
            {
                context.StringSet("O_lastId_", 1);
                id = 1;
            } else {
                id = int.Parse(lastId) + 1;
                context.StringSet("O_lastId_", id);
            }
            HttpResponseMessage responseBasket = await _httpClient.GetAsync("https://localhost:5001/api/basket/" + int.Parse(request.customerIdentifier));
            var serializedBasket = await responseBasket.Content.ReadAsStringAsync();
            Basket basket = JsonSerializer.Deserialize<Models.Basket>(serializedBasket);

            Models.Order order = new Models.Order
            {
                basket = basket,
                customerIdentifier = request.customerIdentifier,
                firstName = request.firstName,
                lastName = request.lastName
            };

            context.StringSet($"O{id}", JsonSerializer.Serialize(order));

            return id;
        }
    }
}
