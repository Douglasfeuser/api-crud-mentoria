using ApiCrud.Dtos.Client;
using ApiCrud.Models;
using ApiCrud.Services.Interface;

namespace ApiCrud.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ClientController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;

    /// <summary>
    /// Getting all clients.
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<ServiceResponse<List<GetClientInfosDto>>>> GetAllClients()
    {
        ServiceResponse<List<GetClientInfosDto>> response = await _clientService.GetAllClients();
        ActionResult<ServiceResponse<List<GetClientInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Adding a new client to Database
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<ServiceResponse<GetClientInfosDto>>> AddClient(AddClientDto client)
    {
        ServiceResponse<GetClientInfosDto> response = await _clientService.AddClient(client);
        ActionResult<ServiceResponse<GetClientInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Update single client informations.
    /// </summary>
    /// <param name="update_infos"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<ActionResult<ServiceResponse<UpdateClientDto>>> UpdateClient(UpdateClientDto update_infos)
    {
        ServiceResponse<UpdateClientDto> response = await _clientService.UpdateClient(update_infos);
        ActionResult<ServiceResponse<UpdateClientDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
}