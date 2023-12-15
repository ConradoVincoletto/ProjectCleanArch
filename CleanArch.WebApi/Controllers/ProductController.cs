using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null)
            {
                return NotFound("Products not found");
            }
            return Ok(products);
        }


        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var products = await _productService.GetById(id);

            if (products == null)
            {
                return NotFound("Products not found");
            }
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {            
            if (productDTO == null)
            {
                return BadRequest("Invalid data");
            }

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();
            if (productDTO == null)
                return BadRequest();

            await _productService.Update(productDTO);
            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound("Product not foud.");

            await _productService.Remove(id);

            return Ok(product);
        }


    }
}
