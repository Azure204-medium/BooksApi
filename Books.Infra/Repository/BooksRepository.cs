

using Books.Domain.Entities;
using Books.Domain.RepositoryContract;
using Books.Infra.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Books.Infra.Repository
{
    public class BooksRepository(ApplicationDbContext applicationDbContext) : IBooksRepository
    {
        // get all books
        public async Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken) 
        {
            return await applicationDbContext.Books.ToListAsync(cancellationToken);
        }
    }
}
