using CleanArch.Application.DTOs;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
            => Ok(await _productRepository.GetProduct());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
            => Ok(await _productRepository.GetByIdAsync(id));

        //[HttpPost]
        //[ProducesResponseType(typeof(ProductDTO), StatusCodes.Status201Created)]

        //public async Task<IActionResult> Post()
        //     => Created("[controller]/{id}", await _productRepository.CreateAsync());


    }
}
