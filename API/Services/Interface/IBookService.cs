using ApiCrud.Dtos;
using ApiCrud.Models;

namespace ApiCrud.Services.Interface;

public interface IBookService
{
    Task<ServiceResponse<GetBookInfosDto>> GetBookById(int id);
    Task<ServiceResponse<List<GetBookInfosDto>>> GetAllBooks();
    Task<ServiceResponse<GetBookInfosDto>> AddBook(AddBookDto book);
    Task<ServiceResponse<UpdateBookDto>> UpdateBook(UpdateBookDto bookDto);
    Task<ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>>> GetBooksWithPagination(int page);
}