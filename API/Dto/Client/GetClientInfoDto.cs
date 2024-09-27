namespace ApiCrud.Dtos.Client;

public class GetClientInfosDto(int id, string name, string lastName)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Lastname { get; set; } = lastName;
}