using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Repositories.Contracts;

namespace AppEstanteVirtual.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author, AuthorOutputModelDTO>
    {
    }
}
