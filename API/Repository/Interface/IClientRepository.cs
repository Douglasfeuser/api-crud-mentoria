using ApiCrud.Models;

namespace ApiCrud.Repository.Interface
{
    public interface IClientRepository
    {
        Task<Client?> GetEntityById(int id);
        Task<List<Client>> GetAll();
        Task<Client> InsertEntity(Client entity);
        Task UpdateEntity(Client entity);
    }
}