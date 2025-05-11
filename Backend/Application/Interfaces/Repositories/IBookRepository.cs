using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        public Task<Book?> GetBookByIdAsync(int id);

        public Task<List<Book>> GetBooksAsync();

        public Task<Book> AddBookAsync(Book book);

        public Book UpdateBook(Book book);

        public Task<bool> DeleteBookAsync(int bookId);
    }
}
