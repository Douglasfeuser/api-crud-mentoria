
using ApiCrud.Database;
using ApiCrud.Dtos.Author;
using ApiCrud.Models;
using ApiCrud.Repository;
using ApiCrud.Services.Interface;
using AutoMapper;
using Azure;

namespace ApiCrud.Service;

public class AuthorService(IMapper mapper, AuthorRepository authorRepository, DataContext context) : IAuthorService
{
    private readonly IMapper _mapper = mapper;
    private readonly AuthorRepository _authorRepository = authorRepository;
    private readonly DataContext _context = context;

    public async Task<ServiceResponse<GetAuthorInfosDto>> AddAuthor(AddAuthorDto author)
    {
        ServiceResponse<GetAuthorInfosDto> response = new();
        try
        {
            Author mappedAuthor = _mapper.Map<Author>(author);
            Author newAuthor = await _authorRepository.InsertEntity(mappedAuthor);
            response.Data = _mapper.Map<GetAuthorInfosDto>(newAuthor);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetAuthorInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<List<GetAuthorInfosDto>>> GetAllAuthors()
    {
        ServiceResponse<List<GetAuthorInfosDto>> response = new();
        try
        {
            List<Author> authors = await _authorRepository.GetAll();

            if(authors.Count == 0)
            {
                return ErrorManager.ReturnError<List<GetAuthorInfosDto>>(EErrorType.NULL, "no authors.");
            }

            response.Data = _mapper.Map<List<GetAuthorInfosDto>>(authors);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<List<GetAuthorInfosDto>>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<GetAuthorInfosDto>> GetAuthorById(int id)
    {
        ServiceResponse<GetAuthorInfosDto> response = new();

        try
        {
            Author? author = await _authorRepository.GetEntityById(id);

            if(author == null)
            {
                return ErrorManager.ReturnError<GetAuthorInfosDto>(EErrorType.NULL, "author not found.");
            }

            response.Data = _mapper.Map<GetAuthorInfosDto>(author);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetAuthorInfosDto>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<UpdateAuthorDto>> UpdateAuthor(UpdateAuthorDto authorDto)
    {
        ServiceResponse<UpdateAuthorDto> response = new();

        try
        {
            Author? author= await _authorRepository.GetEntityById(authorDto.AuthorId);
            if(author == null)
            {
                return ErrorManager.ReturnError<UpdateAuthorDto>(EErrorType.NULL, "author not found.");;
            }

            author.Name = authorDto.Name;
            author.LastName = authorDto.LastName;

            await _context.SaveChangesAsync();
            response.Data = authorDto;

            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<UpdateAuthorDto>(EErrorType.BAD, ex.Message);
        }
    }
}
