using ApiCrud.Dtos.Client;
using ApiCrud.Dtos.Rent;
using ApiCrud.Dtos.Genre;
using ApiCrud.Dtos.Author;
using AutoMapper;

namespace ApiCrud.Mapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        //SOURCE -> DESTINATION
        _ = CreateMap<Book, GetBookInfosDto>();
        _ = CreateMap<AddBookDto, Book>();
        
        _ = CreateMap<Rent, GetRentDto>();
        _ = CreateMap<RentRequestDto, Rent>();

        _ = CreateMap<Client, GetClientInfosDto>();
        _ = CreateMap<AddClientDto, Client>();
        
        _ = CreateMap<Genre, GetGenreInfosDto>();
        _ = CreateMap<AddGenreDto, Genre>();
        
        _ = CreateMap<Author, GetAuthorInfosDto>();
        _ = CreateMap<AddAuthorDto, Author>();
    }
}