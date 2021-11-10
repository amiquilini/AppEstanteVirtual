using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Domain.Repositories.Contracts
{
    public interface IRepository<T, TDtoOutputModel>
    {
        Task<List<TDtoOutputModel>> GetAllAsync();
        Task<TDtoOutputModel> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
