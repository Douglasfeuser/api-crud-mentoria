using ApiCrud.Database;
using ApiCrud.Models;
using ApiCrud.Repository.Interface;

namespace ApiCrud.Repository;

public class ClientRepository(DataContext context) : BaseRepository<Client, DataContext>(context), IClientRepository
{
    
}