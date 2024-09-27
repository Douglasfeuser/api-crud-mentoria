using ApiCrud.Dtos.Author;
using ApiCrud.Models;

namespace ApiCrud.Services.Interface;

public interface IAuthorService
{
    Task<ServiceResponse<GetAuthorInfosDto>> GetAuthorById(int id);
    Task<ServiceResponse<List<GetAuthorInfosDto>>> GetAllAuthors();
    Task<ServiceResponse<GetAuthorInfosDto>> AddAuthor(AddAuthorDto author);
    Task<ServiceResponse<UpdateAuthorDto>> UpdateAuthor(UpdateAuthorDto authorDto);
}