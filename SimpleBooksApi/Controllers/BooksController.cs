using Books.Core.Books.Dto;
using Books.Core.Books.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksResponseDto>>> GetAll(CancellationToken cancellationToken = default)
        {
           var query = new GetAllBooksQuery();
           IEnumerable<BooksResponseDto> books =  await mediator.Send(query, cancellationToken);
           return Ok(books);
        }
    }
}
