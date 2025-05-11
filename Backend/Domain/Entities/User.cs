using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Loan> Loans { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
