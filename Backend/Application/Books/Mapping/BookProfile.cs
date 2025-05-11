using AutoMapper;
using Backend.Application.Books.DTOs.Common;
using Backend.Application.Books.DTOs.Create;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Books.DTOs.Update;
using Backend.Domain.Entities;

namespace Backend.Application.Books.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BaseBookDTO>();

            // Incoming
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();

            // Outgoing
            CreateMap<Book, GetBookDTO>();
        }
    }
}
