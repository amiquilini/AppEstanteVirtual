using AppEstanteVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppEstanteVirtual.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
