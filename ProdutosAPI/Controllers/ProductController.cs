using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Data;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;
using ProdutosAPI.Profiles;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductContext _context;
        private IMapper _mapper;

        public ProductController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet]
        public IEnumerable<ReadProductDto> GetProducts([FromQuery] int skip = 0, [FromQuery]  int take = 10)
        {
            return _mapper.Map<IEnumerable<ReadProductDto>>(_context.Products.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            var dto = _mapper.Map<ReadProductDto>(product);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] UpdateProductDto dto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            _mapper.Map(dto, product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProductParciallyById(int id, [FromBody] JsonPatchDocument<UpdateProductDto> patch)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            var productDto = _mapper.Map<UpdateProductDto>(product);
            patch.ApplyTo(productDto, ModelState);
            if (!TryValidateModel(productDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productDto, product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
