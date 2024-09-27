using ApiCrud.Dtos.Client;
using ApiCrud.Models;

namespace ApiCrud.Services.Interface;

public interface IClientService
{
    Task<ServiceResponse<GetClientInfosDto>> GetClientById(int id);
    Task<ServiceResponse<List<GetClientInfosDto>>> GetAllClients();
    Task<ServiceResponse<GetClientInfosDto>> AddClient(AddClientDto client);
    Task<ServiceResponse<UpdateClientDto>> UpdateClient(UpdateClientDto clientDto);
}