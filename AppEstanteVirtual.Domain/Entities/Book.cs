using AppEstanteVirtual.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEstanteVirtual.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int? Pages { get; set; }

        public GenreEnum? Genre { get; set; }

        public ProgressEnum Progress { get; set; }

        public string CoverUrl { get; set; }

        public Book()
        {
        }

        public Book(string title, string author, int? pages = null, GenreEnum? genre = null, string coverUrl = null, ProgressEnum progress = 0)
        {
            Title = title;
            Author = author;
            Pages = pages;
            Genre = genre;
            CoverUrl = coverUrl;
            Progress = progress;
        }
    }
}
