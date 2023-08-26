using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo) 
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync(); 
            return Ok((List<Product>)products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return product;
        }
        [HttpGet("types")]
        public async Task<List<ProductType>> GetProductTypes()
        {
            var productTypes = await _repo.GetProductTypesAsync();
            return (List<ProductType>)productTypes;
        }

        [HttpGet("brands")]
        public async Task<List<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _repo.GetProductBrandsAsync();
            return (List<ProductBrand>)productBrands;
        }
    }
}