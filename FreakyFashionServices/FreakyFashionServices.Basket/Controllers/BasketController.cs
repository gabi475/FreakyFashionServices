using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FreakyFashionServices.Basket.Models;
using System.Text.Json;

namespace FreakyFashionServices.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }

        // GET: api/Basket/5
        [HttpGet("{id}")]
        public ActionResult<Models.Basket> GetItems(int id)
        {
            var context = FreakyFashionServicesBasketContext.Connection.GetDatabase();
            var serializedBasket = context.StringGet($"B{id}");

            if (serializedBasket.IsNullOrEmpty)
            {
                return NotFound();
            }

            var basket = JsonSerializer.Deserialize<Models.Basket>(serializedBasket);

            return basket;
        }

        // PUT: api/Basket/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutItems(int id, Models.Basket basket)
        {
            var context = FreakyFashionServicesBasketContext.Connection.GetDatabase();

            context.StringSet($"B{id}", JsonSerializer.Serialize(basket));

            return NoContent();
        }
    }
}
