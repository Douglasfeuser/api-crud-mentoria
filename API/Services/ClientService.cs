
using ApiCrud.Database;
using ApiCrud.Dtos.Client;
using ApiCrud.Models;
using ApiCrud.Repository;
using ApiCrud.Repository.Interface;
using ApiCrud.Services.Interface;
using AutoMapper;
using Azure;

namespace ApiCrud.Service;

public class ClientService(IMapper mapper, IClientRepository clientRepository, DataContext context) : IClientService
{
    private readonly IMapper _mapper = mapper;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly DataContext _context = context;

    public async Task<ServiceResponse<GetClientInfosDto>> AddClient(AddClientDto client)
    {
        ServiceResponse<GetClientInfosDto> response = new();
        try
        {
            Client mappedClient = _mapper.Map<Client>(client);
            Client newClient = await _clientRepository.InsertEntity(mappedClient);
            response.Data = _mapper.Map<GetClientInfosDto>(newClient);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetClientInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<List<GetClientInfosDto>>> GetAllClients()
    {
        ServiceResponse<List<GetClientInfosDto>> response = new();
        try
        {
            List<Client> clients = await _clientRepository.GetAll();

            if(clients.Count == 0)
            {
                return ErrorManager.ReturnError<List<GetClientInfosDto>>(EErrorType.NULL, "no clients.");
            }

            response.Data = _mapper.Map<List<GetClientInfosDto>>(clients);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<List<GetClientInfosDto>>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<GetClientInfosDto>> GetClientById(int id)
    {
        ServiceResponse<GetClientInfosDto> response = new();

        try
        {
            Client? client = await _clientRepository.GetEntityById(id);

            if(client == null)
            {
                return ErrorManager.ReturnError<GetClientInfosDto>(EErrorType.NULL, "client not found.");
            }

            response.Data = _mapper.Map<GetClientInfosDto>(client);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetClientInfosDto>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<UpdateClientDto>> UpdateClient(UpdateClientDto clientDto)
    {
        ServiceResponse<UpdateClientDto> response = new();

        try
        {
            Client? client= await _clientRepository.GetEntityById(clientDto.ClientId);
            if(client == null)
            {
                return ErrorManager.ReturnError<UpdateClientDto>(EErrorType.NULL, "client not found.");;
            }

            client.Name = clientDto.Name;
            client.LastName = clientDto.LastName;

            await _context.SaveChangesAsync();
            response.Data = clientDto;

            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<UpdateClientDto>(EErrorType.BAD, ex.Message);
        }
    }
}
