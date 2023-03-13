using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Data;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await unitOfWork.cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(City city)
        {
             unitOfWork.cityRepository.AddCity(city);

           await unitOfWork.SaveAsync();


            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
           unitOfWork.cityRepository.DeleteCity(id);

            await unitOfWork.SaveAsync();


            return Ok();

        }

            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Pune";
        }
    }
}
