using WebAPIForHousing.Models;

namespace WebAPIForHousing.Interfaces
{
    public interface IUserRepository
    {
        Task<USer> Autheticate(string UserName,string Password);
    }
}
