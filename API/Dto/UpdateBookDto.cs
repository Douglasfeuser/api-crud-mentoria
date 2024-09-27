namespace ApiCrud.Dtos;

public class UpdateBookDto
{
    public int BookId { get; set; }
    public string Title { get; set;} = string.Empty;
    public string SubTitle { get; set;} = string.Empty;
}