using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Data;
using WebAPIForHousing.Data.Repo;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext db;
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.db = db;
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(City city)
        {
             cityRepository.AddCity(city);

           await cityRepository.SaveAsync();

            
            return Ok(city);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
           cityRepository.DeleteCity(id);

            await cityRepository.SaveAsync();


            return Ok();

        }

            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Pune";
        }
    }
}
