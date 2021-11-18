using AppEstanteVirtual.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppEstanteVirtual.Domain.DTOs.OutputModels
{
    public class AuthorOutputModelDTO
    {
        public AuthorOutputModelDTO() { }
        public AuthorOutputModelDTO(int id, string name, List<Book> books)
        {
            Id = id;
            Name = name;
            Books = books.Select(x => x.ConvertToObjectOutPut()).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookOutputModelDTO> Books { get; set; }
    }
}
