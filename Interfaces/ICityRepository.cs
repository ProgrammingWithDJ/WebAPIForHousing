using WebAPIForHousing.Models;

namespace WebAPIForHousing.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City> FindCity(int id);

        void DeleteCity(int id);

        void AddCity(City city);

    }
}
