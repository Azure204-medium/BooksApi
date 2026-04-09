using AutoMapper;
using Books.Core.Books.Dto;
using Books.Domain.Entities;
using Books.Domain.RepositoryContract;
using MediatR;

namespace Books.Core.Books.Query
{
    public class GetAllBooksQueryHandler(IBooksRepository booksRepository,IMapper mapper) : IRequestHandler<GetAllBooksQuery, IEnumerable<BooksResponseDto>>
    {
  
        public async Task<IEnumerable<BooksResponseDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Book> books = await booksRepository.GetAllBooksAsync(cancellationToken);
            return mapper.Map<IEnumerable<BooksResponseDto>>(books);
        }
    }
}
