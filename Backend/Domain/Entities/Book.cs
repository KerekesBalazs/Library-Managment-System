using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("books")]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public string ISBN { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int PublishedYear { get; set; }

        public ICollection<Loan> Loans { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
