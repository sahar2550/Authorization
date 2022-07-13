using AuthorizationWebApi.Models;
using AuthorizationWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthorizationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Helpers.Authorize]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            var result = await _carService.AddCar(car);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetCars")]
        public async Task<IActionResult> GetCars()
        {
            var result = await _carService.GetCars();
            return Ok(result);
        }
    }
}
