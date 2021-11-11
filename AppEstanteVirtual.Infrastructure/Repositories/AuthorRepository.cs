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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Author entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AuthorOutputModelDTO>> GetAllAsync()
        {
            var authors = await _context.Authors
                            .AsNoTrackingWithIdentityResolution()
                            .Select(x => x.ConvertToObjectOutPut())
                            .ToListAsync();
            return authors;
        }

        public async Task<AuthorOutputModelDTO> GetByIdAsync(int id)
        {
            var author = await _context.Authors
                            .AsNoTrackingWithIdentityResolution()
                            .FirstOrDefaultAsync(x => x.Id == id);

            return author?.ConvertToObjectOutPut();
        }
    }
}
