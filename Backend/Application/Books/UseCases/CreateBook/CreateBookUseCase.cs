using AutoMapper;
using Backend.Application.Books.DTOs.Create;
using Backend.Application.Books.DTOs.Get;
using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Books.UseCases.CreateBook
{
    public class CreateBookUseCase(
        ILogger<CreateBookUseCase> _logger,
        DataContext _context,
        IMapper _mapper,
        IBookRepository _bookRepo
    ) : ICreateBookUseCase
    {
        public async Task<GetBookDTO> ExecuteAsync(CreateBookDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);

            // Create the book
            var createdBook = await _bookRepo.AddBookAsync(bookEntity);
            // Persist the changes in the data store
            _context.SaveChanges();

            return _mapper.Map<GetBookDTO>(createdBook);
        }
    }
}
