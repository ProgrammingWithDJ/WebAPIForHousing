using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Data;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext db;

        public CityController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await db.Cities.ToListAsync();
            return Ok(cities);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(City city)
        {
            await db.Cities.AddAsync(city);

           await db.SaveChangesAsync();

            
            return Ok(city);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            
            
            var iid= await db.Cities.FindAsync(id);

             db.Cities.Remove(iid);

            await db.SaveChangesAsync();


            return Ok();

        }

            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Pune";
        }
    }
}
