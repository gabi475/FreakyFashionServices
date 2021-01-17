using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly ILogger<ProductPriceController> _logger;

        public ProductPriceController(ILogger<ProductPriceController> logger)
        {
            _logger = logger;
        }

        // GET: api/ProductPrice
        [HttpGet]
        public ActionResult<List<Models.Product>> GetProductPrice([FromQuery] string Products)
        {
            var requestedProducts = new string[0];

            if (!string.IsNullOrWhiteSpace(Products))
            {
                requestedProducts = Products.Split(",");
            }

            var response = new List<Models.Product>();

            Random randomizer = new Random();

            foreach (string articleNumber in requestedProducts)
            {
                response.Add(new Models.Product(articleNumber.Trim(), randomizer.Next(10, 800)));
            }

            return response;
        }
    }
}
