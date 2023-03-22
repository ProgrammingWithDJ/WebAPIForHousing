using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Data;
using WebAPIForHousing.Dtos;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await unitOfWork.cityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            
            return Ok(citiesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn=DateTime.Now;
            
             unitOfWork.cityRepository.AddCity(city);

           await unitOfWork.SaveAsync();


            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id,CityDto cityDto)
        {
            var cityFromDb = await unitOfWork.cityRepository.FindCity(id);

            // var city = mapper.Map<City>(cityDto);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto,cityFromDb);


            await unitOfWork.SaveAsync();


            return StatusCode(200);
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
