using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("loans")]
    public class Loan
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
