using Books.Core.Books.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Books.Query
{
    /// <summary>
    /// Get all books query
    /// </summary>
    public class GetAllBooksQuery : IRequest<IEnumerable<BooksResponseDto>>
    {
    }
}
