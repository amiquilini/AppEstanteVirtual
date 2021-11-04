using AppEstanteVirtual.Application.DTOs.InputModels;
using AppEstanteVirtual.Application.DTOs.OutputModels;
using AppEstanteVirtual.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/[controller]")]
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

        [HttpGet("progress/{progress}")]
        public async Task<ActionResult> GetBookByProgress(int progress)
        {
            var books = await _bookService.GetBooksByProgress(progress);

            return Ok(books);
        }

        [HttpGet("genre/{genre}")]
        public async Task<ActionResult> GetBookByGenre(int genre)
        {
            var books = await _bookService.GetBooksByGenre(genre);

            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] BookInputModelDTO bookInputModelDTO)
        {
            var id = await _bookService.CreateAsync(bookInputModelDTO);

            return CreatedAtAction(nameof(GetBookById), new { id = id }, bookInputModelDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookOutputModelDTO bookOutputModelDTO)
        {
            if (id != bookOutputModelDTO.Id)
                return BadRequest("Book Id mismatch");

            await _bookService.UpdateAsync(bookOutputModelDTO);

            return Ok(bookOutputModelDTO);
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
