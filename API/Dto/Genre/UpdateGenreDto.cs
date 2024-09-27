namespace ApiCrud.Dtos.Genre;

public class UpdateGenreDto
{
    public int GenreId { get; set; }
    public string Name { get; set;} = string.Empty;
}