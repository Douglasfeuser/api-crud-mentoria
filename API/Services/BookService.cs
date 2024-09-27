
using ApiCrud.Repository;
using ApiCrud.Repository.Interface;
using ApiCrud.Services.Interface;
using AutoMapper;

namespace ApiCrud.Service;

public class BookService(IMapper mapper, IBookRepository bookRepository, DataContext context, IBookRepository bookRepository1) : IBookService
{
    private readonly IMapper _mapper = mapper;
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly DataContext _context = context;

    public async Task<ServiceResponse<GetBookInfosDto>> AddBook(AddBookDto book)
    {
        ServiceResponse<GetBookInfosDto> response = new();
        try
        {
            Book mappedBook = _mapper.Map<Book>(book);
            Book newBook = await _bookRepository.InsertEntity(mappedBook);
            response.Data = _mapper.Map<GetBookInfosDto>(newBook);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetBookInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<List<GetBookInfosDto>>> GetAllBooks()
    {
        ServiceResponse<List<GetBookInfosDto>> response = new();
        try
        {
            List<Book> books = await _bookRepository.GetAll();

            if(books.Count == 0)
            {
                return ErrorManager.ReturnError<List<GetBookInfosDto>>(EErrorType.NULL, "no books.");
            }

            response.Data = _mapper.Map<List<GetBookInfosDto>>(books);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<List<GetBookInfosDto>>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<GetBookInfosDto>> GetBookById(int id)
    {
        ServiceResponse<GetBookInfosDto> response = new();

        try
        {
            Book? book = await _bookRepository.GetEntityById(id);

            if(book == null)
            {
                return ErrorManager.ReturnError<GetBookInfosDto>(EErrorType.NULL, "book not found.");
            }

            response.Data = _mapper.Map<GetBookInfosDto>(book);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetBookInfosDto>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>>> GetBooksWithPagination(int page)
    {
        ServiceResponse<BasePaginationResponseDto<GetBookInfosDto>> response = new();

        int batch_size = 15;
        try
        {
            page = page == 0 ? page++ : page;

            int total_books = await _context.Books.CountAsync();

            int total_pages = (int)Math.Ceiling((double)total_books / batch_size);

            if(page > total_pages)
            {
                return ErrorManager.ReturnError<BasePaginationResponseDto<GetBookInfosDto>>(EErrorType.BAD, "page out of range");
            }

            List<GetBookInfosDto> books = await _context.Books
                .OrderBy(u => u.Id)
                .Skip((page - 1) * batch_size)
                .Take(batch_size)
                .Select(u => new GetBookInfosDto(u.Id, u.Title, u.SubTitle))
                .ToListAsync();
            
            BasePaginationResponseDto<GetBookInfosDto> result = new()
            {
                Elements = books,
                TotalPages = total_pages,
                BatchSize = batch_size,
                Page = page
            };

            response.Data = result;
            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<BasePaginationResponseDto<GetBookInfosDto>>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<UpdateBookDto>> UpdateBook(UpdateBookDto bookDto)
    {
        ServiceResponse<UpdateBookDto> response = new();

        try
        {
            Book? book= await _bookRepository.GetEntityById(bookDto.BookId);
            if(book == null)
            {
                return ErrorManager.ReturnError<UpdateBookDto>(EErrorType.NULL, "book not found.");;
            }

            book.Title = bookDto.Title;
            book.SubTitle = bookDto.SubTitle;

            await _context.SaveChangesAsync();
            response.Data = bookDto;

            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<UpdateBookDto>(EErrorType.BAD, ex.Message);
        }
    }
}
