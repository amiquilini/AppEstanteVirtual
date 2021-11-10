using AppEstanteVirtual.Domain.DTOs.Shared;
using AppEstanteVirtual.Domain.Entities;
using AppEstanteVirtual.Domain.Enums;

namespace AppEstanteVirtual.Domain.DTOs.OutputModels
{
    public class BookOutputModelDTO : DTOBase<Book, BookOutputModelDTO>
    {
        public BookOutputModelDTO() {}
        public BookOutputModelDTO(int id, string title, int authorId, int? pages, GenreEnum? genre, ProgressEnum progress, string coverUrl)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Pages = pages;
            Genre = genre;
            Progress = progress;
            CoverUrl = coverUrl;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int? Pages { get; set; }
        public GenreEnum? Genre { get; set; }
        public ProgressEnum Progress { get; set; }
        public string CoverUrl { get; set; }
    }
}
