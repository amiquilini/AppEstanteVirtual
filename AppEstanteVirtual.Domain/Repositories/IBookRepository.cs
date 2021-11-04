using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetBooksByProgress(int progress);
        Task<List<Book>> GetBooksByGenre(int genre);
    }
}
