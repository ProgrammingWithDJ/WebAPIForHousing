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
        public IActionResult GetCities()
        {
            return Ok(db.Cities.ToList());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Pune";
        }
    }
}
