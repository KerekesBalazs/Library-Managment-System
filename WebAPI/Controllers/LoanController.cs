using AutoMapper;
using Backend.Application.Loan.DTOs.Create;
using Backend.Application.Loan.DTOs.Update;
using Backend.Application.Loan.UseCases.CreateLoan;
using Backend.Application.Loan.UseCases.DeleteLoan;
using Backend.Application.Loan.UseCases.GetLoan;
using Backend.Application.Loan.UseCases.UpdateLoan;
using Backend.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOModels.Incoming.Loan;
using WebAPI.DTOModels.Outgoing.Book;
using WebAPI.DTOModels.Outgoing.Loan;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("loans")]
    public class LoanController(
        ICreateLoanUseCase _createLoanUseCase,
        IUpdateLoanUseCase _updateLoanUseCase,
        IDeleteLoanUseCase _deleteLoanUseCase,
        IGetLoanUseCase _getLoanUseCase,
        IMapper _mapper,
        ILogger<LoanController> _logger
    ) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLoanResponse))]
        public async Task<IActionResult> GetLoan([FromRoute] int id)
        {
            try
            {
                var loan = await _getLoanUseCase.ExecuteAsync(id);

                return Ok(new BaseResponse<GetLoanResponse>
                {
                    Data = _mapper.Map<GetLoanResponse>(loan),
                    Type = "Success",
                    Message = "server.loan_found"
                });
            }
            catch (LoanNotFoundException ex)
            {
                _logger.LogWarning(ex, "Loan with ID {Id} not found", id);
                return NotFound(new BaseResponse<GetBookResponse>
                {
                    Type = "Warning",
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLoanResponse))]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanRequest loanRequest)
        {
            try
            {
                var loanDTO = _mapper.Map<CreateLoanDTO>(loanRequest);
                var createdLoad = await _createLoanUseCase.ExecuteAsync(loanDTO);

                return Ok(new BaseResponse<GetLoanResponse>
                {
                    Data = _mapper.Map<GetLoanResponse>(createdLoad),
                    Type = "Success",
                    Message = "server.loan_created"
                });
            }
            catch (BookWasLoanedException ex)
            {
                _logger.LogWarning("Loan with ... already exists: {Message}", ex.Message);
                return BadRequest(new BaseResponse<GetLoanResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogWarning("User with this is don't exists: {Message}", ex.Message);
                return BadRequest(new BaseResponse<GetLoanResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
            catch (BookUnavailableReservationCreatedException ex)
            {
                _logger.LogWarning("Book Unavailable, Reservation Created: {Message}", ex.Message);
                return BadRequest(new BaseResponse<GetLoanResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{loanId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLoanResponse))]
        public async Task<IActionResult> UpdateLoan([FromRoute] int loanId, [FromBody] UpdateLoanRequest loadRequest)
        {
            try
            {
                var loanDTO = _mapper.Map<UpdateLoanDTO>(loadRequest);
                loanDTO.Id = loanId;

                var updatedBook = await _updateLoanUseCase.ExecuteAsync(loanDTO);

                return Ok(new BaseResponse<GetLoanResponse>
                {
                    Data = _mapper.Map<GetLoanResponse>(updatedBook),
                    Type = "Success",
                    Message = "server.loan_updated"
                });
            }
            catch (LoanNotFoundException ex)
            {
                _logger.LogWarning(ex, "Book with ID {Id} not found", loanId);
                return NotFound(new BaseResponse<GetLoanResponse>
                {
                    Data = null,
                    Type = "Error",
                    Message = ex.Message,
                });
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogWarning("User with this is don't exists: {Message}", ex.Message);
                return BadRequest(new BaseResponse<GetLoanResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{loanId}")]
        public async Task<IActionResult> DeleteLoan([FromRoute] int loanId)
        {
            try
            {
                var result = await _deleteLoanUseCase.ExecuteAsync(loanId);
                return NoContent();
            }
            catch (LoanNotFoundException ex)
            {
                _logger.LogWarning(ex, "Loan with ID {Id} not found", loanId);
                return NotFound(new BaseResponse<GetLoanResponse>
                {
                    Type = "Error",
                    Message = ex.Message,
                });
            }
        }
    }
}
