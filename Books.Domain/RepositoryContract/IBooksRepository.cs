using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.RepositoryContract
{
    public interface IBooksRepository 
    {
        /// <summary>
        /// Get all books async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default);
    }
}
