using ApiCrud.Dtos.Rent;

namespace ApiCrud.Services.Interface
{
    public interface IRentService
    {
        Task<ServiceResponse<GetRentDto>> RentBooks(RentRequestDto rentRequest);
        Task<ServiceResponse<GetRentDto>> ReturnBooks(int rentId);
    }
}