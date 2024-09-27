namespace ApiCrud.Dtos.Rent
{
    public class GetRentDto
    {
        public int RentId { get; set; }
        public int ClientId { get; set; }
        public List<int> BooksIds { get; set; } = new List<int>();
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}