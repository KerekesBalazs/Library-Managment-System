namespace WebAPI.DTOModels.Incoming.Book
{
    public class BookFilterDTO
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Quantity { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }
        public int? PublishedYear { get; set; }
    }
}
