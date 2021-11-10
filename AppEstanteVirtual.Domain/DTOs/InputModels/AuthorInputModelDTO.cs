using AppEstanteVirtual.Domain.DTOs.Shared;
using AppEstanteVirtual.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppEstanteVirtual.Domain.DTOs.InputModels
{
    public class AuthorInputModelDTO : DTOBase<AuthorInputModelDTO, Author>
    {
        public AuthorInputModelDTO() { }
        public AuthorInputModelDTO(string name, int? id)
        {
            Name = name;
            Id = id;
        }

        [Required(ErrorMessage = "Inform the name of the author")]
        public string Name { get; set; }
        public int? Id { get; set; }
    }
}
