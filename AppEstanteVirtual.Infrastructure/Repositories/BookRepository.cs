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
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id); 
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooksByProgress(int progress)
        {
            return await _context.Books
                .Where(b => (int)b.Progress == progress)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByGenre(int genre)
        {
            return await _context.Books
                .Where(b => (int)b.Genre == genre)
                .ToListAsync();
        }
    }
}
