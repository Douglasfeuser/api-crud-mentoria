using ApiCrud.Models;

namespace ApiCrud.Repository.Interface
{
    public interface IRentRepository
    {
        Task<Rent?> GetEntityById(int id);
        Task<Rent> InsertEntity(Rent entity);
        Task UpdateEntity(Rent entity);
    }
}