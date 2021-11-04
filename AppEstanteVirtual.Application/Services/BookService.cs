using AppEstanteVirtual.Application.DTOs.InputModels;
using AppEstanteVirtual.Application.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<int> CreateAsync(BookInputModelDTO bookInputModelDTO)
        {
            var book = new Book(bookInputModelDTO.Title, bookInputModelDTO.Author);
            
            var id = await _bookRepository.CreateAsync(book);

            return id;
        }

        public async Task UpdateAsync(BookOutputModelDTO bookOutputModelDTO)
        {
            var book = new Book
            {
                Id = bookOutputModelDTO.Id,
                Title = bookOutputModelDTO.Title,
                Author = bookOutputModelDTO.Author,
                Pages = bookOutputModelDTO.Pages,
                Genre = bookOutputModelDTO.Genre,
                Progress = bookOutputModelDTO.Progress
            };

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookOutputModelDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var bookOutputModelList = books
                .Select(b => new BookOutputModelDTO 
                    { 
                        Id = b.Id, 
                        Title = b.Title, 
                        Author = b.Author, 
                        Pages = b.Pages, 
                        Genre = b.Genre, 
                        Progress = b.Progress 
                    })
                .ToList();
            
            return bookOutputModelList;
        }

        public async Task<BookOutputModelDTO> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            var bookOutputModelDTO = new BookOutputModelDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Pages = book.Pages,
                Genre = book.Genre,
                Progress = book.Progress
            };

            return bookOutputModelDTO;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByProgress(int progress)
        {
            var books = await _bookRepository.GetBooksByProgress(progress);

            var bookOutputModelList = books
                .Select(b => new BookOutputModelDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Pages = b.Pages,
                    Genre = b.Genre,
                    Progress = b.Progress
                })
                .ToList();

            return bookOutputModelList;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByGenre(int genre)
        {
            var books = await _bookRepository.GetBooksByGenre(genre);

            var bookOutputModelList = books
                .Select(b => new BookOutputModelDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Pages = b.Pages,
                    Genre = b.Genre,
                    Progress = b.Progress
                })
                .ToList();

            return bookOutputModelList;
        }
    }
}
