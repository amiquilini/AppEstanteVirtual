using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AppEstanteVirtual.Domain.Shared;
using AppEstanteVirtual.Domain.Constants;
using AppEstanteVirtual.Domain.Shared.Contracts;
using AppEstanteVirtual.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private IResult _result;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                _result = await _bookService.GetAllAsync();

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            try
            {
                _result = await _bookService.GetByIdAsync(id);

                if (_result.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(_result);
                }

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("ByProgress/{progress}")]
        public async Task<ActionResult> GetBooksByProgress(int progress)
        {
            try
            {
                _result = await _bookService.GetBooksByProgress(progress);

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ByGenre/{genre}")]
        public async Task<ActionResult> GetBooksByGenre(int genre)
        {
            try
            {
                _result = await _bookService.GetBooksByGenre(genre);

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("ByAuthor/{authorId}")]
        public async Task<ActionResult> GetBooksByAuthor(int authorId, [FromServices] AuthorService authorService)
        {
            try
            {
                _result = await _bookService.GetBooksByAuthor(authorId, authorService);

                if (_result.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(_result);
                }

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] BookInputModelDTO bookInputModelDTO)
        {
            try
            {
                _result = await _bookService.CreateAsync(bookInputModelDTO);
                
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookInputModelDTO bookInputModelDTO, [FromServices] AuthorService authorService)
        {
            try
            {
                _result = await _bookService.UpdateAsync(id, bookInputModelDTO, authorService);
                if (_result.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(_result);
                }

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                _result = await _bookService.DeleteAsync(id);

                if (_result.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(_result);
                }

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
