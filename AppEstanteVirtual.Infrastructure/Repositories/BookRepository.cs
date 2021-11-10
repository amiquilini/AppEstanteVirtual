using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Repositories;
using AppEstanteVirtual.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Book entity)
        {
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Book entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id); 
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookOutputModelDTO>> GetAllAsync()
        {
            var books = await _context.Books
                            .AsNoTrackingWithIdentityResolution()
                            .Select(x => x.ConvertToObjectOutPut())
                            .ToListAsync();
            return books;
        }

        public async Task<BookOutputModelDTO> GetByIdAsync(int id)
        {
            var book = await _context.Books
                            .AsNoTrackingWithIdentityResolution()
                            .FirstOrDefaultAsync(x => x.Id == id);

            return book?.ConvertToObjectOutPut();
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByProgress(int progress)
        {
            var books = await _context.Books
                            .AsNoTrackingWithIdentityResolution()
                            .Where(b => (int)b.Progress == progress)
                            .Select(x => x.ConvertToObjectOutPut())
                            .ToListAsync();
            return books;

        }

        public async Task<List<BookOutputModelDTO>> GetBooksByGenre(int genre)
        {

            var books = await _context.Books
                            .AsNoTrackingWithIdentityResolution()
                            .Where(b => (int)b.Genre == genre)
                            .Select(x => x.ConvertToObjectOutPut())
                            .ToListAsync();
            return books;
        }

        public async Task<List<BookOutputModelDTO>> GetBooksByAuthor(int author)
        {
            var books = await _context.Books
                            .AsNoTrackingWithIdentityResolution()
                            .Where(b => b.AuthorId == author)
                            .Select(x => x.ConvertToObjectOutPut())
                            .ToListAsync();
            return books;
        }
    }
}
