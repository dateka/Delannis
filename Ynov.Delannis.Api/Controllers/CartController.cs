using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ynov.Delannis.Application.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;

namespace Ynov.Delannis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly CartService _cartService;
        private readonly ICartRepository _cartRepository;

        public CartController(CartService cartService, ICartRepository cartRepository)
        {
            _cartService = cartService;
            _cartRepository = cartRepository;
        }

        // GET: api/Cart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
