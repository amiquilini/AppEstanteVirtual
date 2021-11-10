using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("ByProgress/{progress}")]
        public async Task<ActionResult> GetBooksByProgress(int progress)
        {
            var books = await _bookService.GetBooksByProgress(progress);

            return Ok(books);
        }

        [HttpGet("ByGenre/{genre}")]
        public async Task<ActionResult> GetBooksByGenre(int genre)
        {
            var books = await _bookService.GetBooksByGenre(genre);

            return Ok(books);
        }

        [HttpGet("ByAuthor/{authorId}")]
        public async Task<ActionResult> GetBooksByAuthor(int authorId, [FromServices] AuthorService authorService)
        {
            var author = await authorService.GetByIdAsync(authorId);

            if (author == null)
            {
                return NotFound("Author not found");
            }

            var books = await _bookService.GetBooksByAuthor(authorId);

            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] BookInputModelDTO bookInputModelDTO)
        {
            var id = await _bookService.CreateAsync(bookInputModelDTO);

            return CreatedAtAction(nameof(GetBookById), new { id = id }, bookInputModelDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookInputModelDTO bookInputModelDTO, [FromServices] AuthorService authorService)
        {
            if (id != bookInputModelDTO.Id)
                return BadRequest("Book Id mismatch");

            var author = await authorService.GetByIdAsync(bookInputModelDTO.AuthorId);
            if (author == null)
            {
                return NotFound("Author not found");
            }

            await _bookService.UpdateAsync(bookInputModelDTO);

            return Ok(bookInputModelDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookService.DeleteAsync(id);

            return NoContent();
        }
    }
}
