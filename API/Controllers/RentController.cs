using ApiCrud.Dtos.Rent;
using ApiCrud.Models;
using ApiCrud.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        /// <summary>
        /// Cliente escolhe os livros para alugar.
        /// </summary>
        /// <param name="rentRequest">Detalhes do aluguel (ClientId, Lista de BooksIds)</param>
        /// <returns>Resposta do serviço com o status do aluguel.</returns>
        [HttpPost("rent-books")]
        public async Task<ActionResult<ServiceResponse<GetRentDto>>> RentBooks(RentRequestDto rentRequest)
        {
            var response = await _rentService.RentBooks(rentRequest);
            if (!response.Success)
                return BadRequest(response);
            
            return Ok(response);
        }

        /// <summary>
        /// Cliente devolve os livros alugados.
        /// </summary>
        /// <param name="rentId">Id do aluguel para devolução</param>
        /// <returns>Resposta do serviço com o status da devolução.</returns>
        [HttpPost("return-books/{rentId}")]
        public async Task<ActionResult<ServiceResponse<GetRentDto>>> ReturnBooks(int rentId)
        {
            var response = await _rentService.ReturnBooks(rentId);
            if (!response.Success)
                return BadRequest(response);
            
            return Ok(response);
        }
    }
}