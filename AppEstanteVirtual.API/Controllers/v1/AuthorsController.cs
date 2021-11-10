using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Application.Services;
using AppEstanteVirtual.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorInputModelDTO authorInputModelDTO)
        {
            var id = await _authorService.CreateAsync(authorInputModelDTO);

            return CreatedAtAction(nameof(GetAuthorById), new { id = id }, authorInputModelDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] AuthorInputModelDTO authorInputModelDTO)
        {

            if (id != authorInputModelDTO.Id || authorInputModelDTO.Id == null)
                return BadRequest("Author Id mismatch");

            await _authorService.UpdateAsync(authorInputModelDTO);

            return Ok(authorInputModelDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            await _authorService.DeleteAsync(id);

            return NoContent();
        }
    }
}
