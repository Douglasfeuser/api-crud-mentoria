namespace ApiCrud.Dtos.Rent
{
    public class RentRequestDto
    {
        public int ClientId { get; set; }
        public List<int> BooksIds { get; set; } = new List<int>();
    }
}