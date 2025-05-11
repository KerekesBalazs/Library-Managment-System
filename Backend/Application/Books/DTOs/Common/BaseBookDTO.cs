namespace Backend.Application.Books.DTOs.Common
{
    public class BaseBookDTO
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public string ISBN { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int PublishedYear { get; set; }
    }
}
