using AutoMapper;
using WebApi.DTOs;
using WebApi.Entities;

namespace WebApi.Mapping {
    public class BookMappingProfile : Profile {
        public BookMappingProfile() {
            CreateMap<Book, BookForGetDto>().ForMember(dest => dest.Author, t => t.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            CreateMap<BookForCreationDto, Book>();
        }
    }
}