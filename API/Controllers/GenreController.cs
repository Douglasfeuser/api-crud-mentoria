using ApiCrud.Dtos.Genre;
using ApiCrud.Models;
using ApiCrud.Services.Interface;

namespace ApiCrud.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private readonly IGenreService _genreService = genreService;

    /// <summary>
    /// Getting all genres.
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<ServiceResponse<List<GetGenreInfosDto>>>> GetAllGenres()
    {
        ServiceResponse<List<GetGenreInfosDto>> response = await _genreService.GetAllGenres();
        ActionResult<ServiceResponse<List<GetGenreInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Adding a new genre to Database
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<ServiceResponse<GetGenreInfosDto>>> AddGenre(AddGenreDto genre)
    {
        ServiceResponse<GetGenreInfosDto> response = await _genreService.AddGenre(genre);
        ActionResult<ServiceResponse<GetGenreInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Update single genre informations.
    /// </summary>
    /// <param name="update_infos"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<ActionResult<ServiceResponse<UpdateGenreDto>>> UpdateGenre(UpdateGenreDto update_infos)
    {
        ServiceResponse<UpdateGenreDto> response = await _genreService.UpdateGenre(update_infos);
        ActionResult<ServiceResponse<UpdateGenreDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
    
    /// <summary>
    /// Deleting a genre from the Database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetGenreInfosDto>>> DeleteGenre(int id)
    {
        ServiceResponse<GetGenreInfosDto> response = await _genreService.DeleteGenre(id);
        ActionResult<ServiceResponse<GetGenreInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
}
