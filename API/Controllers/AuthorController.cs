using ApiCrud.Dtos.Author;
using ApiCrud.Services.Interface;

namespace ApiCrud.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private readonly IAuthorService _authorService = authorService;

    /// <summary>
    /// Getting all authors.
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<ServiceResponse<List<GetAuthorInfosDto>>>> GetAllAuthors()
    {
        ServiceResponse<List<GetAuthorInfosDto>> response = await _authorService.GetAllAuthors();
        ActionResult<ServiceResponse<List<GetAuthorInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Adding a new author to Database
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<ServiceResponse<GetAuthorInfosDto>>> AddAuthor(AddAuthorDto author)
    {
        ServiceResponse<GetAuthorInfosDto> response = await _authorService.AddAuthor(author);
        ActionResult<ServiceResponse<GetAuthorInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Update single author informations.
    /// </summary>
    /// <param name="update_infos"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<ActionResult<ServiceResponse<UpdateAuthorDto>>> UpdateAuthor(UpdateAuthorDto update_infos)
    {
        ServiceResponse<UpdateAuthorDto> response = await _authorService.UpdateAuthor(update_infos);
        ActionResult<ServiceResponse<UpdateAuthorDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
}
