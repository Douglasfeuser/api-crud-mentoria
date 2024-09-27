namespace ApiCrud.Models;

public class Book : BaseEntityId
{
    [Column("title")]
    [Required]
    public string Title { get; set;} = string.Empty;

    [Column("subtitle")]
    public string SubTitle {get; set; } = string.Empty;

    public int AuthorId { get; set; }
    
    [Column("author")]
    [Required]
    public Author Author { get; set; }

    public int GenreId { get; set; }
    
    [Column("genre")]
    [Required]
    public Genre Genre { get; set; }
    
    public DateTime publishDate { get; set; }
    
    public ICollection<Rent> Rents { get; set; } = new List<Rent>();
}