using FoodTruckFinderApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodTruckFinderApp.Services;
using FoodTruckFinderApp.Services.FoodTruckService;

namespace FoodTruckFinderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        private readonly IFoodTruckService _foodTruckService;

        public FoodTruckController(IFoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodTruck>>> FindFoodTrucks(double latitude, double longitude, string preferredFood, int amount)
        {
            return await _foodTruckService.FindFoodTrucks(latitude, longitude, preferredFood, amount);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<FoodTruck>>> UpdateFoodTruck(int id, FoodTruck request)
        {
            var result = await _foodTruckService.UpdateFoodTruck(id, request);
            if (result is null)
                return NotFound("Truck not found");

            return Ok(result);
        }
    }
}
