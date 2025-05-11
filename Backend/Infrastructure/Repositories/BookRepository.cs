using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class BookRepository(DataContext _context) : IBookRepository
    {
        public async Task<Book> AddBookAsync(Book book)
        {
            var createdBook = await _context.Books.AddAsync(book);
            return createdBook.Entity;
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            await _context.Books
                .Where(b => b.Id == bookId)
                .ExecuteDeleteAsync();

            var affected = await _context.Books
                .Where(b => b.Id == bookId)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public Book UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return book;
        }
    }
}
