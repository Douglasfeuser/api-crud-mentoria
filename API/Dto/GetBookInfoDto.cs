namespace ApiCrud.Dtos;

public class GetBookInfosDto(int id, string title, string subTitle)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string SubTitle { get; set; } = subTitle;
}