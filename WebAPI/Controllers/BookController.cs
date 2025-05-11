using Microsoft.AspNetCore.Mvc;
using Backend.Application.Books.UseCases.CreateBook;
using AutoMapper;
using Backend.Application.Books.UseCases.DeleteBook;
using Backend.Application.Books.UseCases.UpdateBook;
using Backend.Application.Books.UseCases.GetBook;
using WebAPI.DTOModels.Outgoing.Book;
using Backend.Domain.Exceptions;
using WebAPI.DTOModels.Incoming.Book;
using Backend.Application.Books.DTOs.Create;
using Backend.Application.Books.DTOs.Update;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController(
        ICreateBookUseCase _createBookUseCase,
        IUpdateBookUseCase _updateBookUseCase,
        IDeleteBookUseCase _deleteBookUseCase,
        IGetBookUseCase _getBookUseCase,
        IMapper _mapper,
        ILogger<BookController> _logger
    ) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookResponse))]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            try
            {
                var book = await _getBookUseCase.ExecuteAsync(id);

                return Ok(new BaseResponse<GetBookResponse>
                {
                    Data = _mapper.Map<GetBookResponse>(book),
                    Type = "Success",
                    Message = "server.book_found"
                });
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found", id);
                return NotFound(new BaseResponse<GetBookResponse>
                {
                    Type = "Warning",
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookResponse))]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest bookRequest)
        {
            //try
            //{
                var bookDTO = _mapper.Map<CreateBookDTO>(bookRequest);
                var createdbook = await _createBookUseCase.ExecuteAsync(bookDTO);

                return Ok(new BaseResponse<GetBookResponse>
                {
                    Data = _mapper.Map<GetBookResponse>(createdbook),
                    Type = "Success",
                    Message = "server.book_created"
                });
            //}
            //catch (BookAlreadyExistsException ex)
            //{
            //    _logger.LogWarning("Book with ... already exists: {Message}", ex.Message);
            //    return BadRequest(new BaseResponse<GetBookResponse>
            //    {
            //        Type = "Error",
            //        Message = ex.Message,
            //    });
            //}
        }

        [HttpPut("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookResponse))]
        public async Task<IActionResult> UpdateBook([FromRoute] int bookId, [FromBody] UpdateBookRequest bookRequest)
        {
            try
            {
                var bookDTO = _mapper.Map<UpdateBookDTO>(bookRequest);
                bookDTO.Id = bookId;

                var updatedBook = await _updateBookUseCase.ExecuteAsync(bookDTO);

                return Ok(new BaseResponse<GetBookResponse>
                {
                    Data = _mapper.Map<GetBookResponse>(updatedBook),
                    Type = "Success",
                    Message = "server.book_updated"
                });
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found", bookId);
                return NotFound(new BaseResponse<GetBookResponse>
                {
                    Data = null,
                    Type = "Error",
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            try
            {
                var result = await _deleteBookUseCase.ExecuteAsync(bookId);
                return NoContent();
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found", bookId);
                return NotFound(new BaseResponse<GetBookResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
            catch (BookWasLoanedException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} was loaned", bookId);
                return NotFound(new BaseResponse<GetBookResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
        }
    }
}
