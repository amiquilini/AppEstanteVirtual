using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Application.Services;
using AppEstanteVirtual.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppEstanteVirtual.Domain.Shared.Contracts;
using AppEstanteVirtual.Domain.Shared;
using AppEstanteVirtual.Domain.Constants;
using System;
using Microsoft.AspNetCore.Http;

namespace AppEstanteVirtual.API.Controllers.v1
{
    [Route("v1/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private Task<IResult> _result;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            try
            {
                var authors = await _authorService.GetAllAsync();

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, authors);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);

                if (author == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, author);
                    return NotFound(_result);
                }

                _result = Result.ResultAsync(GlobalMessageConstants.MessageEmpty, author);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorInputModelDTO authorInputModelDTO)
        {
            try
            {
                await _authorService.CreateAsync(authorInputModelDTO);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessRegistered, authorInputModelDTO.ConvertToObject().ConvertToObjectOutPut());
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] AuthorInputModelDTO authorInputModelDTO)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, authorInputModelDTO);
                    return NotFound(_result);
                }

                await _authorService.UpdateAsync(authorInputModelDTO);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessChange, authorInputModelDTO);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null)
                {
                    _result = Result.ResultAsync(GlobalMessageConstants.MessageDataNotFound, author);
                    return NotFound(_result);
                }

                await _authorService.DeleteAsync(id);

                _result = Result.ResultAsync(GlobalMessageConstants.MessageSucessRemove, author);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
