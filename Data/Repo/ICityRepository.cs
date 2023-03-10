using WebAPIForHousing.Models;

namespace WebAPIForHousing.Data.Repo
{
    public interface ICityRepository
    {
        Task <IEnumerable<City>> GetCitiesAsync();

        Task<City> FindCity(int id);

         void DeleteCity(int id);

         void AddCity(City city);

        Task<bool> SaveAsync();
    }
}
