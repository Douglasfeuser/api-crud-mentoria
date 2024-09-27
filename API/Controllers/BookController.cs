using ApiCrud.Services.Interface;

namespace ApiCrud.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    /// <summary>
    /// Getting all books.
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<ServiceResponse<List<GetBookInfosDto>>>> GetAllBooks()
    {
        ServiceResponse<List<GetBookInfosDto>> response = await _bookService.GetAllBooks();
        ActionResult<ServiceResponse<List<GetBookInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Getting a specific book based on his id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetBookInfosDto>>> GetBookById(int id)
    {
        ServiceResponse<GetBookInfosDto> response = await _bookService.GetBookById(id);
        ActionResult<ServiceResponse<GetBookInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    [HttpGet("books/{page}")]
    public async Task<ActionResult<ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>>>> GetBookWithPagination(int page)
    {
        ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>> response = await _bookService.GetBooksWithPagination(page);
        ActionResult<ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Adding a new book to Database
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<ServiceResponse<GetBookInfosDto>>> AddBook(AddBookDto book)
    {
        ServiceResponse<GetBookInfosDto> response = await _bookService.AddBook(book);
        ActionResult<ServiceResponse<GetBookInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Update single book informations.
    /// </summary>
    /// <param name="update_infos"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<ActionResult<ServiceResponse<UpdateBookDto>>> UpdateBook(UpdateBookDto update_infos)
    {
        ServiceResponse<UpdateBookDto> response = await _bookService.UpdateBook(update_infos);
        ActionResult<ServiceResponse<UpdateBookDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
}
