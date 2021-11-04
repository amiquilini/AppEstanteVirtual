using AppEstanteVirtual.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEstanteVirtual.Application.DTOs.OutputModels
{
    public class BookOutputModelDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int? Pages { get; set; }

        public GenreEnum? Genre { get; set; }

        public ProgressEnum Progress { get; set; }

        public string CoverUrl { get; set; }
    }
}
