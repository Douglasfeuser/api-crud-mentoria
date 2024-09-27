using Azure;

namespace ApiCrud.Dtos;

public class BasePaginationResponseDto<D> 
{
    public List<D>? Elements {get; set;}
    public int Page {get; set;}
    public int TotalPages {get; set;}
    public int BatchSize {get; set;}
}