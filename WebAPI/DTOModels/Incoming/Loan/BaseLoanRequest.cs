namespace WebAPI.DTOModels.Incoming.Loan
{
    public class BaseLoanRequest
    {
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
