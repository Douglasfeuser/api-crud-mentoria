namespace ApiCrud.Dtos;

public class UpdateAuthorDto
{
    public int AuthorId { get; set; }
    public string Name { get; set;} = string.Empty;
    public string LastName { get; set;} = string.Empty;
}