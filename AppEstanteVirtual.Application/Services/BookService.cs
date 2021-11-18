using AppEstanteVirtual.Domain.Constants;
using AppEstanteVirtual.Domain.DTOs.InputModels;
using AppEstanteVirtual.Domain.Repositories;
using AppEstanteVirtual.Domain.Shared;
using AppEstanteVirtual.Domain.Shared.Contracts;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AppEstanteVirtual.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResult> CreateAsync(BookInputModelDTO bookInputModelDTO)
        {
            var book = bookInputModelDTO.ConvertToObject();
            await _bookRepository.CreateAsync(book);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessRegistered, book.ConvertToObjectOutPut());
        }

        public async Task<IResult> UpdateAsync(int id, BookInputModelDTO bookInputModelDTO, AuthorService authorService)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            var author = await authorService.GetByIdAsync(bookInputModelDTO.AuthorId);
            if (author == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            var bookObj = bookInputModelDTO.ConvertToObject();
            await _bookRepository.UpdateAsync(bookObj);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessChange, bookObj.ConvertToObjectOutPut());
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            await _bookRepository.DeleteAsync(id);

            return await Result.ResultAsync(StatusCodes.Status200OK, GlobalMessageConstants.MessageSucessRemove, book);
        }

        public async Task<IResult> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return await Result.ResultAsync(StatusCodes.Status200OK, books);
        }

        public async Task<IResult> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            return await Result.ResultAsync(StatusCodes.Status200OK, book);
        }

        public async Task<IResult> GetBooksByProgress(int progress)
        {
            var books = await _bookRepository.GetBooksByProgress(progress);

            return await Result.ResultAsync(StatusCodes.Status200OK, books);
        }

        public async Task<IResult> GetBooksByGenre(int genre)
        {
            var books = await _bookRepository.GetBooksByGenre(genre);

            return await Result.ResultAsync(StatusCodes.Status200OK, books);
        }

        public async Task<IResult> GetBooksByAuthor(int authorId, AuthorService authorService)
        {
            var author = await authorService.GetByIdAsync(authorId);

            if (author == null)
            {
                return await Result.ResultAsync(StatusCodes.Status404NotFound, GlobalMessageConstants.MessageDataNotFound);
            }

            var books = await _bookRepository.GetBooksByAuthor(authorId);

            return await Result.ResultAsync(StatusCodes.Status200OK, books);
        }
    }
}
