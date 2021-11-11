using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Application.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task CreateAsync(AuthorInputModelDTO authorInputModelDTO)
        {
            var author = authorInputModelDTO.ConvertToObject();

            await _authorRepository.CreateAsync(author);

        }

        public async Task UpdateAsync(AuthorInputModelDTO authorInputModelDTO)
        {
            var author = authorInputModelDTO.ConvertToObject();

            await _authorRepository.UpdateAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<AuthorOutputModelDTO>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            return authors.ToList();
        }

        public async Task<AuthorOutputModelDTO> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return null;
            }

            return author;
        }
    }
}
