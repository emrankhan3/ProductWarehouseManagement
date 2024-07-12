using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ProductWarehouseAuth.Service;
using ProductWarehouseAuth.Service.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWarehouseAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }


        // GET: api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginDto loginDto)
        {
            Console.WriteLine("\n\n\n\n\n\n\nAUTH CONTROLLER HIT\n\n\n\n\n");
            return authService.Login(loginDto);
        }

        //// GET api/<AuthController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AuthController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AuthController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuthController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
