using AutoMapper;
using Books.Core.Books.Dto;
using Books.Domain.Entities;


namespace Books.Core.Mapper
{
    public class BooksProfile : Profile
    {
        public BooksProfile() {
            CreateMap<Book, BooksResponseDto>();
        }
    }
}
