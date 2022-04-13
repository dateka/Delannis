using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ynov.Delannis.Application.ProductAggregate;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions;

namespace Ynov.Delannis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductController(ProductService productService, IProductRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }
        
        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                await _productService.AddProductAsync(product);
                return Ok();
            }
            catch (DomainExceptionBase be)
            {
                return BadRequest(be.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }

        // GET: api/Product
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return product;
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            try
            {
                await _productService.DeleteProductAsync(product);
                return Ok();
            }
            catch (DomainExceptionBase be)
            {
                return BadRequest(be.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
        
        // PUT: api/Product/5
         /*[HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }*/
    }
}
