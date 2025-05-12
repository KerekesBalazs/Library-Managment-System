namespace WebAPI.DTOModels.Outgoing.Loan
{
    public class GetLoanResponse
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
