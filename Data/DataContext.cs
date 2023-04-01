using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }

        public DbSet<USer> users { get; set; }
    }
}
