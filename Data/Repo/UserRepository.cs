using Microsoft.EntityFrameworkCore;
using WebAPIForHousing.Interfaces;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        public UserRepository(DataContext db)
        {
            this.db = db;
        }
        public async Task<USer> Autheticate(string UserName, string Password)
        {
            return await db.users.FirstOrDefaultAsync(x => x.Username == UserName &&
             x.Password == Password);
        }
    }
}
