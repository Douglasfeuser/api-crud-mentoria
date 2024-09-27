namespace ApiCrud.Models;

public class Client : BaseEntityId
{
    [Column("name")]
    [Required]
    public string Name { get; set;} = string.Empty;

    [Column("lastname")]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [Column("birthdate")]
    public DateTime BirthDate { get; set; }
    
    public int Phone { get; set; }
    
    public ICollection<Rent> Rents { get; set; } = new List<Rent>();
}