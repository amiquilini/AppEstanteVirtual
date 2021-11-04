using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppEstanteVirtual.Application.DTOs.InputModels
{
    public class BookInputModelDTO
    {
        [Required(ErrorMessage = "Inform the title of the book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Inform the author of the book")]
        public string Author { get; set; }
    }
}
