using AppEstanteVirtual.Application.Services;
using AppEstanteVirtual.Domain.Repositories;
using AppEstanteVirtual.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppEstanteVirtual.API.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<BookService>();
            services.AddTransient<AuthorService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
        }
    }
}
