namespace Backend.Application.Loan.DTOs.Common
{
    public class BaseLoanDTO
    {
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
