using Microsoft.AspNetCore.Mvc;
using ProductWarehouseAuth.Core.Entity;
using ProductWarehouseAuth.Service;
using ProductWarehouseAuth.Service.Dtos;
using ProductWarehouseAuth.Service.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWarehouseAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService=null;
        public ProductController(ProductService productService)
        {
            this.productService=productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            return productService.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productService.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void AddProduct([FromBody] ProductDto productDto)
        {
            productService.AddProduct(productDto);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto productDto)
        {
            productService.UpdateProduct(id, productDto);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
