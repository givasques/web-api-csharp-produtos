using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;
using ProdutosAPI.Profiles;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        private static int id = 0;
        private IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            id++;
            product.Id = id;
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet]
        public IEnumerable<ReadProductDto> GetProducts()
        {
            return _mapper.Map<IEnumerable<ReadProductDto>>(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            var dto = _mapper.Map<ReadProductDto>(product);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            products.Remove(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] UpdateProductDto dto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            var index = products.IndexOf(product);
            products[index] = _mapper.Map(dto, product);
            return NoContent();
        }
    }
}
