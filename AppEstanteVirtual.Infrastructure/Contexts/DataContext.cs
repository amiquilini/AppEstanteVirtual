using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppEstanteVirtual.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new AuthorMapping())
                .ApplyConfiguration(new BookMapping());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
