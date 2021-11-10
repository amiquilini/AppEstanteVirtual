using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEstanteVirtual.Domain.Entities
{
    public class Book : EntityBase<Book, BookInputModelDTO, BookOutputModelDTO>
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int? Pages { get; set; }
        public GenreEnum? Genre { get; set; }
        public ProgressEnum Progress { get; set; }
        public string CoverUrl { get; set; }

        public Book()
        {
        }

        public Book(string title, int authorId, int? pages = null, GenreEnum? genre = null, string coverUrl = null, ProgressEnum progress = 0)
        {
            Title = title;
            AuthorId = authorId;
            Pages = pages;
            Genre = genre;
            CoverUrl = coverUrl;
            Progress = progress;
        }
    }
}
