using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateAsync(BookInputModelDTO bookInputModelDTO)
        {
            var book = bookInputModelDTO.ConvertToObject();

            await _bookRepository.CreateAsync(book);
        }

        public async Task UpdateAsync(BookInputModelDTO bookInputModelDTO)
        {
            var book = bookInputModelDTO.ConvertToObject();

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookOutputModelDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            
            return books;
        }

        public async Task<BookOutputModelDTO> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return book;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByProgress(int progress)
        {
            var books = await _bookRepository.GetBooksByProgress(progress);

            return books;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByGenre(int genre)
        {
            var books = await _bookRepository.GetBooksByGenre(genre);

            return books;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByAuthor(int author)
        {
            var books = await _bookRepository.GetBooksByAuthor(author);

            return books;
        }
    }
}
