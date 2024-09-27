namespace ApiCrud.Dtos;

public class UpdateClientDto
{
    public int ClientId { get; set; }
    public string Name { get; set;} = string.Empty;
    public string LastName { get; set;} = string.Empty;
}