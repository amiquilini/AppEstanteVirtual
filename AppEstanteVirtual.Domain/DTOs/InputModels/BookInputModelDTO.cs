using AppEstanteVirtual.Domain.DTOs.Shared;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEstanteVirtual.Domain.DTOs.InputModels
{
    public class BookInputModelDTO : DTOBase<BookInputModelDTO, Book>
    {
        public BookInputModelDTO() { }
        public BookInputModelDTO(string title, int authorId, int? pages, GenreEnum? genre, ProgressEnum progress, string coverUrl)
        {
            Title = title;
            AuthorId = authorId;
            Pages = pages;
            Genre = genre;
            Progress = progress;
            CoverUrl = coverUrl;
        }

        [Required(ErrorMessage = "Inform the title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Inform the author of the book")]
        public int AuthorId { get; set; }
        public int? Pages { get; set; }
        public GenreEnum? Genre { get; set; }
        public ProgressEnum Progress { get; set; }
        public string CoverUrl { get; set; }
    }
}
