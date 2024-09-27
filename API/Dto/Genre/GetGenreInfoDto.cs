namespace ApiCrud.Dtos.Genre;

public class GetGenreInfosDto(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}