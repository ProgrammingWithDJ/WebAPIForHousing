namespace WebAPIForHousing.Interfaces
{
    public interface IUnitOfWork : ICityRepository
    {
        ICityRepository cityRepository { get; }

        Task<bool> SaveAsync();
    }
}
