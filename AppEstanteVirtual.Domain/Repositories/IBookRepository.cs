using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book, BookOutputModelDTO>
    {
        Task<List<BookOutputModelDTO>> GetBooksByProgress(int progress);
        Task<List<BookOutputModelDTO>> GetBooksByGenre(int genre);
        Task<List<BookOutputModelDTO>> GetBooksByAuthor(int author);
    }
}
