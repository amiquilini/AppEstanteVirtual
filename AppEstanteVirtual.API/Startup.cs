using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AppEstanteVirtual.Infrastructure.Contexts;
using AppEstanteVirtual.Infrastructure.Repositories;
using AppEstanteVirtual.Domain.Repositories;
using AppEstanteVirtual.Application.Services;

namespace AppEstanteVirtual.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSingleton<IBookRepository, BookRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<BookService>();
            //services.AddDbContext<DataContext>(m => m.UseSqlServer(Configuration.GetConnectionString("BooksDB")), ServiceLifetime.Singleton);
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("BooksDB"));
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AppEstanteVirtual.API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppEstanteVirtual.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
