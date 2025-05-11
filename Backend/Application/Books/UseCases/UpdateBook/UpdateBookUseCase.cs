using AutoMapper;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Books.DTOs.Update;
using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Books.UseCases.UpdateBook
{
    public class UpdateBookUseCase(
        ILogger<UpdateBookUseCase> _logger,
        DataContext _context,
        IMapper _mapper,
        IBookRepository _bookRepo
    ) : IUpdateBookUseCase
    {
        public async Task<GetBookDTO> ExecuteAsync(UpdateBookDTO bookDTO)
        {
            var existingBook = await _bookRepo.GetBookByIdAsync(bookDTO.Id);

            if (existingBook == null)
            {
                throw new BookNotFoundException();
            }

            _mapper.Map(bookDTO, existingBook);

            var updatedBook = _bookRepo.UpdateBook(existingBook);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetBookDTO>(updatedBook);
        }
    }
}
