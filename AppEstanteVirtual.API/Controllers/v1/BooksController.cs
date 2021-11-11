using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AppEstanteVirtual.Domain.Shared;
using AppEstanteVirtual.Domain.Constants;
using AppEstanteVirtual.Domain.Shared.Contracts;
using Microsoft.AspNetCore.Http;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private Task<IResult> _result;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllAsync();

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, books);
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
                var book = await _bookService.GetByIdAsync(id);

                if (book == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, book);
                    return NotFound(_result);
                }

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, book);
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
                var books = await _bookService.GetBooksByProgress(progress);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, books);
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
                var books = await _bookService.GetBooksByGenre(genre);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, books);
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
                var author = await authorService.GetByIdAsync(authorId);

                if (author == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, author);
                    return NotFound(_result);
                }

                var books = await _bookService.GetBooksByAuthor(authorId);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, books);
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
                await _bookService.CreateAsync(bookInputModelDTO);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessRegistered, bookInputModelDTO.ConvertToObject().ConvertToObjectOutPut());
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
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, bookInputModelDTO);
                    return NotFound(_result);
                }

                var author = await authorService.GetByIdAsync(bookInputModelDTO.AuthorId);
                if (author == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, author);
                    return NotFound(_result);
                }

                await _bookService.UpdateAsync(bookInputModelDTO);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessChange, bookInputModelDTO);
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
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, book);
                    return NotFound(_result);
                }

                await _bookService.DeleteAsync(id);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessRemove, book);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
