using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppEstanteVirtual.Domain.Entities
{
    public class Author : EntityBase<Author, AuthorInputModelDTO, AuthorOutputModelDTO>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }
    }
}
