namespace AppEstanteVirtual.Domain.DTOs.OutputModels
{
    public class AuthorOutputModelDTO
    {
        public AuthorOutputModelDTO() { }
        public AuthorOutputModelDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
