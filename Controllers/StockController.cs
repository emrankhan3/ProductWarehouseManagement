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
    public class StockController : ControllerBase
    {
        private readonly StockService stockService = null;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        // GET: api/<StockController>
        [HttpGet]
        public IEnumerable<Stock> GetAllStock()
        {
            return stockService.GetAllStocks();
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            return stockService.GetStockById(id);
        }

        // POST api/<StockController>
        [HttpPost]
        public void Post([FromBody] StockDto stockDto)
        {
            stockService.AddStock(stockDto);
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StockDto stokDto)
        {
            stockService.UpdateStock(id, stokDto);
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stockService.DeleteStockById(id);   
        }
    }
}
