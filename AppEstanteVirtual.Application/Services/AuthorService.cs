using AppEstanteVirtual.Domain.Constants;
using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.DTOs.OutputModels;
using AppEstanteVirtual.Domain.Repositories;
using AppEstanteVirtual.Domain.Shared;
using AppEstanteVirtual.Domain.Shared.Contracts;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Application.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResult> CreateAsync(AuthorInputModelDTO authorInputModelDTO)
        {
            var author = authorInputModelDTO.ConvertToObject();

            await _authorRepository.CreateAsync(author);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessRegistered, author.ConvertToObjectOutPut());

        }

        public async Task<IResult> UpdateAsync(int id, AuthorInputModelDTO authorInputModelDTO)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            var authorObj = authorInputModelDTO.ConvertToObject();
            await _authorRepository.UpdateAsync(authorObj);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessChange, authorObj.ConvertToObjectOutPut());
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            await _authorRepository.DeleteAsync(id);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessRemove, author);
        }

        public async Task<IResult> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            return await Result.ResultAsync(StatusCodes.Status200OK, authors);
        }

        public async Task<IResult> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            return await Result.ResultAsync(StatusCodes.Status200OK, author); ;
        }
    }
}
