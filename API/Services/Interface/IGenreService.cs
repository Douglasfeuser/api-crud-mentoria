using ApiCrud.Dtos.Genre;
using ApiCrud.Models;

namespace ApiCrud.Services.Interface;

public interface IGenreService
{
    Task<ServiceResponse<GetGenreInfosDto>> GetGenreById(int id);
    Task<ServiceResponse<List<GetGenreInfosDto>>> GetAllGenres();
    Task<ServiceResponse<GetGenreInfosDto>> AddGenre(AddGenreDto genre);
    Task<ServiceResponse<UpdateGenreDto>> UpdateGenre(UpdateGenreDto genreDto);
    Task<ServiceResponse<GetGenreInfosDto>> DeleteGenre(int id);

}