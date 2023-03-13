using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;


namespace WebAPIForHousing.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;

        public CityRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddCity(City city)
        {
            dc.Cities.AddAsync(city);
            
        }

        public void DeleteCity(int id)
        {
            var city =dc.Cities.Find(id);

            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            var city = await dc.Cities.FindAsync(id);
            return city;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var cities = await dc.Cities.ToListAsync();
             return cities;
        }


    }
}
