using AutoMapper;
using Books.Core.Books.Dto;
using Books.Domain.Entities;
using Books.Domain.RepositoryContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Books.Core.Books.Query
{
    public class GetAllBooksQueryHandler(IBooksRepository booksRepository,IMapper mapper,ILogger<GetAllBooksQueryHandler> logger) : IRequestHandler<GetAllBooksQuery, IEnumerable<BooksResponseDto>>
    {
  
        public async Task<IEnumerable<BooksResponseDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetAllBooksQueryHandler {@Request}", request);
            IEnumerable<Book> books = await booksRepository.GetAllBooksAsync(cancellationToken);
            return mapper.Map<IEnumerable<BooksResponseDto>>(books);
        }
    }
}
