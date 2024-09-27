using ApiCrud.Dtos.Rent;
using ApiCrud.Repository.Interface;
using ApiCrud.Services.Interface;
using AutoMapper;

namespace ApiCrud.Service
{
    public class RentService(IRentRepository rentRepository, IBookRepository bookRepository, IClientRepository clientRepository, IMapper mapper) : IRentService
    {
        private readonly IRentRepository _rentRepository = rentRepository;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IClientRepository _clientRepository = clientRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ServiceResponse<GetRentDto>> RentBooks(RentRequestDto rentRequest)
        {
            var response = new ServiceResponse<GetRentDto>();

            try
            {
                // Verificar se o cliente existe
                var client = await _clientRepository.GetEntityById(rentRequest.ClientId);
                if (client == null)
                {
                    response.Success = false;
                    response.Message = "Client not found.";
                    return response;
                }

                // Buscar os livros pelo Id
                var books = _bookRepository.GetBooksByIds(rentRequest.BooksIds);
                if (!books.Any())
                {
                    response.Success = false;
                    response.Message = "Books not found.";
                    return response;
                }

                // Criar o novo aluguel
                var rent = new Rent
                {
                    Client = client,
                    Books = books,
                    RentDate = DateTime.UtcNow
                };

                var newRent = await _rentRepository.InsertEntity(rent);

                response.Data = _mapper.Map<GetRentDto>(newRent);
                response.Success = true;
                response.Message = "Books rented successfully!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error while renting books: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<GetRentDto>> ReturnBooks(int rentId)
        {
            var response = new ServiceResponse<GetRentDto>();

            try
            {
                // Buscar o aluguel pelo Id
                var rent = await _rentRepository.GetEntityById(rentId);
                if (rent == null)
                {
                    response.Success = false;
                    response.Message = "Rent not found.";
                    return response;
                }

                // Atualizar a data de devolução
                rent.ReturnDate = DateTime.UtcNow;
                await _rentRepository.UpdateEntity(rent);

                response.Data = _mapper.Map<GetRentDto>(rent);
                response.Success = true;
                response.Message = "Books returned successfully!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error while returning books: {ex.Message}";
            }

            return response;
        }
    }
}
