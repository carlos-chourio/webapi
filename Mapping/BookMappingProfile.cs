using AutoMapper;
using WebApi.DTOs;
using WebApi.Entities;

namespace WebApi.Mapping {
    public class BookMappingProfile : Profile {
        public BookMappingProfile() {
            CreateMap<BookDtoBase, Book>().ForMember(dest => dest.)
        }
    }
}