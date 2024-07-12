using Microsoft.AspNetCore.Mvc;
using ProductWarehouseAuth.Api.Dtos;
using ProductWarehouseAuth.Core.Entity;
using ProductWarehouseAuth.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWarehouseAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        // GET: api/<WarehouseController>
        [HttpGet]
        public IEnumerable<Warehouse> Get(WarehouseService warehouseService)
        {
            return warehouseService.GetAllWarehouse();
        }

        // GET api/<WarehouseController>/5
        [HttpGet("{id}")]
        public Warehouse Get(int id,WarehouseService warehouseService)
        {
            return warehouseService.GetWarehouseById(id);
        }

        // POST api/<WarehouseController>
        [HttpPost]
        public void Post([FromBody] WarehouseDto warehouseDto,WarehouseService warehouseService)
        {
           
  
            warehouseService.AddWarehouse(warehouseDto);
            
        }

        // PUT api/<WarehouseController>/5
        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpPut("{id}",Name ="UpdateWarehouse")]
        public void Put(int id, [FromBody] WarehouseDto warehouseDto,WarehouseService warehouseService)
        {
        
            warehouseService.UpdateWarehouse(id,warehouseDto);

        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id,WarehouseService warehouseService)
        {
            warehouseService.DeleteWarehouse(id);
        }
    }
}
