using WebAPIForHousing.Data.Repo;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext db;

        public UnitOfWork(DataContext db)
        {
            this.db = db;
        }

        public ICityRepository cityRepository => new CityRepository(db);

        public void AddCity(City city)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<City> FindCity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
          return await db.SaveChangesAsync() > 0;
        }
    }
}
