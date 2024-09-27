namespace ApiCrud.Models;

public class Rent : BaseEntityId
{
    [Column("rent_date")]
    public DateTime RentDate { get; set; }

    [Column("return_date")]
    public DateTime? ReturnDate { get; set; }
    
    public int ClientId { get; set; }
    
    public Client Client { get; set; }

    public IEnumerable<Book> Books { get; set; }
}