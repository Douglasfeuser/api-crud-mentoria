namespace ApiCrud.Models;

public class Genre : BaseEntityId
{
    [Column("name")]
    [Required]
    public string Name { get; set;} = string.Empty;

    public List<Book> Books { get; set; }
}