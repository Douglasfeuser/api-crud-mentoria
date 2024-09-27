
using ApiCrud.Database;
using ApiCrud.Dtos.Genre;
using ApiCrud.Models;
using ApiCrud.Repository;
using ApiCrud.Services.Interface;
using AutoMapper;
using Azure;

namespace ApiCrud.Service;

public class GenreService(IMapper mapper, GenreRepository genreRepository, DataContext context) : IGenreService
{
    private readonly IMapper _mapper = mapper;
    private readonly GenreRepository _genreRepository = genreRepository;
    private readonly DataContext _context = context;

    public async Task<ServiceResponse<GetGenreInfosDto>> AddGenre(AddGenreDto genre)
    {
        ServiceResponse<GetGenreInfosDto> response = new();
        try
        {
            Genre mappedGenre = _mapper.Map<Genre>(genre);
            Genre newGenre = await _genreRepository.InsertEntity(mappedGenre);
            response.Data = _mapper.Map<GetGenreInfosDto>(newGenre);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetGenreInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<List<GetGenreInfosDto>>> GetAllGenres()
    {
        ServiceResponse<List<GetGenreInfosDto>> response = new();
        try
        {
            List<Genre> genres = await _genreRepository.GetAll();

            if(genres.Count == 0)
            {
                return ErrorManager.ReturnError<List<GetGenreInfosDto>>(EErrorType.NULL, "no genres.");
            }

            response.Data = _mapper.Map<List<GetGenreInfosDto>>(genres);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<List<GetGenreInfosDto>>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<GetGenreInfosDto>> GetGenreById(int id)
    {
        ServiceResponse<GetGenreInfosDto> response = new();

        try
        {
            Genre? genre = await _genreRepository.GetEntityById(id);

            if(genre == null)
            {
                return ErrorManager.ReturnError<GetGenreInfosDto>(EErrorType.NULL, "genre not found.");
            }

            response.Data = _mapper.Map<GetGenreInfosDto>(genre);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetGenreInfosDto>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<UpdateGenreDto>> UpdateGenre(UpdateGenreDto genreDto)
    {
        ServiceResponse<UpdateGenreDto> response = new();

        try
        {
            Genre? genre= await _genreRepository.GetEntityById(genreDto.GenreId);
            if(genre == null)
            {
                return ErrorManager.ReturnError<UpdateGenreDto>(EErrorType.NULL, "genre not found.");;
            }

            genre.Name = genreDto.Name;

            await _context.SaveChangesAsync();
            response.Data = genreDto;

            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<UpdateGenreDto>(EErrorType.BAD, ex.Message);
        }
    }
    
    public async Task<ServiceResponse<GetGenreInfosDto>> DeleteGenre(int id)
    {
        ServiceResponse<GetGenreInfosDto> response = new();

        try
        {
            // Busca o gênero pelo ID
            Genre? genre = await _genreRepository.GetEntityById(id);
        
            // Verifica se o gênero existe
            if (genre == null)
            {
                return ErrorManager.ReturnError<GetGenreInfosDto>(EErrorType.NULL, "genre not found.");
            }

            // Remove o gênero do repositório
            _genreRepository.DeleteEntity(genre);
            await _context.SaveChangesAsync();

            // Mapeia a resposta e retorna os dados do gênero deletado
            response.Data = _mapper.Map<GetGenreInfosDto>(genre);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetGenreInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

}
