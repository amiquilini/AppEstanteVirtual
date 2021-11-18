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
        private IResult _result;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            try
            {
                _result = await _authorService.GetAllAsync();

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
                _result = await _authorService.GetByIdAsync(id);

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
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorInputModelDTO authorInputModelDTO)
        {
            try
            {
                _result = await _authorService.CreateAsync(authorInputModelDTO);

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
                _result = await _authorService.UpdateAsync(id, authorInputModelDTO);
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
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                _result = await _authorService.DeleteAsync(id);
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
