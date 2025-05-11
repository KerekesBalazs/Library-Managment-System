using AutoMapper;
using Backend.Application.Books.DTOs.Common;
using Backend.Application.Books.DTOs.Create;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Books.DTOs.Update;
using WebAPI.DTOModels.Incoming.Book;
using WebAPI.DTOModels.Outgoing.Book;

namespace WebAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BaseBookRequest, BaseBookDTO>();

            // incoming
            CreateMap<CreateBookRequest, CreateBookDTO>();
            CreateMap<UpdateBookRequest, UpdateBookDTO>();

            // outgoing
            CreateMap<GetBookDTO, GetBookResponse>();

        }
    }
}
