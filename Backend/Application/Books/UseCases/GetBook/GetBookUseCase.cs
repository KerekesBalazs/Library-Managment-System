using AutoMapper;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Books.UseCases.GetBook
{
    public class GetBookUseCase(
        ILogger<GetBookUseCase> _logger,
        IBookRepository _bookRepo,
        IMapper _mapper
    ) : IGetBookUseCase
    {
        public async Task<GetBookDTO> ExecuteAsync(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);

            if (book == null)
            {
                throw new BookNotFoundException();
            }

            return _mapper.Map<GetBookDTO>(book);
        }
    }
}
