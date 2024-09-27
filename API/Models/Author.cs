namespace ApiCrud.Models;

public class Author : BaseEntityId
{
    [Column("name")]
    [Required]
    public string Name { get; set;} = string.Empty;

    [Column("lastname")]
    public string LastName { get; set; } = string.Empty;

    [Column("birthdate")]
    public DateTime BirthDate { get; set; }
    
    public List<Book> Books { get; set; }
}